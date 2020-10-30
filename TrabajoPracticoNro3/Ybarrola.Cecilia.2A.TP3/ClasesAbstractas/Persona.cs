using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;

namespace ClasesAbstractas
{
    public abstract class Persona
    {
        private string apellido;
        private ENacionalidad nacionalidad;
        private int dni;
        private string nombre;

        #region Propiedades
        public string Apellido
        {
            get 
            {
                return this.apellido;
            }
            set 
            {
                this.apellido = this.ValidarNombreApellido(value);
            }
        }
        public string Nombre
        {
            get
            {
                return this.nombre;
            }
            set
            {
                this.nombre = this.ValidarNombreApellido(value);
            }
        }
        public int DNI
        {
            get
            {
                return this.dni;
            }
            set
            {
                this.dni = this.ValidarDni(this.nacionalidad, value);
            }
        }

        public ENacionalidad Nacionalidad
        {
            get
            {
                return this.nacionalidad;
            }
            set
            {
                this.nacionalidad = value;
            }
        }
        /// <summary>
        /// Si el DNI presenta un error de formato (más caracteres de los permitidos, letras, etc.) se lanzará DniInvalidoException.
        /// </summary>
        public string StringToDNI
        {
            set
            {
                int DNI;
                if(value.Length <= 8 && int.TryParse(value, out DNI))
                {
                    this.DNI = DNI;
                }
                else
                {
                    throw new DniInvalidoException();
                }

            }
        }
        #endregion

        #region Constructores
        public Persona()
        {

        }
        public Persona(string nombre, string apellido, ENacionalidad nacionalidad)

        {
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Nacionalidad = nacionalidad;
        }
        public Persona(string nombre, string apellido, int dni, ENacionalidad nacionalidad)
            : this(nombre, apellido, nacionalidad)
        {
            this.DNI = dni;
        }
        public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            :this(nombre, apellido, nacionalidad)
        {
            this.StringToDNI = dni;
        }
        #endregion
        private int ValidarDni(ENacionalidad nacionalidad, int dato)
        {
            int retorno = dato;

            switch (nacionalidad)
            {
                case ENacionalidad.Argentino:
                    if (dato < 1 || dato > 89999999)
                    {
                        throw new NacionalidadInvalidaException();
                    }
                    break;
                case ENacionalidad.Extranjero:
                    if (dato < 90000000 || dato > 99999999)
                    {
                        throw new NacionalidadInvalidaException();
                    }
                    break;
            }
            
            return retorno;
        }
        private int ValidarDni(ENacionalidad nacionalidad, string dato)
        {
            int DNI=0;

            try
            {
                if (dato.Length <= 8 && int.TryParse(dato, out DNI))
                {
                    DNI = this.ValidarDni(nacionalidad, DNI);
                }
                else
                {
                    throw new DniInvalidoException();
                }
            }
            catch (NacionalidadInvalidaException e)
            {

            }
            return DNI;



        }
        private string ValidarNombreApellido(string dato)
        {
            string retorno = "";
            if(dato!= null && dato.All(char.IsLetter))
            {
                retorno = dato;
            }
            return retorno;
        }
        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendFormat("NOMBRE COMPLETO: {0}, {1}\n", this.Apellido, this.Nombre);
            stringBuilder.AppendFormat("NACIONALIDAD: {0}\n", this.Nacionalidad);

            return stringBuilder.ToString();
        }
        public enum ENacionalidad
        {
            Argentino,
            Extranjero
        }
    }
}
