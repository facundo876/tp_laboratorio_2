using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EntidadesAbstractas;
using ClasesInstanciables;
using Excepciones;

namespace TestTPN3
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMetodoValidarStringDNI()
        {
            int esperado = 12234456;

            Alumno a1 = new Alumno(1, "Juan", "Lopez", "12234456", EntidadesAbstractas.Persona.ENacionalidad.Argentino, Universidad.EClases.Programacion, Alumno.EEstadoCuenta.Becado);
           
            Assert.AreEqual(esperado, a1.DNI);
        }

        [TestMethod]
        [ExpectedException(typeof(NacionalidadInvalidaException))]
        public void TestNacionalidadInvalidaExceptionMetodoVlidarDNI()
        {
           

            Alumno a1 = new Alumno(1, "Juan", "Lopez", "99999999", EntidadesAbstractas.Persona.ENacionalidad.Argentino, Universidad.EClases.Programacion, Alumno.EEstadoCuenta.Becado);

        }

        [TestMethod]
        [ExpectedException(typeof(DniInvalidoException))]
        public void TestDniInvalidoExceptionMetodoVlidarDNI()
        {


            Alumno a1 = new Alumno(1, "Juan", "Lopez", "A12234456", EntidadesAbstractas.Persona.ENacionalidad.Argentino, Universidad.EClases.Programacion, Alumno.EEstadoCuenta.Becado);

        }

        [TestMethod]
        public void TestMetodoValidarNombreYAperllido()
        {
            string NombreEsperado = "Juan";
            string ApellidoEsperado = "Lopez";

            Alumno a1 = new Alumno(1, "Juan", "Lopez", "12234456", EntidadesAbstractas.Persona.ENacionalidad.Argentino, Universidad.EClases.Programacion, Alumno.EEstadoCuenta.Becado);

            Assert.AreEqual(NombreEsperado, a1.Nombre);
            Assert.AreEqual(ApellidoEsperado, a1.Apellido);
        }

        [TestMethod]
        public void TestValidaAtributosDeClaseNull()
        {
            Profesor profesor = new Profesor(2, "Roberto", "Juarez", "32234456", EntidadesAbstractas.Persona.ENacionalidad.Argentino);

            Assert.IsNotNull(profesor.Nombre);
            Assert.IsNotNull(profesor.Apellido);
            Assert.IsNotNull(profesor.Nacionalidad);

        }
    }


}
