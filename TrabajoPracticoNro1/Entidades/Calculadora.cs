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
            char chrOperando = ' ';

            char.TryParse(operador, out chrOperando);

            operador = Calculadora.ValidarOperador(chrOperando);      

            switch(operador)
            {
                case "+":
                    resultado = num1 + num2;
                    break;
                case "-":
                    resultado = num1 - num2;
                    break;
                case "*":
                    resultado = num1 * num2;
                    break;
                case "/":
                    resultado = num1 / num2;
                    break;
            }
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
