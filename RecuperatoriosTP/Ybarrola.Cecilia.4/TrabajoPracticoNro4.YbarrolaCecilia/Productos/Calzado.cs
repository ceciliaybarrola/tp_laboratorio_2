using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;
using System.Data;
using System.Data.SqlClient;
using System.Xml.Serialization;

namespace Productos
{
    /// <summary>
    /// clase abstracta calzado
    /// </summary>
    public abstract class Calzado
    {
        protected int id;
        private int cantidad;
        protected float precio;
        protected string nombre;
        protected string material;
        #region Propiedades
        public int Id
        {
            get { return this.id; }
            set { this.id = value; }
        }
        public string Material
        {
            get { return this.material; }
            set { this.material = value; }
        }
        public string Nombre
        {
            get { return this.nombre; }
            set { this.nombre = value; }
        }
        public float Precio
        {
            get { return this.precio; }
            set 
            { 
                if(value > 1000)
                {
                    this.precio = value; 
                }
                else
                {
                   throw new PrecioErroneoException();
                }
            }
        }
        public string PrecioString
        {
            set
            {
                float valorNumerico;

                if(float.TryParse(value, out valorNumerico))
                {
                    this.Precio = valorNumerico;
                }
                else
                {
                    throw new PrecioErroneoException();
                }
            }
        }
        public int Cantidad
        {
            get { return this.cantidad; }
            set 
            {
                if (value >= 0)
                {
                    this.cantidad = value;
                }
                else
                {
                    throw new CantidadInvalidaException();
                }
            }
        }
        public string CantidadString
        {
            set
            {
                int valorNumerico;
                if (int.TryParse(value, out valorNumerico))
                {
                    this.Cantidad = valorNumerico;
                }
                else
                {
                    throw new CantidadInvalidaException();
                }            
            }
        }

        #endregion
        #region Constructores
        /// <summary>
        /// constructor por defecto
        /// </summary>
        protected Calzado()
        {
        }
        /// <summary>
        /// constructor parametrizado
        /// </summary>
        /// <param name="cantidad"></param>
        /// <param name="precio"></param>
        /// <param name="nombre"></param>
        /// <param name="material"></param>
        protected Calzado(int cantidad, float precio, string nombre, string material)
        {
            this.Cantidad = cantidad;
            this.Precio = precio;
            this.nombre = nombre;
            this.material = material;

        }
        /// <summary>
        /// USA EXCEPCIONES
        /// constructor parametrizado que toma recibe los datos como string
        /// </summary>
        /// <param name="cantidad"></param>
        /// <param name="precio"></param>
        /// <param name="nombre"></param>
        /// <param name="material"></param>
        protected Calzado(string cantidad, string precio, string nombre, string material)
        {
            if(!string.IsNullOrEmpty(nombre) && !string.IsNullOrWhiteSpace(nombre) && !string.IsNullOrEmpty(material) )
            {
                this.CantidadString = cantidad;
                this.PrecioString = precio;
                this.nombre = nombre;
                this.material = material;
            }
            else
            {
                throw new ArgumentNullException();
            }
        }
        #endregion
        /// <summary>
        /// firma del metodo que ejecutara un comando de ingreso o modificacion
        /// </summary>
        /// <param name="stringComando"></param>
        /// <param name="conexion"></param>
        /// <param name="comando"></param>
        /// <returns></returns>
        public abstract bool ComandoSQL(string stringComando, SqlConnection conexion, SqlCommand comando);
        /// <summary>
        /// firma del metodo que servira para obtener un dato de tipo calzado
        /// </summary>
        /// <param name="stringComando"></param>
        /// <param name="conexion"></param>
        /// <param name="comando"></param>
        /// <param name="calzado"></param>
        /// <returns></returns>
        public abstract bool ComandoSQL(string stringComando, SqlConnection conexion, SqlCommand comando, out Calzado calzado);
       
        #region sobrecargas de operadores
        /// <summary>
        /// sobrecarga del operador ==. Dos calzados son iguales cuando son del mismo tipo y 
        /// comparten los atributos nombre y material
        /// </summary>
        /// <param name="calzado1"></param>
        /// <param name="calzado2"></param>
        /// <returns></returns>
        public static bool operator ==(Calzado calzado1, Calzado calzado2)
        {
            return (calzado1.GetType() == calzado2.GetType() &&
                    calzado1.material == calzado2.material &&
                    calzado1.nombre == calzado2.nombre);
        }
        /// <summary>
        /// sobrecarga del operador !=. Dos calzados son distintos cuando no son del mismo tipo o 
        /// no comparten los atributos nombre o material
        /// </summary>
        /// <param name="calzado1"></param>
        /// <param name="calzado2"></param>
        /// <returns></returns>
        public static bool operator !=(Calzado calzado1, Calzado calzado2)
        {
            return !(calzado1 == calzado2);
        }

        /// <summary>
        /// sobrecarga del metodo to string, encargado de exponer todos los atributos del calzado
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendFormat("Nombre del calzado: {0}\n", this.nombre);
            stringBuilder.AppendFormat("Material: {0}\n", this.material);
            stringBuilder.AppendFormat("Precio por unidad: {0}\n", this.precio);
            stringBuilder.AppendFormat("Cantidad: {0}\n", this.cantidad);

            return stringBuilder.ToString();
        }
        #endregion
    }
}
