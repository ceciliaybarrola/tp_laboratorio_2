using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Productos;

namespace FormVentasZapateria
{
    /// <summary>
    /// formulario que se encarga de seleccionar la cantidad de articulos que se quiere comprar
    /// </summary>
    public partial class FormAgregarCarrito : Form
    {
        public Calzado calzado;
        /// <summary>
        /// constructor que recibe un calzado como parametro e inicializa los componentes
        /// </summary>
        /// <param name="calzado"></param>
        public FormAgregarCarrito(Calzado calzado)
        {
            InitializeComponent();
            this.calzado = calzado;
            this.rtbProductoCaracteristicas.Text = calzado.ToString();
            this.textBoxCantidad.Text = calzado.Cantidad.ToString();
        }
        /// <summary>
        /// boton cancelar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }
        /// <summary>
        /// boton aceptar, en caso de estar todos los datos en orden, se actualizara la cantidad
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            int cantidad;
            if(int.TryParse(this.textBoxCantidad.Text, out cantidad) && cantidad <= calzado.Cantidad && cantidad > 0)
            {
                calzado.Cantidad = cantidad;
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
            else
            {
                MessageBox.Show("Cantidad invalida. Ingrese una cantidad valida para el stock disponible");
            }

        }
    }
}
