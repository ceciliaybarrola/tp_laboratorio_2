using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;
using System.IO;

namespace Archivos
{
    public class Texto : IArchivo<string>
    {
        /// <summary>
        /// Implenetacion de la interfaz para guardar un archivo, en este caso, de texto
        /// </summary>
        /// <param name="archivo"></param>
        /// <param name="datos"></param> out donde saldra el string de la lectua del archivo
        /// <returns></returns> Retorna true si se pudo guardar, de lo contrario, false
        public bool Guardar(string archivo, string datos)
        {
            return this.Guardar(archivo, datos, false);
        }
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
        /// Lee un archivo de texto en unaruta determinada y lo devuelve como un string
        /// </summary>
        /// <param name="archivo"></param>
        /// <param name="datos"></param>
        /// <returns></returns>
        public bool Leer(string archivo, out string datos)
        {
            bool retorno = false;
            Encoding miCodificacion = Encoding.UTF8;

            try
            {
                using (StreamReader streamReader = new StreamReader(archivo, miCodificacion))
                {
                    datos = streamReader.ReadToEnd();
                }
                retorno = true;
            }
            catch (Exception e)
            {
                throw new ArchivosException(e);
            }

            return retorno;
        }



    }
}
