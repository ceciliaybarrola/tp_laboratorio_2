using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Productos;
using Archivos;
using Excepciones;

namespace Negocio
{
    public class Zapateria
    {
        public List<Calzado> stock;
        public List<Calzado> ventas;
        public float gananciaDelDia;
        public string nombreZapateria;

        public Zapateria()
        {
            this.stock = new List<Calzado>();
            this.ventas = new List<Calzado>();
        }
        public Zapateria(string nombreZapateria)
            :this()
        {
            this.gananciaDelDia = 0;
            this.nombreZapateria = nombreZapateria;
        }
        public float BalanceDelDia()
        {
            float balance = 0;
            foreach(Calzado item in this.ventas)
            {
                balance += ((item.Precio * 20) / 100);
            }

            return balance;
        }
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

            ///poner el costo total

            stringBuilder.AppendLine("**************************************************************************");
            
            return stringBuilder.ToString();
        }

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
        public static bool operator !=(Zapateria zapateria, Calzado calzado)
        {
            return !(zapateria==calzado);
        }
 /*       /// <summary>
        /// Busca un calzado determinado en una zapateria 
        /// (segun el criterio de igualdad de esta clase) 
        /// y devuelve la posicion en la que e encuentra
        /// </summary>
        /// <param name="calzado"></param>
        /// <param name="posicion"></param>
        /// <returns></returns> True si se lo encontro, false de lo contrario
        public bool ObtenerCalzado(Calzado calzado, out int posicion)
        {
            bool retorno = false;
            posicion = -1;
            for(int i = 0; i < this.stock.Count; i++)
            {
                if (calzado.Equals(this.stock[i]))
                {
                    posicion = i;
                    retorno = true;
                    break;
                }
            }
            return retorno;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="zapateria"></param>
        /// <param name="calzado"></param>
        /// <returns></returns> Retona true si el calzado no existia y se agrego a la lista. 
        /// Retorna False si el calzado ya existia y se increento el inventario de este
        public static Zapateria operator +(Zapateria zapateria, Calzado calzado)
        {
            bool retorno = false;
            int posicionCalzado;

            if(zapateria.ObtenerCalzado(calzado, out posicionCalzado))
            {
                (zapateria.stock[posicionCalzado]).Cantidad += calzado.Cantidad;
            }
            else
            {
                zapateria.stock.Add(calzado);
                retorno = true;
            }
            return zapateria;
        }

*/

    }
}
