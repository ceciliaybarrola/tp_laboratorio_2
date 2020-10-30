using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Excepciones;
using Archivos;

namespace ClasesInstanciables
{
    public class Universidad
    {
        public enum EClases
        {
            Programacion,
            Laboratorio,
            Legislacion,
            SPD
        }
        private List<Alumno> alumnos;
        private List<Jornada> jornada;
        private List<Profesor> profesor;

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
        public List<Jornada> Jornadas
        {
            get
            {
                return this.jornada;
            }
            set
            {
                this.jornada = value;
            }
        }
        public List<Profesor> Instructores
        {
            get
            {
                return this.profesor;
            }
            set
            {
                this.profesor = value;
            }
        }
        public Jornada this[int i]
        {
            get
            {
                if (i >= this.jornada.Count || i < 0)
                {
                    return null;
                }
                else
                {
                    return this.jornada[i];
                }
            }
            set
            {
                if (i >= 0 && i < this.jornada.Count)
                {
                    this.jornada[i] = value;
                }
                else if (i == this.jornada.Count)
                {
                    this.jornada.Add(value);
                }
            }
        }
        public Universidad()
        {
            this.profesor = new List<Profesor>();
            this.jornada = new List<Jornada>();
            this.alumnos = new List<Alumno>();
        }
        public static bool Guardar(Universidad uni)
        {
            Xml<Universidad> xml = new Xml<Universidad>();
            string ruta = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\UniversidadPrueba.xml";
            return xml.Guardar(ruta, uni);

        }
        public static Universidad Leer()
        {
            Universidad universidad = new Universidad();
            Xml<Universidad> xml = new Xml<Universidad>();
            string ruta = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\UniversidadPrueba.xml";
            
            try
            {
                xml.Leer(ruta, out universidad);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            
            return universidad;
        }
        private static string MostrarDatos(Universidad uni)
        {
            StringBuilder stringBuilder = new StringBuilder();

            for (int i=0; i < uni.jornada.Count; i++)
            {
                stringBuilder.AppendLine("JORNADA");
                stringBuilder.AppendFormat("CLASE DE {0} POR {1}\n\n", (uni.jornada[i]).Clase, ((uni.jornada[i]).Instructor).ToString());
                stringBuilder.AppendLine("ALUMNOS");
                foreach (Alumno item in (uni.jornada[i]).Alumnos)
                {
                    stringBuilder.AppendLine(item.ToString());
                    
                }
                stringBuilder.AppendLine("<------------------------------------------------------>");
            }

            return stringBuilder.ToString();
        }
        /// <summary>
        /// Un Universidad será igual a un Alumno si el mismo está inscripto en él.
        /// </summary>
        /// <param name="g"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static bool operator ==(Universidad g, Alumno a)
        {
            bool retorno = false;
            foreach (Alumno item in g.alumnos)
            {
                if(item == a)
                {
                    retorno = true;
                }
            }
            return retorno;

        }
        public static bool operator !=(Universidad g, Alumno a)
        {
            return !(g == a);
        }
        /// <summary>
        /// Un Universidad será igual a un Profesor si el mismo está dando clases en él.
        /// </summary>
        /// <param name="g"></param>
        /// <param name="i"></param>
        /// <returns></returns>
        public static bool operator ==(Universidad g, Profesor i)
        {
            bool retorno = false;
            foreach (Profesor item in g.profesor)
            {
                if (item == i)
                {
                    retorno = true;
                }
            }
            return retorno;
        }
        public static bool operator !=(Universidad g, Profesor i)
        {
            return !(g == i);
        }
        /// <summary>
        /// La igualación entre un Universidad y una Clase retornará el primer Profesor capaz de dar esa clase.
        /// Sino, lanzará la Excepción SinProfesorException.
        /// </summary>
        /// <param name="u"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static Profesor operator ==(Universidad u, EClases clase)
        {
            foreach (Profesor item in u.profesor)
            {
                if(item == clase)
                {
                    return item;
                }
            }
            throw new SinProfesorException();
        }
        /// <summary>
        /// El distinto retornará el primer Profesor que no pueda dar la clase.
        /// </summary>
        /// <param name="u"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static Profesor operator !=(Universidad u, EClases clase)
        {
            Profesor profesor = new Profesor();
            foreach (Profesor item in u.profesor)
            {
                if (item != clase)
                {
                    profesor = item;
                    break;
                }
            }

            return profesor;
        }
        public static Universidad operator +(Universidad u, Alumno a)
        {
            if(u != a)
            {
                u.alumnos.Add(a);
            }
            else
            {
                throw new AlumnoRepetidoException();
            }
            return u;
        }
        public static Universidad operator +(Universidad u, Profesor i)
        {
            if (u != i)
            {
                u.profesor.Add(i);
            }

            return u;
        }
        /// <summary>
        /// Al agregar una clase a un Universidad se deberá generar y agregar una nueva Jornada indicando la
        /// clase, un Profesor que pueda darla(según su atributo ClasesDelDia) y la lista de alumnos que la
        /// toman(todos los que coincidan en su campo ClaseQueToma).
        /// </summary>
        /// <param name="g"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static Universidad operator +(Universidad g, EClases clase)
        {
            int i = g.jornada.Count;
            List<Alumno> listaAlumnos = new List<Alumno>();
            Profesor profesor;

            foreach (Alumno item in g.alumnos)
            {
                if(item == clase)
                {
                    listaAlumnos.Add(item);
                }
            }

            profesor = g == clase;


            g[i] = new Jornada(clase, profesor);
            (g.jornada[i]).Alumnos = listaAlumnos;

            return g;
        }

        public override string ToString()
        {
            return Universidad.MostrarDatos(this);
        }






    }
}
