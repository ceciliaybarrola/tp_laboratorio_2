using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Productos
{
    public class Zapato : Calzado
    {
        private string tipoDeTaco;
        public Zapato()
        {
        }
        public Zapato(int id, string tipoDeTaco, int cantidad, float precioAlCosto, string nombre, string material) : base(cantidad, precioAlCosto, nombre, material)
        {
            this.tipoDeTaco = tipoDeTaco;
            this.id = id;
        }
        public Zapato(string tipoDeTaco, int cantidad, float precioAlCosto, string nombre, string material) : base(cantidad, precioAlCosto, nombre,  material)
        {
            this.tipoDeTaco = tipoDeTaco;
        }
        public Zapato(string tipoDeTaco, string cantidad, string precioAlCosto, string nombre, string material) : base(cantidad, precioAlCosto, nombre,  material)
        {
            this.tipoDeTaco = tipoDeTaco;
        }
        public string TipoDeTaco
        {
            get { return this.tipoDeTaco; }
            set { this.tipoDeTaco = value; }
        }
        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendLine("ZAPATO");
            stringBuilder.AppendLine(base.ToString());
            stringBuilder.AppendLine("Tipo de taco: " + this.tipoDeTaco );

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
        public override bool ComandoSQL(string stringComando, SqlConnection conexion, SqlCommand comando, out Calzado calzado)
        {
            calzado = new Zapato();
            Zapato zapato;
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

                SqlDataReader dataReader = comando.ExecuteReader();
                if (dataReader.Read())
                {
                    zapato = new Zapato(dataReader.GetInt32(0), dataReader.GetString(5), dataReader.GetInt32(1), (float)(dataReader.GetDouble(2)), dataReader.GetString(3), dataReader.GetString(4));
                    calzado = zapato;
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
        public static bool operator ==(Zapato zapato1, Zapato zapato2)
        {
            return zapato1 == (Calzado)zapato2 && zapato1.tipoDeTaco == zapato2.tipoDeTaco;
        }
        public static bool operator !=(Zapato zapato1, Zapato zapato2)
        {
            return !(zapato1 == zapato2);
        }
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
