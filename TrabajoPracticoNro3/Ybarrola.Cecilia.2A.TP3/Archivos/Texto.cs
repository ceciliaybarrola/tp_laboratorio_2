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

        public bool Guardar(string archivo, string datos)
        {
            bool retorno= false;
            Encoding miCodificacion = Encoding.UTF8;

            try
            {
                using (StreamWriter sw = new StreamWriter(archivo, false, miCodificacion))
                {
                    sw.WriteLine(datos);
                }
                retorno = true;
            }
            catch(Exception e)
            {
                throw new ArchivosException(e);
            }

             return retorno;
        }
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
