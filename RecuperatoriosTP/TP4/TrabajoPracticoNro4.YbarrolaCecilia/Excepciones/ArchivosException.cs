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
        /// USA EXCEPCIONES
        /// Excepcion producida al haber algun tipo de error en la lectura y o 
        /// escritura de un archivo
        /// </summary>
        /// <param name="innerException"></param>
        public ArchivosException(Exception innerException)
            : base("Se produjo un error en la lectura/escritura del archivo: " + innerException.InnerException)
        {
        }
    }
}
