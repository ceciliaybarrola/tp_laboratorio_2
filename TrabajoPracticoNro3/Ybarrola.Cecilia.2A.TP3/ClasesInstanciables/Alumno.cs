using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using ClasesAbstractas;


namespace ClasesInstanciables
{
    sealed public class Alumno : Universitario
    {
        private Universidad.EClases claseQueToma;
        private EEstadoCuenta estadoCuenta;

        public Alumno()
        {

        }
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQueToma)// chequear el estado cuenta por default
            : this(id, nombre, apellido, dni, nacionalidad, claseQueToma, EEstadoCuenta.AlDia)
        {

        }
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQueToma, EEstadoCuenta estadoCuenta)
            : base(id, nombre, apellido, dni, nacionalidad)
        {
            this.claseQueToma = claseQueToma;
            this.estadoCuenta = estadoCuenta;
        }
        protected override string MostrarDatos()
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendLine(base.MostrarDatos());
            stringBuilder.AppendFormat("ESTADO CUENTA: {0}\n", this.estadoCuenta);
            stringBuilder.AppendFormat(this.ParticiparEnClase());

            return stringBuilder.ToString();
        }
        protected override string ParticiparEnClase()
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendFormat("TOMA CLASE DE {0}\n", this.claseQueToma);

            return stringBuilder.ToString();


        }
        public static bool operator ==(Alumno a, Universidad.EClases clase)
        {
            bool retorno = false;
            if (a.claseQueToma == clase && a.estadoCuenta != EEstadoCuenta.Deudor)
            {
                retorno = true;
            }
             
            return retorno;
        }
        public static bool operator !=(Alumno a, Universidad.EClases clase)
        {
            return  a.claseQueToma != clase ;
        }
        public override string ToString()
        {
            return this.MostrarDatos();
        }
        public enum EEstadoCuenta
        {
            AlDia,
            Deudor,
            Becado
        }



    }
}
