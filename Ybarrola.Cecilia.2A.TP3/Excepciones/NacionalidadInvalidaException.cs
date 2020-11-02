using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class NacionalidadInvalidaException : Exception
    {
        /// <summary>
        /// constructor por defecto para la excepcion
        /// </summary>
        public NacionalidadInvalidaException()
            : this("La nacionalidad no se condice con el número de DNI")
        {
        }
        /// <summary>
        /// constructor que recibe un string para esta excepcion
        /// </summary>
        /// <param name="message"></param>
        public NacionalidadInvalidaException(string message)
            : base(message)
        {
        }



    }
}
