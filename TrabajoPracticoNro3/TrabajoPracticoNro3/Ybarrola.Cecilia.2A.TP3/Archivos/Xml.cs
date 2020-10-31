using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;
using System.Xml.Serialization;
using System.Xml;

namespace Archivos
{
    public class Xml<T> : IArchivo<T>
    {
        public bool Guardar(string archivo, T datos)
        {
            bool retorno = false;
            try
            {
                using (XmlTextWriter writer = new XmlTextWriter(archivo, Encoding.UTF8))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(T));
                    serializer.Serialize(writer, datos);
                }
                retorno = true;
            }
            catch (Exception ex)
            {
                throw new ArchivosException(ex);
            }
            return retorno;
        }
        public bool Leer(string archivo, out T datos)
        {
            bool retorno = false;
            datos = default;
            try
            {
                using (XmlTextReader reader = new XmlTextReader(archivo))
                {
                    XmlSerializer ser = new XmlSerializer(typeof(T));
                    datos = (T)ser.Deserialize(reader);
                    retorno = true;
                }               
            }
            catch (Exception ex)
            {
                throw new ArchivosException(ex);
            }

            return retorno;
        }
        


    }
}
