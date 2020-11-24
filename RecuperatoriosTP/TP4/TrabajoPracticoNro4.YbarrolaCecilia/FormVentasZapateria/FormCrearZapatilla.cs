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
    public partial class FormCrearZapatilla : Form
    {
        protected Zapatilla zapatilla;


        public FormCrearZapatilla()
        {
            InitializeComponent();
        }
        public FormCrearZapatilla(Zapatilla zapatilla)
            :this()
        {
            this.comboBoxUsoRecomendado.Text = zapatilla.UsoRecomendado;
            this.textBoxCantidad.Text = zapatilla.Cantidad.ToString();
            this.textBoxPrecio.Text = zapatilla.Precio.ToString();
            this.textBoxNombre.Text = zapatilla.Nombre;
            this.comboBoxMateriales.Text = zapatilla.Material;
        }
        public Zapatilla Zapatilla
        {
            get { return this.zapatilla; }

        }
        private void btnAceptar_Click(object sender, EventArgs e)
        {

            try
            {
                this.zapatilla = new Zapatilla(this.comboBoxUsoRecomendado.Text, this.textBoxCantidad.Text,
                                this.textBoxPrecio.Text, this.textBoxNombre.Text, this.comboBoxMateriales.Text);

                this.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
            catch
            {
                
            }

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            
        }
    }
}
