using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class CantidadInvalidaException : Exception
    {
        /// <summary>
        /// error que se produce cuando una cantidad es menor a cero
        /// </summary>
        public CantidadInvalidaException()
            : base("ERROR! La cantidad es invalida")
        {
        }



    }
}
