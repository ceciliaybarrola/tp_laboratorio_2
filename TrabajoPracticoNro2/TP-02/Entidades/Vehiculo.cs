using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    /// <summary>
    /// La clase Vehiculo no deberá permitir que se instancien elementos de este tipo.
    /// </summary>
    public abstract class Vehiculo
    {
        EMarca marca;
        string chasis;
        ConsoleColor color;

        #region Enumerados
        public enum EMarca
        {
            Chevrolet, 
            Ford, 
            Renault, 
            Toyota, 
            BMW, 
            Honda, 
            HarleyDavidson
        }
        public enum ETamanio
        {
            Chico, 
            Mediano, 
            Grande
        }
        #endregion
        /// <summary>
        /// ReadOnly: Retornará el tamaño
        /// </summary>
        protected abstract ETamanio Tamanio
        {
            get;
        }

        /// <summary>
        /// Constuctor base
        /// </summary>
        /// <param name="chasis"></param>
        /// <param name="marca"></param>
        /// <param name="color"></param>
        public Vehiculo(string chasis, EMarca marca, ConsoleColor color)
        {
            this.chasis = chasis;
            this.marca = marca;
            this.color = color;
        }

        /// <summary>
        /// Publica todos los datos del Vehiculo.
        /// </summary>
        /// <returns></returns>
        public virtual string Mostrar()
        {
            return (string)this;
        }

        #region Sobrecarga de operadores
        /// <summary>
        /// Sobrecarga explicit del string encargado de convertir a string 
        /// todos los datos base del vehiculo que reciba
        /// </summary>
        /// <param name="p"></param>
        public static explicit operator string(Vehiculo p)
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendFormat("CHASIS: {0}\r\n", p.chasis);
            stringBuilder.AppendFormat("MARCA : {0}\r\n", p.marca.ToString());
            stringBuilder.AppendFormat("COLOR : {0}\r\n", p.color.ToString());
            stringBuilder.AppendLine("---------------------\n");
            stringBuilder.AppendFormat("TAMAÑO : {0}", p.Tamanio);
            return stringBuilder.ToString();
        }

        /// <summary>
        /// Dos vehiculos son iguales si comparten el mismo chasis
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns></returns>
        public static bool operator ==(Vehiculo v1, Vehiculo v2)
        {
            return v1.chasis == v2.chasis;
        }
        /// <summary>
        /// Dos vehiculos son distintos si su chasis es distinto
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns></returns>
        public static bool operator !=(Vehiculo v1, Vehiculo v2)
        {
            return !(v1 == v2);
        }
#endregion
    }
}
