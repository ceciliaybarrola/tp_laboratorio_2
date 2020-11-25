using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;
using System.Data;
using System.Data.SqlClient;

namespace Productos
{
    public abstract class Calzado
    {
        protected int id;
        private int cantidad;
        protected float precio;
        protected string nombre;
        protected string material;
        /*
         posibles errores al usar este enum al serialiar, cambio a string
         */
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
        protected Calzado()
        {
        }
        protected Calzado(int cantidad, float precio, string nombre, string material)
        {
            this.Cantidad = cantidad;
            this.Precio = precio;
            this.nombre = nombre;
            this.material = material;

        }
       /* protected Calzado(float precioAlCosto, string nombre, bool esDeMarca)
            : this(1, precioAlCosto, nombre, esDeMarca)
        {
        }*/
        protected Calzado(string cantidad, string precio, string nombre, string material)
        {
            this.CantidadString = cantidad;
            this.PrecioString = precio;
            this.nombre = nombre;
            this.material = material;

        }
        public abstract bool ComandoSQL(string stringComando, SqlConnection conexion, SqlCommand comando);
        public abstract bool ComandoSQL(string stringComando, SqlConnection conexion, SqlCommand comando, out Calzado calzado);
        #endregion
        public static bool operator ==(Calzado calzado1, Calzado calzado2)
        {
            return (calzado1.GetType() == calzado2.GetType() &&
                    calzado1.material == calzado2.material &&
                    calzado1.nombre == calzado2.nombre);
        }
        public static bool operator !=(Calzado calzado1, Calzado calzado2)
        {
            return !(calzado1 == calzado2);
        }


        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendFormat("Nombre del calzado: {0}\n", this.nombre);
            stringBuilder.AppendFormat("Material: {0}\n", this.material);
            stringBuilder.AppendFormat("Precio por unidad: {0}\n", this.precio);
            stringBuilder.AppendFormat("Cantidad: {0}\n", this.cantidad);

            return stringBuilder.ToString();
        }

    }
}
