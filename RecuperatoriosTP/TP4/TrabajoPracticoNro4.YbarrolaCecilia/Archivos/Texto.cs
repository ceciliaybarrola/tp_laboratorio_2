using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;
using System.IO;
using MetodosDeExtension;

namespace Archivos
{
    public class Texto : IArchivo<string>
    {
        /// <summary>
        /// USA ARCHIVOS DE TEXTO
        /// Implenetacion de la interfaz para guardar un archivo, en este caso, de texto
        /// </summary>
        /// <param name="archivo"></param>
        /// <param name="datos"></param> 
        /// <returns></returns> Retorna true si se pudo guardar, de lo contrario, false
        public bool Guardar(string archivo, string datos)
        {
            return this.Guardar(archivo, datos, false);
        }

        /// <summary>
        /// USA ARCHIVOS DE TEXTO
        /// guardar un archivo de texto y recibe como parametro el append
        /// </summary>
        /// <param name="archivo"></param>
        /// <param name="datos"></param>
        /// <param name="append"></param>
        /// <returns></returns>Retorna true si se pudo guardar, de lo contrario, false
        public bool Guardar(string archivo, string datos, bool append)
        {
            bool retorno = false;
            Encoding miCodificacion = Encoding.UTF8;

            try
            { 
                using (StreamWriter sw = new StreamWriter(archivo, append, miCodificacion))
                {
                    sw.WriteLine(datos);
                }
                retorno = true;
            }
            catch (Exception e)
            {
                throw new ArchivosException(e);
            }

            return retorno;
        }
        /// <summary>
        /// USA ARCHIVOS DE TEXTO
        /// Lee un archivo de texto en unaruta determinada y lo devuelve como un string
        /// </summary>
        /// <param name="archivo"></param>
        /// <param name="datos"></param>
        /// <returns></returns>
        public bool Leer(string archivo, out string datos)
        {
            bool retorno = false;
            datos = archivo.LeerArchivo();
            retorno = true;

            return retorno;
        }



    }
}
