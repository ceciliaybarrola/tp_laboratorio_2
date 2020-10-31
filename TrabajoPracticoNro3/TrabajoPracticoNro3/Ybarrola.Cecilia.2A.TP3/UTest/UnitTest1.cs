using System;
using ClasesInstanciables;
using Excepciones;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UTest
{
    [TestClass]
    public class UnitTest1
    {
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
        [TestMethod]
        public void VerificarIgualdadUniversitarios_Null()
        {
            //Arrange
            Profesor profesor= null;
            Alumno alumno= null;
            bool respuesta;
            //Act
            respuesta = profesor == alumno;
            //Assert
            Assert.IsFalse(respuesta);
        }

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
