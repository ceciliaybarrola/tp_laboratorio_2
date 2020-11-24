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


        public FormularioPrincipalZapateria()
        {
            InitializeComponent();
            this.zapateria = new Zapateria("Don Armando Shoes");
            this.listaCarritoCompras = new List<Calzado>();
            this.StartPosition = FormStartPosition.CenterScreen;
            // No permito modificar desde la grilla
            this.dataGridViewDataTable.EditMode = DataGridViewEditMode.EditProgrammatically;


            this.zapateria.stock = AccesoDatos.ObtenerListaCalzados();
            this.dataTableCalzados = AccesoDatos.ObtenerTablaCalzado();
            this.dataGridViewDataTable.DataSource = this.dataTableCalzados;

            this.eventoActualizarDatosForm += ActualiarDataGreadDB;
            this.eventoActualizarDatosForm += ActualiarListaZapateriaDB;
            this.eventoActualizarDatosForm += ActualiarBalanceDelDia;
            this.eventoActualizarDatosForm += ActualiarVentasDelDia;

            //Thread hiloActualiacionListas = new Thread(this.Actualizaciones);
            
            // 
            // 
            //hiloActualiacionListas.Start();
        }

        public void Actualizaciones()
        {
            while (true)
            {
                
                //this.eventoActualizarDatosForm.BeginInvoke(new AsyncCallback(), );
            }
        }

        public void ActualiarDataGreadDB()//no funca
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
            Thread.Sleep(3000);                
        }
        public void ActualiarListaZapateriaDB()
        {
            this.zapateria.stock = AccesoDatos.ObtenerListaCalzados();
            Thread.Sleep(10000);
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
                this.labelGanancias.Text = this.labelGanancias.Text + " " + this.zapateria.gananciaDelDia;
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
                this.labelVentas.Text = this.labelVentas.Text + " " + this.zapateria.ventas.Count;
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

                this.zapateria.stock = AccesoDatos.ObtenerListaCalzados();
                this.dataTableCalzados = AccesoDatos.ObtenerTablaCalzado();
                this.dataGridViewDataTable.DataSource = this.dataTableCalzados;
            }
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
            Zapatilla zapatillaDataBase;
            Zapato zapatoDataBase;
            FormAgregarProductos seleccionProductos = new FormAgregarProductos();
            seleccionProductos.StartPosition = FormStartPosition.CenterScreen;

            if(seleccionProductos.ShowDialog() == DialogResult.OK)
            {
                ///chequear por casteo a zapatos para solucionar               
                if((object)seleccionProductos.Zapatilla != null)
                {
                    if(this.zapateria != seleccionProductos.Zapatilla)// si esta zapatilla no existe en la lista
                    {
                        AccesoDatos.InsertarCalzado(seleccionProductos.Zapatilla);//agrego a la base de datos
                    }
                    else
                    {               
                        string cadenaComando= "SELECT * FROM StockZapateria WHERE nombre = @nombre AND material = @material AND usoRecomendado = @usoRecomendado;";
                        seleccionProductos.Zapatilla.ComandoSQL(cadenaComando, AccesoDatos.conexion, AccesoDatos.comando, out zapatillaDataBase);
                        zapatillaDataBase.Cantidad += seleccionProductos.Zapatilla.Cantidad;

                        AccesoDatos.comando.Parameters.AddWithValue("@id", zapatillaDataBase.Id);
                        AccesoDatos.ModificarCalzado(zapatillaDataBase);                         
                    }
                }
                if ((object)seleccionProductos.Zapato != null)
                {
                    if( this.zapateria != seleccionProductos.Zapato)
                    {
                        AccesoDatos.InsertarCalzado(seleccionProductos.Zapato);//agrego a la base de datos
                    } 
                    else
                    {
                        string cadenaComando = "SELECT * FROM StockZapateria WHERE nombre = @nombre AND material = @material AND tipoDeTaco = @tipoDeTaco;";
                        seleccionProductos.Zapato.ComandoSQL(cadenaComando, AccesoDatos.conexion, AccesoDatos.comando, out zapatoDataBase);
                        zapatoDataBase.Cantidad += seleccionProductos.Zapato.Cantidad;

                        AccesoDatos.comando.Parameters.AddWithValue("@id", zapatoDataBase.Id);
                        AccesoDatos.ModificarCalzado(zapatoDataBase);
                    }
                }


                this.zapateria.stock = AccesoDatos.ObtenerListaCalzados();
                this.dataTableCalzados = AccesoDatos.ObtenerTablaCalzado();
                this.dataGridViewDataTable.DataSource = this.dataTableCalzados;
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

                    this.zapateria.stock = AccesoDatos.ObtenerListaCalzados();
                    this.dataTableCalzados = AccesoDatos.ObtenerTablaCalzado();
                    this.dataGridViewDataTable.DataSource = this.dataTableCalzados;
                }
            }
            else
            {
                FormCrearZapato formZapato = new FormCrearZapato((Zapato)calzado);
                if (formZapato.ShowDialog() == DialogResult.OK)
                {
                    formZapato.Zapato.Id = calzado.Id;
                    AccesoDatos.ModificarCalzado(formZapato.Zapato);

                    this.zapateria.stock = AccesoDatos.ObtenerListaCalzados();
                    this.dataTableCalzados = AccesoDatos.ObtenerTablaCalzado();
                    this.dataGridViewDataTable.DataSource = this.dataTableCalzados;
                }
            }
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

        }

        private void Salir_Click(object sender, EventArgs e)
        {

        }

    }
}
