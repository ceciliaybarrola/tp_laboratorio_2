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
    public partial class FormCrearZapato : Form
    {
        private Zapato zapato;
        public FormCrearZapato()
        {
            InitializeComponent();
        }
        public FormCrearZapato(Zapato zapato) : this()
        {
            this.comboBoxTipoDeTaco.Text = zapato.TipoDeTaco;
            this.textBoxCantidad.Text = zapato.Cantidad.ToString();
            this.textBoxPrecio.Text = zapato.Precio.ToString();
            this.textBoxNombre.Text = zapato.Nombre;
            this.comboBoxMateriales.Text = zapato.Material;
        }
        public Zapato Zapato
        {
            get { return this.zapato; }

        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                this.zapato = new Zapato(this.comboBoxTipoDeTaco.Text, this.textBoxCantidad.Text,
                                this.textBoxPrecio.Text, this.textBoxNombre.Text, this.comboBoxMateriales.Text);

                this.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
            catch(Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }
    }
}
