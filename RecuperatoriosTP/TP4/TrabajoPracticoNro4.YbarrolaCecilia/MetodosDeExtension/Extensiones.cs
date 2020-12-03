using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Excepciones;

namespace MetodosDeExtension
{
    /// <summary>
    /// USO DE METODOS DE EXTENSION
    /// </summary>
    public static class Extensiones
    {
        /// <summary>
        /// metodo de extension encargado de leer un archivo de texto
        /// </summary>
        /// <param name="archivo"></param>
        /// <returns></returns>
        public static string LeerArchivo(this string archivo)
        {
            string retorno;
            Encoding miCodificacion = Encoding.UTF8;
            try
            {
                using (StreamReader streamReader = new StreamReader(archivo, miCodificacion))
                {
                    retorno = streamReader.ReadToEnd();
                }
            }
            catch (Exception e)
            {
                throw new ArchivosException(e);
            }

            return retorno;
        }
    }



}
