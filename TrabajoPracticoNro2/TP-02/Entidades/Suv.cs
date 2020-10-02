using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Suv : Vehiculo
    {
        /// <summary>
        /// Unico constructor que inicializa los datos heredados
        /// </summary>
        /// <param name="marca"></param>
        /// <param name="chasis"></param>
        /// <param name="color"></param>
        public Suv(EMarca marca, string chasis, ConsoleColor color)
            : base(chasis, marca, color)
        {
        }
        /// <summary>
        /// Las camionetas son medianas
        /// </summary>
        protected override ETamanio Tamanio
        {
            get
            {
                return ETamanio.Mediano;
            }
        }

        /// <summary>
        /// Polimorfismo del metodo mostrar del base, muestra los datos propios de la 
        /// SUV junto a los datos heredados
        /// </summary>
        /// <returns></returns>
        public override sealed string Mostrar()
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendLine("SUV");
            stringBuilder.AppendFormat("{0}\n\n", base.Mostrar());
            stringBuilder.AppendLine("---------------------");

            return stringBuilder.ToString();
        }
    }
}
