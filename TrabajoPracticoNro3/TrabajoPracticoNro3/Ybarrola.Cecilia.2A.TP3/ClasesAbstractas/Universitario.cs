using Excepciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Xml;


namespace ClasesAbstractas
{
    public abstract class Universitario : Persona
    {
        private int legajo;

        public Universitario()
            :base()
        {
        }
        public Universitario(int legajo, string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : base (nombre, apellido, dni, nacionalidad)
        {
            this.legajo = legajo;
        }

        /// <summary>
        /// Método protegido y virtual MostrarDatos retornará todos los datos del Universitario.
        /// </summary>
        /// <returns></returns>
        protected virtual string MostrarDatos()
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendLine(base.ToString());
            stringBuilder.AppendFormat("LEGAJO NUMERO: {0}\n", this.legajo);

            return stringBuilder.ToString();
        }
        /// <summary>
        /// Método protegido y abstracto ParticiparEnClase.
        /// </summary>
        /// <returns></returns>
        protected abstract string ParticiparEnClase();

        /// <summary>
        /// Dos Universitario serán iguales si y sólo si son del mismo Tipo y su Legajo o DNI son iguales.
        /// Chequeo si son nulos para evitar un error al pasar un objeto null durante algun testeo
        /// </summary>
        /// <param name="pg1"></param>
        /// <param name="pg2"></param>
        /// <returns></returns>
        public static bool operator ==(Universitario pg1, Universitario pg2)
        {
            bool retorno = false;
            if((object)pg1 != null && (object)pg2!= null)
            {
                if(pg1.GetType() == pg2.GetType() &&   ( pg1.legajo == pg2.legajo || pg1.DNI == pg2.DNI))
                {
                    retorno = true;
                }
            }
            
            return retorno;
        }
        /// <summary>
        /// Dos Universitario serán distintos si y sólo si son no del mismo Tipo o si su Legajo o DNI no son iguales.
        /// </summary>
        /// <param name="pg1"></param>
        /// <param name="pg2"></param>
        /// <returns></returns>
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
