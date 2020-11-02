using System;
using ClasesInstanciables;
using Excepciones;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UTest
{
    [TestClass]
    public class UnitTest1
    {
        /// <summary>
        /// Prueba de igualdad que debera devolver false ya que son de distinto tipo
        /// </summary>
        [TestMethod]
        public void VerificarIgualdadUniversitarios_Fail()
        {
            //Arrange
            Profesor profesor = new Profesor(1, "Juan", "Perez", "43407010", ClasesAbstractas.Persona.ENacionalidad.Argentino);
            Alumno alumno = new Alumno(1, "Juan", "Perez", "43407010", ClasesAbstractas.Persona.ENacionalidad.Argentino, Universidad.EClases.Laboratorio);
            bool respuesta;
            //Act

            respuesta = profesor == alumno;
            //Assert
            Assert.IsFalse(respuesta);
        }
        /// <summary>
        /// Test que verifica el correcto lanzamiento de la excepcion DniInvalidoException
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(DniInvalidoException))]
        public void VerificarDNIString_DNIInvalidoExcepcion()
        {
            //Arrange
            Profesor profesor;
            //Act   
            profesor = new Profesor(1, "Juan", "Lopez", "43409999999999999999873",
                                    ClasesAbstractas.Persona.ENacionalidad.Argentino);
        }
        /// <summary>
        /// Test que verifica el correcto lanzamiento de la excepcion NacionalidadInvalidaException
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(NacionalidadInvalidaException))]
        public void VerificarDNIString_NacionalidadInvalidaExcepcion()
        {
            //Arrange
            Profesor profesor = new Profesor();
            //Act
            profesor.Nacionalidad = ClasesAbstractas.Persona.ENacionalidad.Extranjero;
            profesor.StringToDNI = "4340873";
        }
        /// <summary>
        /// Test que verifica que se instancie correctamente la lista de alumnos de la clase jornada
        /// </summary>
        [TestMethod]
        public void VerificarInstanciacionListaJornada()
        {
            //Arrange
            Jornada jornada;
            //Act
            jornada = new Jornada(Universidad.EClases.Laboratorio, 
                      new Profesor(1, "juana", "perez", "1000000", ClasesAbstractas.Persona.ENacionalidad.Argentino));
            //Assert
            Assert.IsNotNull(jornada.Alumnos);
        }
    }
}
