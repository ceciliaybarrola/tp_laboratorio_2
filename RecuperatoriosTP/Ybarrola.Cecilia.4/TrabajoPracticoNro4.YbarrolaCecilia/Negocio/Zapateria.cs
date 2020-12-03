using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Productos;
using Archivos;
using Excepciones;
using System.Xml.Serialization;
using System.Xml;

namespace Negocio
{
    /// <summary>
    /// Negocio de zapatos.
    /// </summary>
    [XmlInclude(typeof(Zapatilla))]
    [XmlInclude(typeof(Zapato))]
    [XmlInclude(typeof(Calzado))]
    [XmlInclude(typeof(Zapateria))]
    public class Zapateria
    {
        public List<Calzado> stock;
        public List<Calzado> ventas;
        public float gananciaDelDia;
        public string nombreZapateria;
        /// <summary>
        /// Constructor por defecto encargado de instanciar las listas
        /// </summary>
        public Zapateria()
        {
            this.stock = new List<Calzado>();
            this.ventas = new List<Calzado>();
        }
        /// <summary>
        /// constructor parametrizado que recibe como parametro el nombre de la zapateria
        /// </summary>
        /// <param name="nombreZapateria"></param>
        public Zapateria(string nombreZapateria)
            :this()
        {
            this.gananciaDelDia = 0;
            this.nombreZapateria = nombreZapateria;
        }
        /// <summary>
        /// metodo enargado de calcular la ganancia teniendo en cuenta que se 
        /// gana el %20 del precio del producto
        /// </summary>
        /// <returns></returns>
        public float BalanceDelDia()
        {
            float balance = 0;
            foreach(Calzado item in this.ventas)
            {
                balance += ((item.Precio * 20) / 100)* item.Cantidad;
            }

            return balance;
        }
        /// <summary>
        /// Se encarga de serializar una zapateria a xml
        /// </summary>
        /// <param name="zapateria"></param>
        /// <returns></returns>
        public static bool Guardar(Zapateria zapateria)
        {
            Xml<Zapateria> xml = new Xml<Zapateria>();
            return xml.Guardar("Zapateria.xml", zapateria);

        }
        /// <summary>
        /// Deserializará un archivo xml y convertira los datos en una zapateria
        /// </summary>
        /// <returns></returns>
        public static Zapateria Leer()
        {
            Zapateria zapateria = new Zapateria();
            Xml<Zapateria> xml = new Xml<Zapateria>();
            try
            {
                xml.Leer("Zapateria.xml", out zapateria);
            }
            catch (ArchivosException e)
            {
                Console.WriteLine(e.Message);
            }
            return zapateria;
        }
        /// <summary>
        /// lee el archivo de tickets
        /// </summary>
        /// <returns></returns>
        public static string LeerTicketera()
        {
            string ticketVentas="";
            Texto texto = new Texto();
            try
            {
                texto.Leer("RegistroVentas.txt", out ticketVentas);
            }
            catch (ArchivosException e)
            {
                Console.WriteLine(e.Message);
            }
            return ticketVentas;
        }
        /// <summary>
        /// Escribe el archivo de ventas
        /// </summary>
        /// <param name="ventas"></param> lista de ventas a escribir
        /// <returns></returns>
        public string EscribirTicketera(List<Calzado> ventas)
        {
            string ticketVentas = Zapateria.EscribirTicket(ventas, this);
            Texto texto = new Texto();
            try
            {
                texto.Guardar("RegistroVentas.txt", ticketVentas, true);
            }
            catch (ArchivosException e)
            {
                Console.WriteLine(e.Message);
            }
            return ticketVentas;
        }
        /// <summary>
        /// Se encarga de darle el formato al ticket segun la lista que reciba y la zapateria recibida como parametro
        /// </summary>
        /// <param name="ventas"></param>
        /// <param name="zapateria"></param>
        /// <returns></returns>
        public static string EscribirTicket(List<Calzado> ventas, Zapateria zapateria)
        {
            StringBuilder stringBuilder = new StringBuilder();
            float precioTotal = 0;

            stringBuilder.AppendFormat("**************** ZAPATERIA {0} ****************\n", zapateria.nombreZapateria);
            stringBuilder.AppendFormat("Fecha de emision {0}\n", DateTime.Now);
            stringBuilder.AppendLine("Listado de productos:");
            foreach(Calzado item in ventas)
            {
                stringBuilder.AppendLine(item.ToString());
                precioTotal += item.Precio * item.Cantidad;
            }
            stringBuilder.AppendLine("PRECIO TOTAL ------------> "+ precioTotal);
            stringBuilder.AppendLine("**************************************************************************");
            
            return stringBuilder.ToString();
        }
        /// <summary>
        /// una zapateria sera igual a un calzado si el mismo se encuentra en su stock
        /// </summary>
        /// <param name="zapateria"></param>
        /// <param name="calzado"></param>
        /// <returns></returns>
        public static bool operator ==(Zapateria zapateria , Calzado calzado)
        {
            bool retorno = false;

            foreach(Calzado item in zapateria.stock)
            {
                if(calzado.Equals(item))
                {
                    retorno = true;
                    break;
                }
            }
            return retorno;
        }
        /// <summary>
        /// una zapateria sera distinta a un calzado cuando el mismo no este dentro de la lista
        /// </summary>
        /// <param name="zapateria"></param>
        /// <param name="calzado"></param>
        /// <returns></returns>
        public static bool operator !=(Zapateria zapateria, Calzado calzado)
        {
            return !(zapateria==calzado);
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendFormat("**************** ZAPATERIA {0} ****************\n", this.nombreZapateria);

            stringBuilder.AppendLine("Listado de Stock:");
            foreach (Calzado item in this.stock)
            {
                stringBuilder.AppendLine(item.ToString());
            }
            stringBuilder.AppendLine("\nListado de Ventas:");
            foreach (Calzado item in this.ventas)
            {
                stringBuilder.AppendLine(item.ToString());
            }
            stringBuilder.AppendLine("**************************************************************************");

            return stringBuilder.ToString();
        }

    }
}
