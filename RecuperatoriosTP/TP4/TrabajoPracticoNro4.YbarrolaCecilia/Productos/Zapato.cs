using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Xml.Serialization;
using System.Xml;

namespace Productos
{
    /// <summary>
    /// clase zapato que deriva de calzado. Este sera uno de los productos aptos para la venta
    /// </summary>
    public class Zapato : Calzado
    {
        private string tipoDeTaco;
        /// <summary>
        /// constructor por defecto
        /// </summary>
        public Zapato()
        {
        }
        /// <summary>
        /// Constructor con Id incluido utilizado para obtener un elemento completo de la base de datos
        /// </summary>
        /// <param name="id"></param>
        /// <param name="tipoDeTaco"></param>
        /// <param name="cantidad"></param>
        /// <param name="precio"></param>
        /// <param name="nombre"></param>
        /// <param name="material"></param>
        public Zapato(int id, string tipoDeTaco, int cantidad, float precio, string nombre, string material) : this(tipoDeTaco, cantidad, precio, nombre, material)
        {
            this.id = id;
        }
        /// <summary>
        /// constructor sin id como parametro
        /// </summary>
        /// <param name="tipoDeTaco"></param>
        /// <param name="cantidad"></param>
        /// <param name="precio"></param>
        /// <param name="nombre"></param>
        /// <param name="material"></param>
        public Zapato(string tipoDeTaco, int cantidad, float precio, string nombre, string material) : base(cantidad, precio, nombre,  material)
        {
            this.tipoDeTaco = tipoDeTaco;
        }
        /// <summary>
        /// constructor sin id como parametro y con los datos recibidos como parametro de tipo string, incluye 
        /// validaciones por nulos o vacios
        /// </summary>
        /// <param name="tipoDeTaco"></param>
        /// <param name="cantidad"></param>
        /// <param name="precio"></param>
        /// <param name="nombre"></param>
        /// <param name="material"></param>
        public Zapato(string tipoDeTaco, string cantidad, string precio, string nombre, string material) : base(cantidad, precio, nombre,  material)
        {
            if(!string.IsNullOrEmpty(tipoDeTaco))
            {
                this.tipoDeTaco = tipoDeTaco;
            }
            else
            {
                throw new ArgumentNullException();
            }
        }
        /// <summary>
        /// propiedad de lectura y escritura del atributo propio
        /// </summary>
        public string TipoDeTaco
        {
            get { return this.tipoDeTaco; }
            set { this.tipoDeTaco = value; }
        }
        /// <summary>
        /// sobrecarga del operador to string que muestra todos los datos del Zapato
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendLine("ZAPATO");
            stringBuilder.AppendLine(base.ToString());
            stringBuilder.AppendLine("Tipo de taco: " + this.tipoDeTaco );

            return stringBuilder.ToString();
        }
        /// <summary>
        /// USA DATA BASE
        /// Ejecuta un comando recibido como parametro. Sirve para realizar updates sin id 
        /// (asi se puede usar este codigo para inserts, tambien se puede agregar al comando 
        /// antes del llamado) e inserts.
        /// </summary>
        /// <param name="stringComando"></param>
        /// <param name="conexion"></param>
        /// <param name="comando"></param>
        /// <returns></returns>
        public override bool ComandoSQL(string stringComando, SqlConnection conexion, SqlCommand comando)
        {
            bool retorno = true;

            try
            {
                comando.Parameters.AddWithValue("@cantidad", this.Cantidad);
                comando.Parameters.AddWithValue("@precio", this.Precio);
                comando.Parameters.AddWithValue("@nombre", this.Nombre);
                comando.Parameters.AddWithValue("@material", this.Material);
                comando.Parameters.AddWithValue("@tipoDeTaco", this.TipoDeTaco);

                comando.CommandText = stringComando;
                conexion.Open();
                comando.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                retorno = false;
                throw e;
            }
            finally
            {
                if (conexion.State == ConnectionState.Open)
                {
                    conexion.Close();
                }
            }

            return retorno;
        }
        /// <summary>
        /// USA DATA BASE
        /// metodo utilizado para hacer selects que no requieran el id como parametro y requieran 
        /// el calzado. 
        /// </summary>
        /// <param name="stringComando"></param>
        /// <param name="conexion"></param>
        /// <param name="comando"></param>
        /// <param name="calzado"></param>
        /// <returns></returns>
        public override bool ComandoSQL(string stringComando, SqlConnection conexion, SqlCommand comando, out Calzado calzado)
        {
            calzado = new Zapato();
            Zapato zapato;
            bool retorno = true;
            try
            {
                comando = new SqlCommand();
                comando.CommandType = CommandType.Text;
                comando.Connection = conexion;

                comando.Parameters.AddWithValue("@cantidad", this.Cantidad);
                comando.Parameters.AddWithValue("@precio", this.Precio);
                comando.Parameters.AddWithValue("@nombre", this.Nombre);
                comando.Parameters.AddWithValue("@material", this.Material);
                comando.Parameters.AddWithValue("@tipoDeTaco", this.TipoDeTaco);
                comando.CommandText = stringComando;

                conexion.Open();

                SqlDataReader dataReader = comando.ExecuteReader();
                if (dataReader.Read())
                {
                    zapato = new Zapato(dataReader.GetInt32(0), dataReader.GetString(5), dataReader.GetInt32(1), (float)(dataReader.GetDouble(2)), dataReader.GetString(3), dataReader.GetString(4));
                    calzado = zapato;
                }
            }
            catch (Exception e)
            {
                retorno = false;
                throw e;
            }
            finally
            {
                comando.Parameters.Clear();
                if (conexion.State == ConnectionState.Open)
                {
                    conexion.Close();
                }
            }
            return retorno;
        }
        /// <summary>
        /// sobrecarga del operador == que reutiliza el == del base y compaa el atributo propio
        /// </summary>
        /// <param name="zapato1"></param>
        /// <param name="zapato2"></param>
        /// <returns></returns>
        public static bool operator ==(Zapato zapato1, Zapato zapato2)
        {
            return zapato1 == (Calzado)zapato2 && zapato1.tipoDeTaco == zapato2.tipoDeTaco;
        }
        /// <summary>
        /// sobrecarga del operador !=
        /// </summary>
        /// <param name="zapato1"></param>
        /// <param name="zapato2"></param>
        /// <returns></returns>
        public static bool operator !=(Zapato zapato1, Zapato zapato2)
        {
            return !(zapato1 == zapato2);
        }
        /// <summary>
        /// sobrecarga del equals. Seran dos objetos iguales cuando sean del tipo Zapato y sean iguales
        /// segun la sobrecarga del ==
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            bool retorno = false;
            if (obj is Zapato)
            {
                retorno = this == (Zapato)obj;
            }

            return retorno;
        }
    }
}
