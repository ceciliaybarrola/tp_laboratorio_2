using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace MiCalculadora
{
    public partial class FormCalculadora : Form
    {
        public FormCalculadora()
        {
            InitializeComponent();
            
        }

        private void btnOperar_Click(object sender, EventArgs e)
        {
            double respuesta = FormCalculadora.Operar(this.txtNumero1.Text, this.txtNumero2.Text, this.cmbOperador.Text);
            this.lblResultado.Text = respuesta.ToString();
        }
        private static double Operar(string numero1, string numero2, string operador)
        {
            Numero n1 = new Numero(numero1);
            Numero n2 = new Numero(numero2);
            
            return Calculadora.Operar(n1, n2, operador);
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            limpiar();
        }
        private void btnConvertirABinario_Click(object sender, EventArgs e)
        {
            Numero n1 = new Numero();
            this.lblResultado.Text = n1.DecimalBinario(this.lblResultado.Text);
        }
        private void btnConvertirADecimal_Click(object sender, EventArgs e)
        {
            Numero n1 = new Numero();
            this.lblResultado.Text = n1.BinarioDecimal(this.lblResultado.Text);

        }
        private void limpiar()
        {
            this.txtNumero1.Text = "";
            this.txtNumero2.Text = "";
            this.lblResultado.Text = "";
            this.cmbOperador.Text = "";
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
