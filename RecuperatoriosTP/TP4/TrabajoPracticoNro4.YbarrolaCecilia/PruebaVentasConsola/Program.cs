using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Negocio;
using Productos;
using Excepciones;
using Archivos;
using System.Data;
using System.Data.SqlClient;

namespace PruebaVentasConsola
{
    class Program
    {
        static void Main(string[] args)
        {
            Zapateria zapateria = new Zapateria("Don Ernesto");

            Zapatilla zapatilla1 = new Zapatilla("Crossfit", "10", "3500", "super trainner", "Lona");
            Zapato zapato1 = new Zapato("Cuña", "21", "6000", "zapatos chinos", "Gamuza");

            Calzado calzadoDataBase;
            string cadenaComando;
            //Cantidad invalida
            try
            {
                Zapatilla zapatillaInvalida = new Zapatilla("UsoCotidiano", "salala", "200", "salala", "Tela"); ;
            }
            catch(CantidadInvalidaException ex)
            {
                Console.WriteLine(ex.Message);
            }
            // Precio invalido
            try
            {
                Zapato zapatoInvalido = new Zapato("Cuña", "66", "200", "salala", "Tela"); ;
            }
            catch (PrecioErroneoException ex)
            {
                Console.WriteLine(ex.Message);
            }
            //pruebo la conexion
            try
            {
                AccesoDatos.conexion.Open();
                Console.WriteLine("Conexion abierta efectivamente");
            }
            catch (Exception)
            {
                Console.WriteLine("Error al probar la conexion");
            }
            finally
            {
                if (AccesoDatos.conexion.State == ConnectionState.Open)
                {
                    AccesoDatos.conexion.Close();
                }
            }
            //agrego lista directo de la base
            try
            {
                zapateria.stock = AccesoDatos.ObtenerListaCalzados();
                Console.WriteLine("Se obtuvo la lista de forma correcta");
            }
            catch
            {
                Console.WriteLine("Error al obtener lista");
            }

            //serializo archivo
            try
            {
                Zapateria.Guardar(zapateria);
                Console.WriteLine("Se guardo la zapateria de forma correcta en xml");
            }
            catch(ArchivosException ex)
            {
                Console.WriteLine(ex.Message);
            }

            //deserializo el archivo
            try
            {
                zapateria = Zapateria.Leer();
                Console.WriteLine("Se obtuvo la zapateria de forma correcta en xml\n");
            }
            catch (ArchivosException ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine();
            }

            try
            {
                //agrego zapatilla
                if(AccesoDatos.InsertarCalzado(zapatilla1))
                {                
                    Console.WriteLine("Se inserto zapatilla correctamente en la base de datos");
                }
                else
                {
                    Console.WriteLine("Error al insertar zapatilla en la base de datos");
                }
                // Selecciono zapatilla
                cadenaComando = "SELECT * FROM StockZapateria WHERE nombre = @nombre AND material = @material AND usoRecomendado = @usoRecomendado;";
            
                if(zapatilla1.ComandoSQL(cadenaComando, AccesoDatos.conexion, AccesoDatos.comando, out calzadoDataBase)){
                    if (calzadoDataBase == zapatilla1)
                    {
                        Console.WriteLine("Se obtuvo correctamente la zapatilla");
                    }
                }
                else
                {
                    Console.WriteLine("ERROR! Se obtuvo correctamente la zapatilla");
                }
                //modifico zapatilla
                ((Zapatilla)calzadoDataBase).UsoRecomendado = "Yoga";
                if (AccesoDatos.ModificarCalzado(calzadoDataBase))
                {
                    Console.WriteLine("Se modifico la zapatilla correctamente");
                }
                else
                {
                    Console.WriteLine("No se modifico la zapatilla correctamente");
                }
                //elimino zapatilla
                if (AccesoDatos.EliminarCalzado(calzadoDataBase))
                {
                    Console.WriteLine("Se elimino la zapatilla correctamente\n");
                }
                else
                {
                    Console.WriteLine("No se elimino la zapatilla correctamente\n");
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine("Se genero una excepcion" + ex.Message);
                Console.WriteLine();
            }

            try
            {
                //agrego zapato
                if (AccesoDatos.InsertarCalzado(zapato1))
                {
                    Console.WriteLine("Se inserto zapato correctamente en la base de datos");
                }
                else
                {
                    Console.WriteLine("Error al insertar zapato en la base de datos");
                }

                // Selecciono Zapato
                cadenaComando = "SELECT * FROM StockZapateria WHERE nombre = @nombre AND material = @material AND tipoDeTaco = @tipoDeTaco;";
                if (zapato1.ComandoSQL(cadenaComando, AccesoDatos.conexion, AccesoDatos.comando, out calzadoDataBase))
                {
                    if (calzadoDataBase == zapato1)
                    {
                        Console.WriteLine("Se obtuvo correctamente el zapato");
                    }
                }
                else
                {
                    Console.WriteLine("ERROR! Se obtuvo incorrectamente el zapato");
                }
                //modifico Zapato
                ((Zapato)calzadoDataBase).TipoDeTaco = "Plataforma";
                if (AccesoDatos.ModificarCalzado(calzadoDataBase))
                {
                    Console.WriteLine("Se modifico el zapato correctamente");
                }
                else
                {
                    Console.WriteLine("No se modifico el zapato correctamente");
                }
                //elimino Zapato
                if (AccesoDatos.EliminarCalzado(calzadoDataBase))
                {
                    Console.WriteLine("Se elimino el zapato correctamente\n");
                }
                else
                {
                    Console.WriteLine("No se elimino el zapato correctamente\n");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Se genero una excepcion" + ex.Message);
                Console.WriteLine();
            }

            Console.WriteLine("Presione una tecla terminar...");

            Console.ReadKey();
        }
    }
}
