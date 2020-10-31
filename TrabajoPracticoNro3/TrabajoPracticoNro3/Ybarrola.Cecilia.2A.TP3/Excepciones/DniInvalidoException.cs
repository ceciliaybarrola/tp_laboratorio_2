using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class DniInvalidoException : Exception
    {
        /// <summary>
        /// constructor con mensaje por defecto
        /// </summary>
        public DniInvalidoException()
            : this ("DNI invalido ")
        {
        }
        /// <summary>
        /// constructor que recibe una excepcion como parametro
        /// </summary>
        /// <param name="e"></param>
        public DniInvalidoException(Exception e)
            : this ("DNI invalido ", e)
        {
        }
        /// <summary>
        /// constructor que recibe un mensaje
        /// </summary>
        /// <param name="message"></param>
        public DniInvalidoException(string message)
            : base(message)
        {
        }
        /// <summary>
        /// constructor que recibe un mensaje y un objeto de tipo Exception
        /// </summary>
        /// <param name="message"></param>
        /// <param name="e"></param>
        public DniInvalidoException(string message, Exception e)
            : base (message, e)
        {
        }


    }
}
