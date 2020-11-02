using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class AlumnoRepetidoException : Exception
    {
        /// <summary>
        /// constructor por defecto de esta excepcion
        /// </summary>
        public AlumnoRepetidoException()
            : this("Alumnno repetido.")
        {
        }
        /// <summary>
        /// constructor que recibe uun string como parametro
        /// </summary>
        /// <param name="message"></param>
        public AlumnoRepetidoException(string message)
            : base(message)
        {
        }
    }
}
