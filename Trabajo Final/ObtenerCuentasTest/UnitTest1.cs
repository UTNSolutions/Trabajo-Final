using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Trabajo_Final.Controladores;

namespace ObtenerCuentasTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Assert.AreEqual(2,Fachada.Instancia.ObtenerCuentas().Count);
        }
    }
}
