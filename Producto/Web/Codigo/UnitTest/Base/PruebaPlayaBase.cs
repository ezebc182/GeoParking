using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Datos;
using ReglasDeNegocio;
using Repositorios;

namespace UnitTest.Base
{
    public class PruebaPlayaBase
    {
        public IRepositorioPlayaDeEstacionamiento repositorioPlayas;
        public IRepositorioTipoDePlaya repositorioTipoPlayas;
        public GestorPlaya gestor;

        public PruebaPlayaBase()
        {
            repositorioPlayas = new RepositorioPlayasFalso();
            repositorioTipoPlayas = new RepositorioTipoPlayasFalso();
            gestor = new GestorPlaya(repositorioPlayas, repositorioTipoPlayas);
        }
    }
}
