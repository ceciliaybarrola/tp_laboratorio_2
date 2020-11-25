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
    public static class AccesoDatos
    {
        #region Atributos

        public static SqlConnection conexion;
        public static SqlCommand comando;

        #endregion

        #region Constructor
        static AccesoDatos()
        {
            AccesoDatos.conexion = new SqlConnection(Properties.Settings.Default.coneccionStockZapateriaDB);
        }

        #endregion

        #region Métodos

        #region Getters
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
            catch (Exception ex)
            {
                //Console.WriteLine(ex.ToString());
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

        public static Calzado ObtenerCalzadoPorID(int id)
        {
            Zapatilla zapatilla=new Zapatilla ();
            Zapato zapato= new Zapato();
            bool esZapatilla= false;

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
                        zapato = new Zapato(dataReader.GetInt32(0), dataReader.GetString(5), dataReader.GetInt32(1), (float)(dataReader.GetDouble(2)), dataReader.GetString(3), dataReader.GetString(4));
                    }
                    else if (dataReader.IsDBNull(5))//Si no existe el atributo tipo de taco es zapatilla
                    {
                        zapatilla = new Zapatilla(dataReader.GetInt32(0), dataReader.GetString(6), dataReader.GetInt32(1), (float)(dataReader.GetDouble(2)), dataReader.GetString(3), dataReader.GetString(4));
                        esZapatilla = true;
                    }
                }


                dataReader.Close();
            }

            catch (Exception e )
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                if (AccesoDatos.conexion.State == ConnectionState.Open)
                {
                    AccesoDatos.conexion.Close();
                }
            }
            if (esZapatilla)
            {
                return zapatilla;
            }
            else
            {
                return zapato;
            }
;
        }

        #endregion

        #region Insertar Calzado
        public static bool InsertarCalzado(Calzado calzado)
        {
            bool todoOk = false;
            string sql;
            try
            {
                AccesoDatos.comando = new SqlCommand();
                AccesoDatos.comando.CommandType = CommandType.Text;
                AccesoDatos.comando.Connection = AccesoDatos.conexion;

                if (calzado is Zapato)
                {
                    sql = " INSERT INTO StockZapateria(cantidad, precio, nombre, material ,tipoDeTaco) VALUES(@cantidad, @precio, @nombre, @material, @tipoDeTaco);";
                    todoOk = calzado.ComandoSQL(sql, AccesoDatos.conexion, AccesoDatos.comando);             
                }
                else
                {
                    sql = " INSERT INTO StockZapateria(cantidad, precio, nombre, material , usoRecomendado) VALUES(@cantidad, @precio, @nombre, @material, @usoRecomendado);";
                    todoOk = calzado.ComandoSQL(sql, AccesoDatos.conexion, AccesoDatos.comando);
                }

            }
            catch (Exception e)
            {
                todoOk = false;
            }

            return todoOk;
        }

        #endregion

        #region Modificar Calzado
        public static bool ModificarCalzado(Calzado calzado)
        {
            bool todoOk = false;

            string sql;

            try
            {
                if (calzado is Zapato)
                {
                    sql = " UPDATE StockZapateria SET cantidad = @cantidad, precio = @precio, " +
                        "nombre = @nombre, material = @material, tipoDeTaco = @tipoDeTaco WHERE id = @id";
                    todoOk = calzado.ComandoSQL(sql, AccesoDatos.conexion, AccesoDatos.comando);
                }
                else
                {
                    sql = " UPDATE StockZapateria SET cantidad = @cantidad, precio = @precio, " +
                        "nombre = @nombre, material = @material, usoRecomendado = @usoRecomendado WHERE id = @id";
                    todoOk = calzado.ComandoSQL(sql, AccesoDatos.conexion, AccesoDatos.comando);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);//Error de syntaxis
                todoOk = false;
            }

            return todoOk;
        }

        #endregion

        #region Eliminar Calzado
        public static bool EliminarCalzado(Calzado calzado)
        {
            bool todoOk = false;

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

                todoOk = true;
            }
            catch (Exception)
            {
                todoOk = false;
            }
            finally
            {
                if (AccesoDatos.conexion.State == ConnectionState.Open)
                {
                    AccesoDatos.conexion.Close();
                }
            }

            return todoOk;
        }

        #endregion

        #endregion





    }
}
