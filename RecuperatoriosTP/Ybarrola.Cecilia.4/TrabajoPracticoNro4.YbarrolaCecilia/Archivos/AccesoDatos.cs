using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Productos;

namespace Archivos
{
    /// <summary>
    /// USO DATA BASE
    /// clase estatica AccesoDatos que se encarga de manejar la gran mayoria de las 
    /// interacciones con la base de datos
    /// </summary>
    public static class AccesoDatos
    {
        #region Atributos

        public static SqlConnection conexion;
        public static SqlCommand comando;

        #endregion
        #region Constructor
        /// <summary>
        /// constructor estatico del 
        /// </summary>
        static AccesoDatos()
        {
            AccesoDatos.conexion = new SqlConnection(Properties.Settings.Default.coneccionStockZapateriaDB);
        }

        #endregion
        #region Métodos

        #region Getters
        /// <summary>
        /// obtiene los elementos de la base de datos y los agrega a una lista de calzados
        /// </summary>
        /// <returns></returns>
        public static List<Calzado> ObtenerListaCalzados()
        {
            List<Calzado> lista = new List<Calzado>();

            try
            {
                AccesoDatos.comando = new SqlCommand();
                AccesoDatos.comando.CommandType = CommandType.Text;
                AccesoDatos.comando.Connection = AccesoDatos.conexion;
                comando.CommandText = "SELECT * FROM StockZapateria ORDER BY id, nombre";
                AccesoDatos.conexion.Open();

                SqlDataReader dataReader = AccesoDatos.comando.ExecuteReader();

                while(dataReader.Read())
                {
                    if (dataReader.IsDBNull(6))
                    {
                        lista.Add(new Zapato(dataReader.GetString(5), dataReader.GetInt32(1), (float)(dataReader.GetDouble(2)), dataReader.GetString(3), dataReader.GetString(4)));
                    }
                    else if (dataReader.IsDBNull(5))//Si no existe el atributo tipo de taco 
                    {
                        lista.Add(new Zapatilla(dataReader.GetInt32(0), dataReader.GetString(6), dataReader.GetInt32(1), (float)(dataReader.GetDouble(2)), dataReader.GetString(3), dataReader.GetString(4)));
                    }
                }
                dataReader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                if (AccesoDatos.conexion.State == ConnectionState.Open)
                {
                    AccesoDatos.conexion.Close();
                }
            }

            return lista;
        }
        /// <summary>
        /// obtiene los elementos de la base de datos y los agrega a una datatable
        /// </summary>
        /// <returns></returns>
        public static DataTable ObtenerTablaCalzado()
        {
            DataTable tabla = new DataTable("StockZapateria");

            try
            {
                AccesoDatos.comando = new SqlCommand();
                AccesoDatos.comando.CommandType = CommandType.Text;
                AccesoDatos.comando.Connection = AccesoDatos.conexion;
                AccesoDatos.comando.CommandText = "SELECT * FROM StockZapateria ORDER BY id DESC, nombre";
                AccesoDatos.conexion.Open();

                SqlDataReader dataReader = AccesoDatos.comando.ExecuteReader();

                tabla.Load(dataReader);

                dataReader.Close();
            }
            finally
            {
                if (AccesoDatos.conexion.State == ConnectionState.Open)
                {
                    AccesoDatos.conexion.Close();
                }
            }

            return tabla;
        }
        /// <summary>
        /// hace un select de la base de datos por id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static Calzado ObtenerCalzadoPorID(int id)
        {
            Calzado calzado= null;

            try
            {
                AccesoDatos.comando = new SqlCommand();
                AccesoDatos.comando.CommandType = CommandType.Text;
                AccesoDatos.comando.Connection = AccesoDatos.conexion;

                AccesoDatos.comando.CommandText = "SELECT * FROM StockZapateria WHERE id = @id;";
                AccesoDatos.comando.Parameters.AddWithValue("@id", id);
                AccesoDatos.conexion.Open();

                SqlDataReader dataReader = AccesoDatos.comando.ExecuteReader();

                if(dataReader.Read())
                {
                    if(dataReader.IsDBNull(6))//Si no existe el atributo uso recomendado es zapato
                    {
                        calzado = new Zapato(dataReader.GetInt32(0), dataReader.GetString(5), dataReader.GetInt32(1), (float)(dataReader.GetDouble(2)), dataReader.GetString(3), dataReader.GetString(4));
                    }
                    else if (dataReader.IsDBNull(5))//Si no existe el atributo tipo de taco es zapatilla
                    {
                        calzado = new Zapatilla(dataReader.GetInt32(0), dataReader.GetString(6), dataReader.GetInt32(1), (float)(dataReader.GetDouble(2)), dataReader.GetString(3), dataReader.GetString(4));
                    }
                }
                dataReader.Close();
            }
            finally
            {
                if (AccesoDatos.conexion.State == ConnectionState.Open)
                {
                    AccesoDatos.conexion.Close();
                }
            }

            return calzado;
;
        }

