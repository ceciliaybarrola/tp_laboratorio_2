using Excepciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClasesAbstractas
{
    public abstract class Universitario : Persona
    {
        private int legajo;

        public Universitario()
        {

        }
        public Universitario(int legajo, string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : base (nombre, apellido, dni, nacionalidad)
        {
            this.legajo = legajo;
        }
        
        protected virtual string MostrarDatos()
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendLine(base.ToString());//chequear
            stringBuilder.AppendFormat("LEGAJO NUMERO: {0}\n", this.legajo);

            return stringBuilder.ToString();
        }
        protected abstract string ParticiparEnClase();

        public static bool operator ==(Universitario pg1, Universitario pg2)
        {
            bool retorno = false;

            if(pg1.GetType() == pg2.GetType() &&   ( pg1.legajo == pg2.legajo || pg1.DNI == pg2.DNI))
            {
                retorno = true;
            }
            
            return retorno;
        }
        public static bool operator !=(Universitario pg1, Universitario pg2)
        {
            return !(pg1==pg2);
        }

        public override bool Equals(object obj)
        {
            bool retorno = false;

            if (obj is Universitario)
            {
                retorno = this == (Universitario)obj;
            }

            return retorno;
        }


    }
}
