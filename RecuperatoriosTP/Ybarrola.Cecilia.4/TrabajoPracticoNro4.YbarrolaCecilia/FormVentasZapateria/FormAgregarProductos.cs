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
    /// Form intermediario entre el principal y el de creacion que permite 
    /// elegir si se desea agregar un zapato o zapatilla
    /// </summary>
    public partial class FormAgregarProductos : Form
    {
        protected Calzado calzado;
        private bool seCreo;
        /// <summary>
        /// propiedad de solo lectura del atributo calzado
        /// </summary>
        public Calzado Calzado
        {
            get { return this.calzado; }

        }
        /// <summary>
        /// constructor por defecto del Form
        /// </summary>
        public FormAgregarProductos()
        {
            InitializeComponent();
        }
        #region Metodos
        /// <summary>
        /// Boton que crea una instancia del form crear zapato donde se podra crear un zapato
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BotonAgregarZapato_Click(object sender, EventArgs e)
        {
            FormCrearZapato nuevoZapato = new FormCrearZapato();
            nuevoZapato.StartPosition = FormStartPosition.CenterScreen;
            if (nuevoZapato.ShowDialog() == DialogResult.OK)
            {
                this.calzado = nuevoZapato.Zapato;
                this.seCreo = true;
            }
        }
        /// <summary>
        /// Boton que crea una instancia del form crear zapatilla donde se podra crear una zapatilla
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BotonAgregarZapatilla_Click(object sender, EventArgs e)
        {
            FormCrearZapatilla nuevaZapatilla = new FormCrearZapatilla();
            nuevaZapatilla.StartPosition = FormStartPosition.CenterScreen;
            if (nuevaZapatilla.ShowDialog() == DialogResult.OK)
            {
                this.calzado = nuevaZapatilla.Zapatilla;
                this.seCreo = true;
            }
        }
        /// <summary>
        /// si un calzado se creo, el dialog result sera ok, de lo contratio, pedira que se ingrese
        /// un producto o se cancele la operacion
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BotonAceptar_Click(object sender, EventArgs e)
        {
             if(this.seCreo == true)
             {
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
             }
            else
            {
                MessageBox.Show("No se ha añadido ningun producto. En caso de no querer agregar ningun elemento al inventario, cancele esta operacion");
            }
        }
        /// <summary>
        /// establece el dialog result como Cancel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BotonCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }
        #endregion
    }
}
