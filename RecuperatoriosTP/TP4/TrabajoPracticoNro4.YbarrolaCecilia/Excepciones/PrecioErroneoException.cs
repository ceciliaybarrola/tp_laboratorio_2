using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class PrecioErroneoException: Exception
    {
        /// <summary>
        /// error que se produce cuando un precio es menor a $1000
        /// </summary>
        public PrecioErroneoException()
            :base("ERROR! Precio invalido ")
        {
        }
    }
}
