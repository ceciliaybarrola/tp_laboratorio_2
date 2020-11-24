using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Productos
{
    public class Zapatilla : Calzado
    {
        private string usoRecomendado;

        public Zapatilla()
        {
        }
        public Zapatilla(int id,string usoRecomendado, int cantidad, float precioAlCosto, string nombre, string material) : base(cantidad, precioAlCosto, nombre,  material)
        {
            this.usoRecomendado = usoRecomendado;
            this.id = id;
        }
        public Zapatilla(string usoRecomendado, string cantidad, string precioAlCosto, string nombre, string material) : base(cantidad, precioAlCosto, nombre,  material)
        {
            this.usoRecomendado = usoRecomendado;
        }
        public Zapatilla( string usoRecomendado, int cantidad, float precioAlCosto, string nombre, string material) : base(cantidad, precioAlCosto, nombre, material)
        {
            this.usoRecomendado = usoRecomendado;
        }
        public string UsoRecomendado
        {
            get { return this.usoRecomendado; }
            set { this.usoRecomendado = value; }
        }
        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendLine("ZAPATILLA");
            stringBuilder.AppendLine(base.ToString());
            stringBuilder.AppendLine("Uso recomendado segun deporte: " + this.usoRecomendado);

            return stringBuilder.ToString();
        }

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
        public bool ComandoSQL(string stringComando, SqlConnection conexion, SqlCommand comando, out Zapatilla zapatilla)
        {
            zapatilla = new Zapatilla();
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

                SqlDataReader dataReader = comando.ExecuteReader();
                if (dataReader.Read())
                {
                    zapatilla = new Zapatilla(dataReader.GetInt32(0), dataReader.GetString(6), dataReader.GetInt32(1), (float)(dataReader.GetDouble(2)), dataReader.GetString(3), dataReader.GetString(4));
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
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
        public override bool Equals(object obj)
        {
            bool retorno = false;
            if (obj is Zapatilla)
            {
                retorno = this == (Calzado)obj;
            }

            return retorno;
        }



    }
}
