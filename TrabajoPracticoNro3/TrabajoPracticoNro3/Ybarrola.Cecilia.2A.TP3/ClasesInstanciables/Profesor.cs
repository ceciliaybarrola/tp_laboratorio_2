using ClasesAbstractas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ClasesInstanciables
{
    public sealed class Profesor : Universitario
    {

        private Queue<Universidad.EClases> clasesDelDia;
        private static Random random;
        public Profesor()           
        {
        }
        static Profesor()
        {
            Profesor.random = new Random();           
        }
        public Profesor(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            :base(id, nombre, apellido, dni, nacionalidad)
        {
            this.clasesDelDia = new Queue<Universidad.EClases>();
            this._randomClases();
        }
        /// <summary>
        /// se asignarán dos clases al azar al Profesor mediante el método randomClases.
        /// </summary>
        private void _randomClases()
        {
            for(int i=0; i<2; i++)
            {
                this.clasesDelDia.Enqueue((Universidad.EClases)Profesor.random.Next(0, Enum.GetValues(typeof(Universidad.EClases)).GetLength(0)));
            }
        }
        /// <summary>
        /// Sobrescribir el método MostrarDatos con todos los datos del profesor.
        /// </summary>
        /// <returns></returns>
        protected override string MostrarDatos()
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendLine(base.MostrarDatos());
            stringBuilder.AppendFormat(this.ParticiparEnClase());

            return stringBuilder.ToString();
        }
        /// <summary>
        /// ParticiparEnClase retornará la cadena "CLASES DEL DÍA" junto al nombre de la clases que da.
        /// </summary>
        /// <returns></returns>
        protected override string ParticiparEnClase()
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendLine("CLASES DEL DIA");
            foreach (Universidad.EClases item in this.clasesDelDia)
            {
                stringBuilder.AppendLine(item.ToString());
            }

            return stringBuilder.ToString();
        }

        /// <summary>
        /// ToString hará públicos los datos del Profesor.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.MostrarDatos();
        }
        /// <summary>
        /// Un Profesor será igual a un EClase si da esa clase.
        /// </summary>
        /// <param name="i"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static bool operator ==(Profesor i, Universidad.EClases clase)
        {
            return i.clasesDelDia.Contains(clase);
        }
        /// <summary>
        /// Un Profesor será distinto a un EClase si da no esa clase.
        /// </summary>
        /// <param name="i"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static bool operator !=(Profesor i, Universidad.EClases clase)
        {
            return !(i == clase);
        }

    }
}
