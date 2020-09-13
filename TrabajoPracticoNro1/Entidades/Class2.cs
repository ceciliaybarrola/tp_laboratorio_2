using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class Calculadora
    {
        /// <summary>
        /// Validara y realizara la operacion pedida entre ambos numeros
        /// </summary>
        /// <param name="num1"></param>
        /// <param name="num2"></param>
        /// <param name="operador"></param>
        /// <returns></returns>
        public static double Operar(Numero num1, Numero num2, string operador)
        {
            double resultado = 0;
            string result;
            operador = Calculadora.ValidarOperador(Convert.ToChar(operador));

            /*  resultado = num1 + num2;

              Console.WriteLine(" Resultado + :"+ resultado);
              resultado = num1 - num2;
              Console.WriteLine(" Resultado - :" + resultado);
              resultado = num1 * num2;
              Console.WriteLine(" Resultado * :" + resultado);
              resultado = num1 / num2;
              Console.WriteLine(" Resultado / :" + resultado);
            */
            resultado = double.Parse(num1.DecimalBinario(31));
            Console.WriteLine(" DecimalBinario :" + resultado);
            resultado = double.Parse(num1.DecimalBinario("29"));
            Console.WriteLine(" DecimalBinario :" + resultado);

            result = num1.BinarioDecimal("1101001"); //1001011
            //resultado = double.Parse(num1.BinarioDecimal("1101001"));
            Console.WriteLine(" BinarioDecimal :" + result);
            return resultado;
        }

        /// <summary>
        /// Valida que el operador sea +,-,/ o *.
        /// </summary>
        /// <param name="operador"></param>
        /// <returns></returns> Retornara el operador correspondiente o + si no es valido
        private static string ValidarOperador(char operador)
        {
            string operadorValidado = "+";

            if (operador == '*' || operador == '/' || operador == '-')
            {
                operadorValidado = operador.ToString();
            }
            return operadorValidado;
        }



    }
}
