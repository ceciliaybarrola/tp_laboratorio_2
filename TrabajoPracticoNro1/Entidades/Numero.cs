using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Numero
    {   
        private double numero;

        public string SetNumero
        {           
            set { this.numero = this.ValidarNumero(value) ; }
        }

        /// <summary>
        /// Validara que se trate de un binario y luego canvertira a ese numero a decimal
        /// </summary>
        /// <param name="binario"></param>
        /// <returns></returns> si no es binario retornara: "valor invalido" y si lo es retornara el numero
        public string BinarioDecimal(string binario)
        {
            string retornoBinario="Valor invalido";

            if(this.EsBinario(binario))
            {
                retornoBinario = Convert.ToUInt64(binario, 2).ToString(); 
            }

            return retornoBinario;
        }

        /// <summary>
        /// Convierte decimal a binario.
        /// Trabajaran con enteros positivos, quedandose con el valor absoluto y entero del double recibido 
        /// </summary>
        /// <param name="binario"></param>
        /// <returns></returns>
        public string DecimalBinario(string numero)
        {
            string retorno = "Valor invalido";
            
            if(double.TryParse(numero, out this.numero))
            {
                retorno=this.DecimalBinario(this.numero);
            }
            return retorno;
        }

        /// <summary>
        /// Convierte decimal a binario.
        /// Trabajaran con enteros positivos, quedandose con el valor absoluto y entero del double recibido 
        /// </summary>
        /// <param name="numero"></param>
        /// <returns></returns>
        public string DecimalBinario(double numero)
        {
            string retornoBinario = "";
            UInt64 numeroNatural;

            numeroNatural = (UInt64)Math.Abs(numero);

            while(numeroNatural >0)// no entro con el numero negativo
            {

                if(numeroNatural % 2==0)
                {
                    retornoBinario = "0" + retornoBinario;
                }
                else
                {
                    retornoBinario = "1" + retornoBinario;
                }
                numeroNatural = numeroNatural / 2;
            }

            return retornoBinario;
        }
        private bool EsBinario(string binario)
        {
            bool esBinario = true;

            for(int i=0; i< binario.Length; i++)
            {
                if(binario[i] != '0' && binario[i] != '1')
                {
                    esBinario = false;
                    break;
                }
            }
            return esBinario;
        }

        #region constructores
        public Numero()
        {
            this.numero = 0;
        }

        public Numero(double numero)
        {
            this.numero = numero;
        }

        public Numero(string strNumero)
        {
            this.SetNumero = strNumero;
        }
        #endregion

        #region operadores
        public static double operator -(Numero n1, Numero n2)
        {
            return n1.numero - n2.numero;
        }
        public static double operator +(Numero n1, Numero n2)
        {
            return n1.numero + n2.numero; ;
        }
        public static double operator *(Numero n1, Numero n2)
        {
            return n1.numero * n2.numero;
        }
        public static double operator /(Numero n1, Numero n2)
        {
            double resultadoDivision = double.MinValue;
            if(n2.numero != 0) //aca puedo hacer otro operador 
            {
                resultadoDivision = n1.numero / n2.numero;
            }
            return resultadoDivision;
        }
        #endregion

        /// <summary>
        /// Comprueba que el valor recibido  sea numerico
        /// </summary>
        /// <param name="strNumero"></param>
        /// <returns></returns> En caso que sea numerico retornara el double, de lo contrario retornara 0
        private double ValidarNumero(string strNumero)
        {
            double numero=0;
            double.TryParse(strNumero, out numero);
            return numero;
        }

    }
}
