using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archivos
{
    public interface IArchivo<T>
    {
        /// <summary>
        /// Firma de interfaz generica para guardar un archivo
        /// </summary>
        /// <param name="archivo"></param>
        /// <param name="datos"></param>
        /// <returns></returns> 
        bool Guardar(string archivo, T datos);
        /// <summary>
        /// Firma de interfaz generica para leer un archivo
        /// </summary>
        /// <param name="archivo"></param>
        /// <param name="datos"></param>
        /// <returns></returns> 
        bool Leer(string achivo, out T datos);

    }
}
