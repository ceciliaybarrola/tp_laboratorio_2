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
        private List<Alumno> alumnos;
        private List<Jornada> jornada;
        private List<Profesor> profesor;
        /// <summary>
        /// propiedad de lectura y escritura del atributo alumnos
        /// </summary>
        public List<Alumno> Alumnos
        {
            get { return this.alumnos; }
            set { this.alumnos = value; }
        }
        /// <summary>
        /// propiedad de lectura y escritura del atributo jornada
        /// </summary>
        public List<Jornada> Jornadas
        {
            get { return this.jornada; }
            set { this.jornada = value; }
        }
        /// <summary>
        /// propiedad de lectura y escritura del atributo profesor
        /// </summary>
        public List<Profesor> Instructores
        {
            get { return this.profesor; }
            set { this.profesor = value; }
        }
        /// <summary>
        /// Se accederá a una Jornada específica a través de un indexador.
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
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
        /// <summary>
        /// constructor por defecto 
        /// </summary>
        public Universidad()
        {
            this.profesor = new List<Profesor>();
            this.jornada = new List<Jornada>();
            this.alumnos = new List<Alumno>();
        }
        /// <summary>
        /// Serializara los datos de la universidad en un archivo xml
        /// </summary>
        /// <param name="uni"></param>
        /// <returns></returns>
        public static bool Guardar(Universidad uni)
        {
            Xml<Universidad> xml = new Xml<Universidad>();
            return xml.Guardar("Universidad.xml", uni);

        }
        /// <summary>
        /// Deserializará un archivo xml y convertira los datos en una universidad
        /// </summary>
        /// <returns></returns>
        public static Universidad Leer()
        {
            Universidad universidad = new Universidad();
            Xml<Universidad> xml = new Xml<Universidad>();            
            try
            {
                xml.Leer("Universidad.xml", out universidad);
            }
            catch(ArchivosException e)
            {
                Console.WriteLine(e.Message);
            }
            
            return universidad;
        }
        /// <summary>
        /// Mostrara todos los datos de la universidad
        /// </summary>
        /// <param name="uni"></param>
        /// <returns></returns>
        private static string MostrarDatos(Universidad uni)
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendLine("JORNADA");

            for (int i=0; i < uni.jornada.Count; i++)
            {
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
                if(a.Equals(item))
                {
                    retorno = true;
                    break;
                }
            }
            return retorno;

        }
        /// <summary>
        /// Un Universidad será distinto a un Alumno si el mismo no está inscripto en él.
        /// </summary>
        /// <param name="g"></param>
        /// <param name="a"></param>
        /// <returns></returns>
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
        /// <summary>
        /// Un Universidad será distinto a un Profesor si el mismo no está dando clases en él.
        /// </summary>
        /// <param name="g"></param>
        /// <param name="i"></param>
        /// <returns></returns>
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
        /// <summary>
        /// Agregara un alumno si este no pertenece a la universidad,sino tirara alumnoRepetidoException
        /// </summary>
        /// <param name="u"></param>
        /// <param name="a"></param>
        /// <returns></returns>
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
        /// <summary>
        /// Se agregara un profesor si el mismo no esta en la universidad
        /// </summary>
        /// <param name="u"></param>
        /// <param name="i"></param>
        /// <returns></returns>
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
            g[i] = new Jornada(clase, g == clase);

            foreach (Alumno item in g.alumnos)
            {
                g[i] += item;
            }

            return g;
        }
        /// <summary>
        /// Hará publico los datos de la universidad
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return Universidad.MostrarDatos(this);
        }
        /// <summary>
        /// enumerado clases
        /// </summary>
        public enum EClases
        {
            Programacion,
            Laboratorio,
            Legislacion,
            SPD
        }
    }
}
