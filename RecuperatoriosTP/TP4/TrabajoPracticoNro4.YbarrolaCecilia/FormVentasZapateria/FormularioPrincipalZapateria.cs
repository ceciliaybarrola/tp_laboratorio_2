using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Negocio;
using Productos;
using Archivos;
using Excepciones;
using System.Threading;

namespace FormVentasZapateria
{
    /// <summary>
    /// Clase formulario principal, donde se iniciara y terminara el proyecto
    /// </summary>
    public partial class FormularioPrincipalZapateria : Form
    {
        public Zapateria zapateria;
        public DataTable dataTableCalzados;
        public List<Calzado> listaCarritoCompras;

        public delegate void delegadoActualizaciones();
        public event delegadoActualizaciones eventoActualizarDatosForm;
        public Thread hiloActualiacionListas;

        /// <summary>
        /// USA HILOS, EVENTOS, DELEGADOS Y DATABASE
        /// constructor por defecto, en él se inicializarán los atributos instanciables, 
        /// se le otorgaran valores a algunos elementos del form, se iniciará el hilo secundario que ejecutará
        /// un metodo con la invocacion de un evento con algunos de los metodos de actualizacion de datos y 
        /// mejora de la interfaz asociados (encargado de actualizar la lista del stock de la zapateria -usada 
        /// para agilizar algunas busquedas- con la base de datos, actualizar el balance de de las ventas 
        /// -porcentaje de ganancia- y la cantidad de ventas realizadas)
        /// </summary>
        public FormularioPrincipalZapateria()
        {
            InitializeComponent();
            this.zapateria = new Zapateria("Don Armando Shoes");
            this.labelTitulo.Text += this.zapateria.nombreZapateria;
            this.listaCarritoCompras = new List<Calzado>();
            this.StartPosition = FormStartPosition.CenterScreen;

            this.zapateria.stock = AccesoDatos.ObtenerListaCalzados();
            this.dataTableCalzados = AccesoDatos.ObtenerTablaCalzado();
            this.dataGridViewDataTable.DataSource = this.dataTableCalzados;

            this.eventoActualizarDatosForm += ActualiarListaZapateriaDB;
            this.eventoActualizarDatosForm += ActualiarBalanceDelDia;
            this.eventoActualizarDatosForm += ActualiarVentasDelDia;

            this.hiloActualiacionListas = new Thread(this.Actualizaciones);
            hiloActualiacionListas.Start();
        }
        #region Metodos
        /// <summary>
        /// USA EVENTOS
        /// Metodo asociado al hilo de actualizaciones donde se invoca a los distintos manejadores de eventos
        /// </summary>
        public void Actualizaciones()
        {
            while (true)
            {
                this.eventoActualizarDatosForm.Invoke();
                Thread.Sleep(3000);
            }
        }
        /// <summary>
        /// USA DELEGADOS Y BASE DE DATOS
        /// Actualiza el Data Grid con los datos de la base de datos
        /// </summary>
        public void ActualiarDataGridDB()
        {       
            if(this.dataGridViewDataTable.InvokeRequired)
            {
                delegadoActualizaciones delegado = new delegadoActualizaciones(this.ActualiarDataGridDB);
                this.Invoke(delegado);
            }
            else
            {
                this.dataTableCalzados= AccesoDatos.ObtenerTablaCalzado();
                this.dataGridViewDataTable.DataSource = this.dataTableCalzados;
            }              
        }
        /// <summary>
        /// USA DELEGADOS
        /// actualiza la lista de stock de la zapateria -usada para agilizar algunas busquedas- con la base de datos
        /// </summary>
        public void ActualiarListaZapateriaDB()
        {
            this.zapateria.stock = AccesoDatos.ObtenerListaCalzados();
        }
        /// <summary>
        /// USA DELEGADOS
        /// actualiza la ganancia de las ventas hechas en tiempo de ejecucion -el %20 del precio del producto-
        /// </summary>
        public void ActualiarBalanceDelDia()
        {
            if (this.labelGanancias.InvokeRequired)
            {
                delegadoActualizaciones delegado = new delegadoActualizaciones(this.ActualiarBalanceDelDia);
                this.Invoke(delegado);
            }
            else
            {
                this.labelGanancias.Text = "Ganancia del dia: " + this.zapateria.BalanceDelDia(); 
            }
        }
        /// <summary>
        /// USA DELEGADOS
        /// actualiza la cantidad de ventas hechas en el dia
        /// </summary>
        public void ActualiarVentasDelDia()
        {
            if (this.labelGanancias.InvokeRequired)
            {
                delegadoActualizaciones delegado = new delegadoActualizaciones(this.ActualiarVentasDelDia);
                this.Invoke(delegado);
            }
            else
            {
                this.labelVentas.Text = "Ventas del dia: " + this.zapateria.ventas.Count;
            }
        }
        /// <summary>
        /// USA DATABASE
        /// Añade a la lista que funciona como carrito un producto seleccionado, el cual se podra elegir 
        /// que cantidad de productos se querrá comprar mediante el uso de otro formulario. Tambien 
        /// escribe el ticket de compra en el formulario para una mejor experiencia de usuario y para 
        /// tener noción de qué se está vendiendo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AñadirAlCarro_Click(object sender, EventArgs e)
        {
            try
            {
                int i = this.dataGridViewDataTable.SelectedRows[0].Index;
                DataRow fila = this.dataTableCalzados.Rows[i];
                int id = int.Parse(fila["id"].ToString());

                Calzado calzado = AccesoDatos.ObtenerCalzadoPorID(id);
                if(!this.listaCarritoCompras.Contains(calzado))
                {
                    FormAgregarCarrito carrito = new FormAgregarCarrito(calzado);
                    carrito.StartPosition= FormStartPosition.CenterScreen;

                    if (carrito.ShowDialog() == DialogResult.OK)
                    {
                        this.listaCarritoCompras.Add(carrito.calzado);
                        this.rtbListaChanguito.Text = Zapateria.EscribirTicket(this.listaCarritoCompras, this.zapateria);                               
                    }
                }
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Por favor, seleccione un producto antes de agregar al carrito");
            }
            catch(Exception exception)
            {
                MessageBox.Show("Error al añadir al carrito: " + exception.Message);
            }
        }
        /// <summary>
        /// USA ARCHIVOS DE TEXTO Y DATABASE
        /// En caso de haber productos en el carrito de compras, agrega esa lista a la de vendidos de zapateria, sube
        /// el ticket de esta venta a el archivo de texto que guarda una copia de estos registros y
        /// recorre sus elementos para obtenerlos por id de la base de datos y restarle a los productos de la base
        /// la cantidad que se va a vender, para luego modificar esta. Actualiza los cambios y vacia los elementos 
        /// relacionados a la venta (lista de carrito y rich text box con el ticket).
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Venta_Click(object sender, EventArgs e)
        {
            try
            {
                if(this.listaCarritoCompras.Count > 0)
                {
                    this.zapateria.ventas.AddRange(this.listaCarritoCompras);
                    zapateria.EscribirTicketera(this.listaCarritoCompras);
            
                    foreach(Calzado item in this.listaCarritoCompras)
                    {
                        item.Cantidad = (AccesoDatos.ObtenerCalzadoPorID(item.Id)).Cantidad - item.Cantidad;
                        AccesoDatos.ModificarCalzado(item);
                    }
                    this.ActualiarDataGridDB();
                    this.CancelarCompra_Click(sender, e);
                }
                else
                {
                    MessageBox.Show("Primero añade productos al carrito");
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }

        }
        /// <summary>
        /// vacia el carrito de compras y limpia el rich text box con el ticket
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CancelarCompra_Click(object sender, EventArgs e)
        {
            this.rtbListaChanguito.Text = "";
            this.listaCarritoCompras.Clear();
        }
        /// <summary>
        /// TEMA ARCHIVOS DE TEXTO
        /// Muestra en un form nuevo el archivo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Ticket_Click(object sender, EventArgs e)
        {
            try
            {
                FormTicketera ticketera = new FormTicketera(Zapateria.LeerTicketera());
                ticketera.ShowDialog();
            }
            catch (ArchivosException exception)
            {
                MessageBox.Show(exception.Message);
            }
        }
        /// <summary>
        /// USA DATA BASE
        /// Permite crear una nueva zapatilla o zapato para agregar en la base de datos. 
        /// Si no existe en la lista de stock de la zapateria (asociada al la DB), simplemente 
        /// se la agregará. De lo contrario, selecciono de la base de datos el calzado que tenga
        /// en comun todos los atributos excepto el precio y la cantidad para luego incrementar 
        /// su stock y modificar el calzado
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Agregar_Click(object sender, EventArgs e)
        {
            try
            {
                string cadenaComando;
                Calzado calzadoDataBase;
                FormAgregarProductos seleccionProductos = new FormAgregarProductos();
                seleccionProductos.StartPosition = FormStartPosition.CenterScreen;

                if(seleccionProductos.ShowDialog() == DialogResult.OK)
                {
                    if(this.zapateria != seleccionProductos.Calzado)// si este calzado no existe en la lista
                    {
                        AccesoDatos.InsertarCalzado(seleccionProductos.Calzado);//agrego a la base de datos
                    }
                    else //si es un dato repetido, incremento su valor
                    {
                        if(seleccionProductos.Calzado is Zapatilla)
                        {
                            cadenaComando= "SELECT * FROM StockZapateria WHERE nombre = @nombre AND material = @material AND usoRecomendado = @usoRecomendado;";
                        }
                        else
                        {
                            cadenaComando = "SELECT * FROM StockZapateria WHERE nombre = @nombre AND material = @material AND tipoDeTaco = @tipoDeTaco;";
                        }
                        seleccionProductos.Calzado.ComandoSQL(cadenaComando, AccesoDatos.conexion, AccesoDatos.comando, out calzadoDataBase);
                        calzadoDataBase.Cantidad += seleccionProductos.Calzado.Cantidad;

                        AccesoDatos.ModificarCalzado(calzadoDataBase);
                    }
                    this.ActualiarDataGridDB();
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show("Error al agregar: " + exception.Message);
            }
        }
        /// <summary>
        /// USA DATABASE
        /// Se selecciona una fila del data grid, busca ese elemento en la dataBase y crea un form 
        /// dependiendo del tipo para modificar ese objeto. En caso de aceptar los cambios, hace un 
        /// update de ese elemento con los nuevos valores.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Modificar_Click(object sender, EventArgs e)
        {
            try
            {
                int i = this.dataGridViewDataTable.SelectedRows[0].Index;

                DataRow fila = this.dataTableCalzados.Rows[i];
                int id = int.Parse(fila["id"].ToString());
                Calzado calzado = AccesoDatos.ObtenerCalzadoPorID(id);

                if(calzado is Zapatilla)
                {
                    FormCrearZapatilla formZapatilla = new FormCrearZapatilla((Zapatilla)calzado);
                    if (formZapatilla.ShowDialog() == DialogResult.OK)
                    {
                        formZapatilla.Zapatilla.Id = calzado.Id;
                        AccesoDatos.ModificarCalzado(formZapatilla.Zapatilla);
                    }
                }
                else
                {
                    FormCrearZapato formZapato = new FormCrearZapato((Zapato)calzado);
                    if (formZapato.ShowDialog() == DialogResult.OK)
                    {
                        formZapato.Zapato.Id = calzado.Id;
                        AccesoDatos.ModificarCalzado(formZapato.Zapato);
                    }
                }
                this.ActualiarDataGridDB();

            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Por favor, seleccione un producto antes de modificar");
            }
            catch (Exception exception)
            {
                MessageBox.Show("Error al modificar: " + exception.Message);
            }

        }
        /// <summary>
        /// USA DATABASE
        /// Selecciona un producto de la tabla y lo elimina de la base de datos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void botonEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                int i = this.dataGridViewDataTable.SelectedRows[0].Index;
                DataRow fila = this.dataTableCalzados.Rows[i];
                int id= int.Parse(fila["id"].ToString());

                AccesoDatos.EliminarCalzado(AccesoDatos.ObtenerCalzadoPorID(id));
                this.ActualiarDataGridDB();
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Por favor, seleccione un producto antes de eliminar");
            }
            catch (Exception exception)
            {
                MessageBox.Show("Error al eliminar: " + exception.Message);
            }
        }
        /// <summary>
        /// USA SERIALIZACION XML
        /// serializa la zapateria dentro de un archivo xml
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GuardarCambios_Click(object sender, EventArgs e)
        {
            try
            {
                Zapateria.Guardar(this.zapateria);
                MessageBox.Show("Se ha guardado exitosamente");
            }
            catch(ArchivosException exception)
            {
                MessageBox.Show(exception.Message);
            }
        }
        /// <summary>
        /// Cierra el formulario. Previamente consulta si se quiere cancelar dicha operacion
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Salir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// USA HILOS
        /// evento asociado al form closing. En este evento se abortara el hilo secundario si esta vivo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormVentasZapateria_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult respuesta = MessageBox.Show("¿Está seguro de salir?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

            if (respuesta == DialogResult.Yes)
            {
                e.Cancel = false;
                if (this.hiloActualiacionListas.IsAlive)
                {
                    this.hiloActualiacionListas.Abort();
                }
            }
            else
            {
                e.Cancel = true;
            }
        }
        #endregion
    }
}