        #endregion

        #region Insertar Calzado
        /// <summary>
        /// inserta un calzado en la base de datos
        /// </summary>
        /// <param name="calzado"></param>
        /// <returns></returns>
        public static bool InsertarCalzado(Calzado calzado)
        {
            bool retorno;
            string sql;
            try
            {
                AccesoDatos.comando = new SqlCommand();
                AccesoDatos.comando.CommandType = CommandType.Text;
                AccesoDatos.comando.Connection = AccesoDatos.conexion;

                if (calzado is Zapato)
                {
                    sql = " INSERT INTO StockZapateria(cantidad, precio, nombre, material ,tipoDeTaco) VALUES(@cantidad, @precio, @nombre, @material, @tipoDeTaco);";
                    retorno = calzado.ComandoSQL(sql, AccesoDatos.conexion, AccesoDatos.comando);             
                }
                else
                {
                    sql = " INSERT INTO StockZapateria(cantidad, precio, nombre, material , usoRecomendado) VALUES(@cantidad, @precio, @nombre, @material, @usoRecomendado);";
                    retorno = calzado.ComandoSQL(sql, AccesoDatos.conexion, AccesoDatos.comando);
                
                }
            }
            catch (Exception)
            {
                retorno = false;
            }

            return retorno;
        }

        #endregion

        #region Modificar Calzado
        /// <summary>
        /// hace un update de un calzado en la base de datos
        /// </summary>
        /// <param name="calzado"></param>
        /// <returns></returns>
        public static bool ModificarCalzado(Calzado calzado)
        {
            bool retorno;
            string sql;

            try
            {
                AccesoDatos.comando = new SqlCommand();
                AccesoDatos.comando.CommandType = CommandType.Text;
                AccesoDatos.comando.Connection = AccesoDatos.conexion;

                if (calzado is Zapato)
                {
                    sql = " UPDATE StockZapateria SET cantidad = @cantidad, precio = @precio, " +
                        "nombre = @nombre, material = @material, tipoDeTaco = @tipoDeTaco WHERE id = @id";
                    
                    AccesoDatos.comando.Parameters.AddWithValue("@id", calzado.Id);
                    retorno = calzado.ComandoSQL(sql, AccesoDatos.conexion, AccesoDatos.comando);
                }
                else
                {
                    sql = " UPDATE StockZapateria SET cantidad = @cantidad, precio = @precio, " +
                        "nombre = @nombre, material = @material, usoRecomendado = @usoRecomendado WHERE id = @id";
                    
                    AccesoDatos.comando.Parameters.AddWithValue("@id", calzado.Id);
                    retorno = calzado.ComandoSQL(sql, AccesoDatos.conexion, AccesoDatos.comando);
                }
                retorno = true;
            }
            catch (Exception)
            {
                retorno = false;
            }

            return retorno;
        }

        #endregion

        #region Eliminar Calzado
        /// <summary>
        /// hace un delete de un calzado
        /// </summary>
        /// <param name="calzado"></param>
        /// <returns></returns>
        public static bool EliminarCalzado(Calzado calzado)
        {
            bool retorno = false;

            string sql = "DELETE FROM StockZapateria WHERE id = @id";

            try
            {
                AccesoDatos.comando = new SqlCommand();
                AccesoDatos.comando.CommandType = CommandType.Text;
                AccesoDatos.comando.Connection = AccesoDatos.conexion;

                AccesoDatos.comando.Parameters.AddWithValue("@id", calzado.Id);
                AccesoDatos.comando.CommandText = sql;
                AccesoDatos.conexion.Open();
                AccesoDatos.comando.ExecuteNonQuery();

                retorno = true;
            }
            finally
            {
                if (AccesoDatos.conexion.State == ConnectionState.Open)
                {
                    AccesoDatos.conexion.Close();
                }
            }

            return retorno;
        }

        #endregion

        #endregion
    }
}
