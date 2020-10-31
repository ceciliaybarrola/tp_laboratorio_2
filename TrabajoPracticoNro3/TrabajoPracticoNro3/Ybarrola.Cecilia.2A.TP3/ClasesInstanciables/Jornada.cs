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
            get { return this.alumnos; }
            set { this.alumnos = value; }
        }
        public Universidad.EClases Clase
        {
            get { return this.clase; }
            set {  this.clase = value; }
        }
        public Profesor Instructor
        {
            get { return this.instructor; }
            set { this.instructor = value; }
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
        /// <summary>
        /// Leer de clase retornará los datos de la Jornada como texto.
        /// </summary>
        /// <returns></returns>
        public static string Leer()
        {
            Texto archivoTexto = new Texto();
            string ruta = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\JornadaPrueba.txt";
            string datosArchivo;

            archivoTexto.Leer(ruta, out datosArchivo);

            return datosArchivo;
        }
        /// <summary>
        /// Guardar de clase guardará los datos de la Jornada en un archivo de texto.
        /// </summary>
        /// <param name="jornada"></param>
        /// <returns></returns>
        public static bool Guardar(Jornada jornada)
        {
            Texto archivoTexto = new Texto();
            string ruta = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\JornadaPrueba.txt";

            return archivoTexto.Guardar(ruta, jornada.ToString());
        }
        /// <summary>
        /// ToString mostrará todos los datos de la Jornada.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendLine("CLASE: " + this.clase);
            stringBuilder.AppendFormat("INSTRUCTOR: " + this.instructor.ToString());

            foreach(Alumno item in this.alumnos)
            {
                stringBuilder.AppendLine(item.ToString());
            }

            return stringBuilder.ToString();
        }
        /// <summary>
        /// Una Jornada será igual a un Alumno si el mismo participa de la clase.
        /// </summary>
        /// <param name="j"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static bool operator ==(Jornada j, Alumno a)
        {
             bool retorno = false;

             foreach(Alumno item in j.alumnos)
             {
                 if((a == item))
                 {
                     retorno = true;
                     break;
                 }
             }          
             return retorno;

        }
        /// <summary>
        /// Una Jornada será distinto a un Alumno si el mismo no participa de la clase.
        /// </summary>
        /// <param name="j"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static bool operator !=(Jornada j, Alumno a)
        {
            return !(j == a);
        }
        /// <summary>
        /// Agregar Alumnos a la clase por medio del operador +, validando que no estén previamente
        /// cargados.
        /// </summary>
        /// <param name="j"></param>
        /// <param name="a"></param>
        /// <returns></returns>
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
