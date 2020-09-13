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

        public double SetNumero
        {
            set { numero = this.ValidarNumero(value.ToString()); }
        }

        /// <summary>
        /// Validara que se trate de un binario y luego canvertira a ese numero a decimal
        /// </summary>
        /// <param name="binario"></param>
        /// <returns></returns> si no es binario retornara: "valor invalido" y si lo es retornara el numero
        public string BinarioDecimal(string binario)
        {
            string retornoBinario = "Valor invalido";
            int suma = 0;
            int j;
            if (this.EsBinario(binario))
            {
                j = 0;
                for (int i = binario.Length - 1; i >= 0; i--)
                {

                    if (binario[i] == '1')//me lee la cadena al reves
                    {
                        suma += (int)Math.Pow(2, j);
                    }
                    j++;
                }
                retornoBinario = suma.ToString();
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
            return this.DecimalBinario(double.Parse(numero));
        }

        /// <summary>
        /// Convierte decimal a binario.
        /// Trabajaran con enteros positivos, quedandose con el valor absoluto y entero del double recibido 
        /// </summary>
        /// <param name="numero"></param>
        /// <returns></returns>
        public string DecimalBinario(double numero)
        {
            string retornoBinario = "";//solucionar el tema del retorno
            int numeroNatural;

            if (numero > 0)
            {
                numeroNatural = (int)Math.Abs(numero);
            }
            else
            {
                numeroNatural = (int)(-1 * Math.Abs(numero));
            }

            while (numeroNatural >= 2)
            {
                numeroNatural = numeroNatural / 2;

                if (numeroNatural % 2 == 0)
                {
                    retornoBinario = retornoBinario + "0";
                }
                else
                {
                    retornoBinario = retornoBinario + "1";
                }
            }
            return retornoBinario;
        }
        private bool EsBinario(string binario)
        {
            bool esBinario = true;

            for (int i = 0; i < binario.Length; i++)
            {
                if (binario[i] != '0' && binario[i] != '1')
                //if (binario.Substring(1, i)!="0" && binario.Substring(1, i) != "1")
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
            this.numero = double.Parse(strNumero);
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
            if (n2.numero != 0) //aca puedo hacer otro operador 
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
            double numero = 0;
            double.TryParse(strNumero, out numero);
            return numero;
        }

    }
}
