using Archivos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ClasesInstanciables
{
    public class Jornada
    {
        private List<Alumno> alumnos;
        private Universidad.EClases clase;
        private Profesor instructor;

        public List<Alumno> Alumnos
        {
            get
            {
                return this.alumnos;
            }
            set
            {
                this.alumnos = value;
            }
        }
        public Universidad.EClases Clase
        {
            get
            {
                return this.clase;
            }
            set
            {
                this.clase = value;
            }
        }
        public Profesor Instructor
        {
            get
            {
                return this.instructor;
            }
            set
            {
                this.instructor = value;
            }
        }
        private Jornada()
        {
            this.alumnos = new List<Alumno>();

        }
        public Jornada(Universidad.EClases clase, Profesor instructor)
            :this()
        {
            this.clase = clase;
            this.instructor = instructor;
        }
        public static string Leer()
        {
            Texto archivoTexto = new Texto();
            string ruta = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\JornadaPrueba.txt";
            string datosArchivo;

            archivoTexto.Leer(ruta, out datosArchivo);

            return datosArchivo;
        }
        public static bool Guardar(Jornada jornada)
        {
            Texto archivoTexto = new Texto();
            string ruta = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\JornadaPrueba.txt";

            return archivoTexto.Guardar(ruta, jornada.ToString());
        }
     
        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendLine("CLASE: " + this.clase);
            stringBuilder.AppendFormat("INSTRUCTOR: " + this.instructor);

            foreach(Alumno item in this.alumnos)
            {
                stringBuilder.AppendLine(item.ToString());
            }

            return stringBuilder.ToString();
        }
        public static bool operator ==(Jornada j, Alumno a)
        {
             bool retorno = false;

             foreach(Alumno item in j.alumnos)
             {
                 if(!(a != item))
                 {
                     retorno = true;
                     break;
                 }
             }          
             return retorno;

        }
        public static bool operator !=(Jornada j, Alumno a)
        {
            return !(j == a);
        }
        public static Jornada operator +(Jornada j, Alumno a)
        {
            if (j != a)
            {
                j.alumnos.Add(a);
            }
            return j;
        }




    }
}
