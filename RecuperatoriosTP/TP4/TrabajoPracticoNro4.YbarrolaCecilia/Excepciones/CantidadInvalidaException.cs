using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class CantidadInvalidaException : Exception
    {
        public CantidadInvalidaException()
            : base("ERROR! La cantidad es invalida")
        {
        }



    }
}
