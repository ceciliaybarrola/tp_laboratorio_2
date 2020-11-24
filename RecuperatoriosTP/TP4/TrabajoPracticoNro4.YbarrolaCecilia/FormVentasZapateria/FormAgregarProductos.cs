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
    public partial class FormAgregarProductos : Form
    {
        protected Zapatilla zapatilla;
        protected Zapato zapato;
        protected Calzado calzado;
        private bool seCreo;

        public Zapatilla Zapatilla
        {
            get { return this.zapatilla; }

        }
        public Zapato Zapato
        {
            get { return this.zapato; }

        }
        public Calzado Calzado
        {
            get { return this.zapato; }

        }

        public FormAgregarProductos()
        {
            InitializeComponent();
        }

        private void BotonAgregarZapato_Click(object sender, EventArgs e)
        {
            FormCrearZapato nuevoZapato = new FormCrearZapato();
            nuevoZapato.StartPosition = FormStartPosition.CenterScreen;
            if (nuevoZapato.ShowDialog() == DialogResult.OK)
            {
                this.zapato = new Zapato();
                this.zapato = nuevoZapato.Zapato;
                this.seCreo = true;
            }
        }

        private void BotonAgregarZapatilla_Click(object sender, EventArgs e)
        {
            FormCrearZapatilla nuevaZapatilla = new FormCrearZapatilla();
            nuevaZapatilla.StartPosition = FormStartPosition.CenterScreen;
            if (nuevaZapatilla.ShowDialog() == DialogResult.OK)
            {
                this.zapatilla = new Zapatilla();
                this.zapatilla = nuevaZapatilla.Zapatilla;
                this.seCreo = true;
            }
        }

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

        private void BotonCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }
    }
}
