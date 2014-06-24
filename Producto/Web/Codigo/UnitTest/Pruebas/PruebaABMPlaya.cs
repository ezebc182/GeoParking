using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entidades;
using Repositorios;
using UnitTest.Base;

namespace UnitTest.Pruebas
{
    [TestClass]
    public class PruebaABMPlaya : PruebaPlayaBase
    {
        [TestMethod]
        public void BuscarPlayaPorIdPrueba()
        {
            //Busca la playa con ID = 1, si retorna un objeto pasa el test.
            PlayaDeEstacionamiento result = gestor.BuscarPlayaPorId(1);
            Assert.IsNotNull(result);
        }
    }
}
