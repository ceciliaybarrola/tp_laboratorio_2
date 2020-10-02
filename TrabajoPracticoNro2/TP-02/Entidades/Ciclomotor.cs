using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
     public class Ciclomotor : Vehiculo
    {
        public Ciclomotor(EMarca marca, string chasis, ConsoleColor color): base(chasis, marca, color)
        {
        }

        /// <summary>
        /// Las motos son chicas
        /// </summary>
        protected override ETamanio Tamanio
        {
            get
            {
                return ETamanio.Chico;
            }
        }

        /// <summary>
        /// Polimorfismo del metodo mostrar del base, muestra los datos propios del 
        /// ciclomotor junto a los datos heredados
        /// </summary>
        /// <returns></returns>
        public override sealed string Mostrar()
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendLine("CICLOMOTOR");
            stringBuilder.AppendFormat("{0}\n\n", base.Mostrar());
            stringBuilder.AppendLine("---------------------");

            return stringBuilder.ToString();
        }
    }
}
