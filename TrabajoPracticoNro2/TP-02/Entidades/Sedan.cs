using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;

namespace Entidades
{
    public class Sedan : Vehiculo
    {
        private ETipo tipo;
        public enum ETipo 
        { 
            CuatroPuertas, 
            CincoPuertas 
        }
        #region Constructores
        /// <summary>
        /// Por defecto, TIPO será Monovolumen
        /// </summary>
        /// <param name="marca"></param>
        /// <param name="chasis"></param>
        /// <param name="color"></param>
        public Sedan(EMarca marca, string chasis, ConsoleColor color)
            : this (marca, chasis, color, ETipo.CuatroPuertas)
        {
        }
        /// <summary>
        /// Constructor que recibe todos los parametros y llama al base
        /// </summary>
        /// <param name="marca"></param>
        /// <param name="chasis"></param>
        /// <param name="color"></param>
        /// <param name="tipo"></param>
        public Sedan(EMarca marca, string chasis, ConsoleColor color, ETipo tipo)
            : base(chasis, marca, color)
        {
            this.tipo = tipo;
        }
        #endregion


        /// <summary>
        /// Los automoviles son medianos
        /// </summary>
        protected override ETamanio Tamanio
        {
            get
            {
                return ETamanio.Mediano;
            }
        }

        /// <summary>
        /// Polimorfismo del metodo mostrar del base, muestra los datos propios de
        /// la sedan junto a los datos heredados
        /// </summary>
        /// <returns></returns>
        public override sealed string Mostrar()
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendLine("SEDAN");
            stringBuilder.AppendFormat("{0}\nTIPO : {1}\n\n", base.Mostrar(), this.tipo);
            stringBuilder.AppendLine("---------------------");

            return stringBuilder.ToString();
        }
    }
}
