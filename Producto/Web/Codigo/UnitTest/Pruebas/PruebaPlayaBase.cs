using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Datos;
using ReglasDeNegocio;
using UnitTest.Repositorios;

namespace UnitTest.Pruebas
{
    public class PruebaPlayaBase
    {
        public IRepositorioPlayaDeEstacionamiento repositorioPlayas;
        public IRepositorioTipoDePlaya repositorioTipoPlayas;
        public GestorABMPlaya gestor;

        public PruebaPlayaBase()
        {
            repositorioPlayas = new RepositorioPlayasFalso();
            repositorioTipoPlayas = new RepositorioTipoPlayasFalso();
            gestor = new GestorABMPlaya(repositorioPlayas, repositorioTipoPlayas);
        }
    }
}
