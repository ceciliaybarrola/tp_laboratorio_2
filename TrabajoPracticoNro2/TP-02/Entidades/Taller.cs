using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    /// <summary>
    /// No podrá tener clases heredadas.
    /// </summary>
    sealed public class Taller
    {
        List<Vehiculo> vehiculos;
        private int espacioDisponible;
        public enum ETipo
        {
            Ciclomotor, 
            Automovil,
            Sedan, 
            SUV, 
            Todos
        }

        #region "Constructores"

        /// <summary>
        /// Constructor por defecto privado, encargado de instanciar la lista 
        /// </summary>
        private Taller()
        {
            this.vehiculos = new List<Vehiculo>();
        }
        /// <summary>
        /// Constructor publico parametrizado
        /// </summary>
        /// <param name="espacioDisponible"></param>
        public Taller(int espacioDisponible) : this()
        {
            this.espacioDisponible = espacioDisponible;
        }
        #endregion

        #region "Sobrecargas"
        /// <summary>
        /// Muestro el estacionamiento y TODOS los vehículos
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return Taller.Listar(this, ETipo.Todos);
        }
        #endregion

        #region "Métodos"

        /// <summary>
        /// Expone los datos del elemento y su lista (incluidas sus herencias)
        /// SOLO del tipo requerido
        /// </summary>
        /// <param name="taller">Elemento a exponer</param>
        /// <param name="ETipo">Tipos de ítems de la lista a mostrar</param>
        /// <returns></returns>
        public static string Listar(Taller taller, ETipo tipo)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("Tenemos {0} lugares ocupados de un total de {1} disponibles\n", taller.vehiculos.Count, taller.espacioDisponible);

            foreach (Vehiculo item in taller.vehiculos)
            {

                switch (tipo)
                {
                    case ETipo.Ciclomotor:
                        if (item is Ciclomotor)
                        {
                            sb.AppendLine(item.Mostrar());
                        }
                        break;
                    case ETipo.Sedan:
                        if (item is Sedan)
                        {
                            sb.AppendLine(item.Mostrar());
                        }
                        break;
                    case ETipo.SUV:
                        if (item is Suv)
                        {
                            sb.AppendLine(item.Mostrar());
                        }
                        break;
                    default:
                        sb.AppendLine(item.Mostrar());
                        break;
                }
            }

            return sb.ToString();
        }
        #endregion

        #region "Operadores"
        /// <summary>
        /// Agregará un elemento a la lista
        /// </summary>
        /// <param name="taller">Objeto donde se agregará el elemento</param>
        /// <param name="vehiculo">Objeto a agregar</param>
        /// <returns></returns>
        public static Taller operator +(Taller taller, Vehiculo vehiculo)
        {
            if(taller.espacioDisponible > taller.vehiculos.Count )
            {
                foreach (Vehiculo item in taller.vehiculos)
                {
                    if (item == vehiculo)
                    {
                        return taller;
                    }
                    
                }
                taller.vehiculos.Add(vehiculo);
            }
            return taller;
        }
        /// <summary>
        /// Quitará un elemento de la lista
        /// </summary>
        /// <param name="taller">Objeto donde se quitará el elemento</param>
        /// <param name="vehiculo">Objeto a quitar</param>
        /// <returns></returns>
        public static Taller operator -(Taller taller, Vehiculo vehiculo)
        {
            foreach (Vehiculo item in taller.vehiculos)
            {
                if (item == vehiculo)
                {
                    taller.vehiculos.Remove(item);
                    break;
                }
            }
            return taller;
        }
        #endregion
    }
}
