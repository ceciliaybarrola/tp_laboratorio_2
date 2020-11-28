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
    /// form utilizado para crear un zapato
    /// </summary>
    public partial class FormCrearZapato : Form
    {
        private Zapato zapato;
        /// <summary>
        /// constructor por defecto donde se inicializan los componentes
        /// </summary>
        public FormCrearZapato()
        {
            InitializeComponent();
        }
        /// <summary>
        /// constructor en el que pone los atributos en los objetos donde se ingresan los datos
        /// </summary>
        /// <param name="zapato"></param>
        public FormCrearZapato(Zapato zapato) : this()
        {
            this.comboBoxTipoDeTaco.Text = zapato.TipoDeTaco;
            this.textBoxCantidad.Text = zapato.Cantidad.ToString();
            this.textBoxPrecio.Text = zapato.Precio.ToString();
            this.textBoxNombre.Text = zapato.Nombre;
            this.comboBoxMateriales.Text = zapato.Material;
        }
        /// <summary>
        /// propiedad de solo lectura del atributo zapato
        /// </summary>
        public Zapato Zapato
        {
            get { return this.zapato; }

        }
        /// <summary>
        /// boton que crea un nuevo zapato a partir de los valores ingresados
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
        /// <summary>
        /// cancela la operacion
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }
    }
}
