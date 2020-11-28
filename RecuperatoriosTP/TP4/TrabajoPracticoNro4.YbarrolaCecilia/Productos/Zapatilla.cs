using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Xml;
using System.Xml.Serialization;

namespace Productos
{
    /// <summary>
    /// Clase insanciable Zapatilla la cual deriva de Calzado. Es un producto que formara parte del stock
    /// </summary>
    public class Zapatilla : Calzado
    {
        private string usoRecomendado;

        #region Constructores
        /// <summary>
        /// constructor por defecto de Zapatilla
        /// </summary>
        public Zapatilla()
        {
        }
        /// <summary>
        /// constructor parametrizado 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="usoRecomendado"></param>
        /// <param name="cantidad"></param>
        /// <param name="precioAlCosto"></param>
        /// <param name="nombre"></param>
        /// <param name="material"></param>
        public Zapatilla(int id,string usoRecomendado, int cantidad, float precioAlCosto, string nombre, string material) : base(cantidad, precioAlCosto, nombre,  material)
        {
            this.usoRecomendado = usoRecomendado;
            this.id = id;
        }
        /// <summary>
        /// constructor parametrizado que recibe los datos como string.
        /// </summary>
        /// <param name="usoRecomendado"></param>
        /// <param name="cantidad"></param>
        /// <param name="precioAlCosto"></param>
        /// <param name="nombre"></param>
        /// <param name="material"></param>
        public Zapatilla(string usoRecomendado, string cantidad, string precioAlCosto, string nombre, string material) : base(cantidad, precioAlCosto, nombre,  material)
        {
            if(!string.IsNullOrEmpty(usoRecomendado))
            {
                this.usoRecomendado = usoRecomendado;
            }
            else
            {
                throw new ArgumentNullException();
            }
        }
        #endregion
        #region Propiedad
        /// <summary>
        /// propiedad de lectura y escritura del atributo uso recomendado
        /// </summary>
        public string UsoRecomendado
        {
            get { return this.usoRecomendado; }
            set { this.usoRecomendado = value; }
        }
        #endregion
        #region Metodos
        /// <summary>
        /// implementacion del miembro abstracto de la clase base. Se utiliza para insertar y para modificar.
        /// No hace uso del id para poder ser usado para insertar, en caso de necesitarlo, se puede añadir el
        /// valor del parametro antes.
        /// </summary>
        /// <param name="stringComando"></param> Comando a ejecutar
        /// <param name="conexion"></param> conexion a la base de datos
        /// <param name="comando"></param> SqlComand
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
                comando.Parameters.AddWithValue("@usoRecomendado", this.UsoRecomendado);
                comando.CommandText = stringComando;

                conexion.Open();
                
                comando.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
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
        /// sobrecarga e implementacion de la firma del metodo base. Es utilizado para hacer un select
        /// por algun atributo distinto al id y lo retorna como parametro.
        /// </summary>
        /// <param name="stringComando"></param> Comando qwery a ejecutar
        /// <param name="conexion"></param> conexion a la base de datos
        /// <param name="comando"></param> SqlComand
        /// <param name="calzado"></param> 
        /// <returns></returns>
        public override bool ComandoSQL(string stringComando, SqlConnection conexion, SqlCommand comando, out Calzado calzado)
        {
            calzado = new Zapatilla();
            Zapatilla zapatilla;
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
                comando.Parameters.AddWithValue("@usoRecomendado", this.UsoRecomendado);
                comando.CommandText = stringComando;

                conexion.Open();

                SqlDataReader dataReader = comando.ExecuteReader();
                if (dataReader.Read())
                {
                    zapatilla = new Zapatilla(dataReader.GetInt32(0), dataReader.GetString(6), dataReader.GetInt32(1), (float)(dataReader.GetDouble(2)), dataReader.GetString(3), dataReader.GetString(4));
                    calzado = zapatilla;
                }
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
        #endregion
        #region sobrecarga de operadores
        /// <summary>
        /// sobrecarga del metodo ToString que expone los atributos de la zapatilla
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendLine("ZAPATILLA");
            stringBuilder.AppendLine(base.ToString());
            stringBuilder.AppendLine("Uso recomendado segun deporte: " + this.usoRecomendado);

            return stringBuilder.ToString();
        }
        /// <summary>
        /// sobrecarga del metodo Equals
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            bool retorno = false;
            if (obj is Zapatilla)
            {
                retorno = this == (Calzado)obj;
            }

            return retorno;
        }
        #endregion
    }
}
