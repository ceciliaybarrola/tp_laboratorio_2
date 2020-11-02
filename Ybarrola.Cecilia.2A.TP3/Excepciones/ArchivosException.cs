using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class ArchivosException : Exception
    {
        /// <summary>
        /// Constructor correspondiente al diagrama de clase, donde se recibe una excepcion como parametro
        /// </summary>
        /// <param name="innerException"></param>
        public ArchivosException(Exception innerException)
            : this("Se produjo un error en la lectura/escritura del archivo: "+innerException.Message)
        {
        }
        /// <summary>
        /// ATENCION!! constructor requerido segun las consignas del pdf del trabajo practico
        /// </summary>
        /// <param name="message"></param>
        public ArchivosException(string message)
            : base(message)
        {
        }
        /// <summary>
        /// ATENCION!! constructor requerido segun las consignas del pdf del trabajo practico
        /// </summary>
        /// <param name="message"></param>
        public ArchivosException()
            : this("Se produjo un error en la lectura/escritura del archivo")
        {
        }
    }
}
