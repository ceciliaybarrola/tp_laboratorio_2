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
    public partial class FormAgregarCarrito : Form
    {
        public Calzado calzado;

        public FormAgregarCarrito(Calzado calzado)
        {
            InitializeComponent();
            this.calzado = calzado;
            this.rtbProductoCaracteristicas.Text = calzado.ToString();
            this.textBoxCantidad.Text = calzado.Cantidad.ToString();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            int cantidad;
            if(int.TryParse(this.textBoxCantidad.Text, out cantidad) && cantidad <= calzado.Cantidad && cantidad > 0)
            {
                calzado.Cantidad = cantidad;
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
            }

        }
    }
}
