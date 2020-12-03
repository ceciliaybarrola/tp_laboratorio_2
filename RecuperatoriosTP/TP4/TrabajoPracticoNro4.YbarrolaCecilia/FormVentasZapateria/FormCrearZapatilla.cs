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
    /// Form que toma los datos necesarios para crear una zapatilla
    /// </summary>
    public partial class FormCrearZapatilla : Form
    {
        protected Zapatilla zapatilla;
        #region constructores
        /// <summary>
        /// constructor por defecto que inicializa los componentes
        /// </summary>
        public FormCrearZapatilla()
        {
            InitializeComponent();
        }
        /// <summary>
        /// constructor parametrizado que ubica los atributos de la zapatilla en los diferentes objetos
        /// usados para tomar datos
        /// </summary>
        /// <param name="zapatilla"></param>
        public FormCrearZapatilla(Zapatilla zapatilla)
            :this()
        {
            this.comboBoxUsoRecomendado.Text = zapatilla.UsoRecomendado;
            this.textBoxCantidad.Text = zapatilla.Cantidad.ToString();
            this.textBoxPrecio.Text = zapatilla.Precio.ToString();
            this.textBoxNombre.Text = zapatilla.Nombre;
            this.comboBoxMateriales.Text = zapatilla.Material;
        }
        #endregion
        #region Propiedad
        /// <summary>
        /// propiedad de solo lectura del atributo zapatilla
        /// </summary>
        public Zapatilla Zapatilla
        {
            get { return this.zapatilla; }

        }
        #endregion
        #region Metodos
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                this.zapatilla = new Zapatilla(this.comboBoxUsoRecomendado.Text, this.textBoxCantidad.Text,
                                this.textBoxPrecio.Text, this.textBoxNombre.Text, this.comboBoxMateriales.Text);

                this.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;          
        }
        #endregion
    }
}
