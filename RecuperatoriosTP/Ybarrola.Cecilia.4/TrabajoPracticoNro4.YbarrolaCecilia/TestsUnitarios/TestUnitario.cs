using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Productos;
using Excepciones;
using Archivos;

namespace TestsUnitarios
{
    /// <summary>
    /// USA TESTS UNITARIOS
    /// Clase que testea alguna de las funciones de la aplicacion
    /// </summary>
    [TestClass]
    public class TestUnitario
    {
        /// <summary>
        /// testea la igualacion, no se hace por id. Se espera que de false
        /// </summary>
        [TestMethod]
        public void TestoIgualacionCalzados_Fallo()
        {
            Calzado calzado1 = new Zapato(1, "Plataforma", 25, 9000, "Lola", "cuero");
            Calzado calzado2 = new Zapatilla(2, "UsoCotidiano", 25, 9000, "Lola", "cuero");

            bool respuesta = calzado1 == calzado2;

            Assert.IsFalse(respuesta);
        }
        /// <summary>
        /// Testea el correcto funcionamiento del lanzamiento PrecioErroneoException
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(PrecioErroneoException))]
        public void TestoLanzamientoPrecioErroneoException()
        {
            Zapatilla zapatilla;

            zapatilla = new Zapatilla(2, "UsoCotidiano", 25, -582, "Lola", "cuero");
        }
        /// <summary>
        /// Testea el correcto funcionamiento del lanzamiento ArchivosException
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArchivosException))]
        public void TestoLanzamientoArchivosException()
        {
            string path = "noEsUnArchivoExistente.txt";
            Texto texto = new Texto();

            texto.Leer(path, out path);

        }
    }
}
