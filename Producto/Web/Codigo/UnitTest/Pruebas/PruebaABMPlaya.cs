using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entidades;

namespace UnitTest.Pruebas
{
    [TestClass]
    public class PruebaABMPlaya : PruebaPlayaBase
    {
        [TestMethod]
        public void BuscarPlayaPorIPrueba()
        {
            //Busca la playa con ID = 1, si retorna un objeto pasa el test.
            PlayaDeEstacionamiento result = gestor.BuscarPlayaPorId(1);
            Assert.IsNotNull(result);
        }
    }
}
