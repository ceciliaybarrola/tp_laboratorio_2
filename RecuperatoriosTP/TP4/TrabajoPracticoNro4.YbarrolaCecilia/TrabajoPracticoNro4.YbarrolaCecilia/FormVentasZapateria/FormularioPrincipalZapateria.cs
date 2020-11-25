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
    public partial class FormularioPrincipalZapateria : Form
    {
        public Zapateria zapateria;
        public DataTable dataTableCalzados;
        public List<Calzado> listaCarritoCompras;

        public delegate void delegadoActualizaciones();
        public event delegadoActualizaciones eventoActualizarDatosForm;
        public Thread hiloActualiacionListas;


        public FormularioPrincipalZapateria()
        {
            InitializeComponent();
            this.zapateria = new Zapateria("Don Armando Shoes");
            this.listaCarritoCompras = new List<Calzado>();
            this.StartPosition = FormStartPosition.CenterScreen;
            // No permito modificar desde la grilla
            this.dataGridViewDataTable.EditMode = DataGridViewEditMode.EditProgrammatically;
            this.dataGridViewDataTable.MultiSelect = false;


            this.zapateria.stock = AccesoDatos.ObtenerListaCalzados();
            this.dataTableCalzados = AccesoDatos.ObtenerTablaCalzado();
            this.dataGridViewDataTable.DataSource = this.dataTableCalzados;

           // this.eventoActualizarDatosForm += ActualiarDataGreadDB;
            this.eventoActualizarDatosForm += ActualiarListaZapateriaDB;
            this.eventoActualizarDatosForm += ActualiarBalanceDelDia;
            this.eventoActualizarDatosForm += ActualiarVentasDelDia;

            this.hiloActualiacionListas = new Thread(this.Actualizaciones);
            hiloActualiacionListas.Start();
        }

        public void Actualizaciones()
        {
            while (true)
            {
                this.eventoActualizarDatosForm.Invoke();
            }
        }

        public void ActualiarDataGreadDB()
        {       
            if(this.dataGridViewDataTable.InvokeRequired)
            {
                delegadoActualizaciones delegado = new delegadoActualizaciones(this.ActualiarDataGreadDB);
                this.Invoke(delegado);
            }
            else
            {
                this.dataTableCalzados= AccesoDatos.ObtenerTablaCalzado();
                this.dataGridViewDataTable.DataSource = this.dataTableCalzados;
            }              
        }
        public void ActualiarListaZapateriaDB()
        {
            this.zapateria.stock = AccesoDatos.ObtenerListaCalzados();
        }
        public void ActualiarBalanceDelDia()
        {
            if (this.labelGanancias.InvokeRequired)
            {
                delegadoActualizaciones delegado = new delegadoActualizaciones(this.ActualiarBalanceDelDia);
                this.Invoke(delegado);
            }
            else
            {
                this.labelGanancias.Text = "Ganancia del dia: " + this.zapateria.BalanceDelDia(); ;
            }
        }
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


        private void AñadirAlCarro_Click(object sender, EventArgs e)
        {
            int i = this.dataGridViewDataTable.SelectedRows[0].Index;
            DataRow fila = this.dataTableCalzados.Rows[i];
            int id = int.Parse(fila["id"].ToString());

            Calzado calzado = AccesoDatos.ObtenerCalzadoPorID(id);
            if(!(this.listaCarritoCompras.Contains(calzado)))
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
        private void Venta_Click(object sender, EventArgs e)
        {

            this.zapateria.ventas.AddRange(this.listaCarritoCompras);
            zapateria.EscribirTicketera(this.listaCarritoCompras);
            // despues chequear por si no existe este archivo porque no se crearon las ventas en el boton mostrar
            
            foreach(Calzado item in this.listaCarritoCompras)
            {
                item.Cantidad = (AccesoDatos.ObtenerCalzadoPorID(item.Id)).Cantidad - item.Cantidad;
                AccesoDatos.ModificarCalzado(item);
            }
            this.ActualiarDataGreadDB();
        }
        private void CancelarCompra_Click(object sender, EventArgs e)
        {
            this.rtbListaChanguito.Text = "";
            this.listaCarritoCompras.Clear();
        }
        private void Ticket_Click(object sender, EventArgs e)
        {
            FormTicketera ticketera = new FormTicketera(Zapateria.LeerTicketera());
            ticketera.ShowDialog();
        }

        private void Agregar_Click(object sender, EventArgs e)
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
                else
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

                    AccesoDatos.comando.Parameters.AddWithValue("@id", calzadoDataBase.Id);
                    AccesoDatos.ModificarCalzado(calzadoDataBase);
                }
                this.ActualiarDataGreadDB();
            }
        }

        private void Modificar_Click(object sender, EventArgs e)
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
            this.ActualiarDataGreadDB();

        }
        private void botonEliminar_Click(object sender, EventArgs e)
        {
            int i = this.dataGridViewDataTable.SelectedRows[0].Index;
            DataRow fila = this.dataTableCalzados.Rows[i];
            int id= int.Parse(fila["id"].ToString());

            AccesoDatos.EliminarCalzado(AccesoDatos.ObtenerCalzadoPorID(id));
            fila.Delete();
        }

        private void GuardarCambios_Click(object sender, EventArgs e)
        {
            try
            {
                Xml<Zapateria> xmlZapateria = new Xml<Zapateria>();
                xmlZapateria.Guardar("Zapateria.xml", this.zapateria);
                MessageBox.Show("Se ha guardado exitosamente");
            }
            catch
            {
                MessageBox.Show("Error al guardar");
            }

        }

        private void Salir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void FormVentasZapateria_FormClosing(object sender, FormClosingEventArgs e)
        {
            string nvfd = e.CloseReason.ToString();
            Console.WriteLine(nvfd);

            DialogResult rta = MessageBox.Show("¿Está seguro de salir?", "Atención",
                                                MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                                                MessageBoxDefaultButton.Button2);

            if (rta == DialogResult.Yes)
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
    }
}
