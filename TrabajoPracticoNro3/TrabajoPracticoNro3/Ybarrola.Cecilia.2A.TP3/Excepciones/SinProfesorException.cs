using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class SinProfesorException : Exception
    {
        /// <summary>
        /// Constructor por defecto de la excepcion
        /// </summary>
        public SinProfesorException()
            : this("No hay profesor para la clase.")
        {
        }
        /// <summary>
        /// ATENCION!! constructor requerido segun las consignas del pdf del trabajo practico
        /// </summary>
        /// <param name="message"></param>
        public SinProfesorException(string message)
            : base(message)
        {
        }

    }
}
