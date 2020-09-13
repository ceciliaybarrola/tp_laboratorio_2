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

        /// <summary>
        /// Evento click del boton operar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOperar_Click(object sender, EventArgs e)
        {
            double respuesta = FormCalculadora.Operar(this.txtNumero1.Text, this.txtNumero2.Text, this.cmbOperador.Text);
            this.lblResultado.Text = respuesta.ToString();
        }

        /// <summary>
        /// Metodo que crea los objetos de la clase numero y llama al metodo operar de calculadora
        /// </summary>
        /// <param name="numero1"></param>
        /// <param name="numero2"></param>
        /// <param name="operador"></param>
        /// <returns></returns>
        private static double Operar(string numero1, string numero2, string operador)
        {
            Numero n1 = new Numero(numero1);
            Numero n2 = new Numero(numero2);
            
            return Calculadora.Operar(n1, n2, operador);
        }

        /// <summary>
        /// Evento click del boton limpiar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            limpiar();
        }

        /// <summary>
        /// Evento click del boton convertir a binario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConvertirABinario_Click(object sender, EventArgs e)
        {
            Numero n1 = new Numero();
            this.lblResultado.Text = n1.DecimalBinario(this.lblResultado.Text);
        }

        /// <summary>
        /// Evento click del boton convertir a decimal
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConvertirADecimal_Click(object sender, EventArgs e)
        {
            Numero n1 = new Numero();
            this.lblResultado.Text = n1.BinarioDecimal(this.lblResultado.Text);
        }

        /// <summary>
        /// Limpia la calculadora poniendotodos los elementos vacios
        /// </summary>
        private void limpiar()
        {
            this.txtNumero1.Text = "";
            this.txtNumero2.Text = "";
            this.lblResultado.Text = "";
            this.cmbOperador.Text = "";
        }

        /// <summary>
        /// Evento click del boton cerrar, cierra el programa
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
