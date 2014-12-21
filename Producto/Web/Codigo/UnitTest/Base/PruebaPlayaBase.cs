using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Datos;
using ReglasDeNegocio;
using Repositorios;

namespace UnitTest.Base
{
    public class PruebaPlayaBase
    {
        IRepositorioPlayaDeEstacionamiento playaDao;
        IRepositorioTipoDePlaya tipoPlayaDao;
        IRepositorioDiaAtencion diaAtencionDao;
        IRepositorioTipoVehiculo tipoVehiculoDao;
        IRepositorioHorario horarioDao;
        IRepositorioServicio servicioDao;
        IRepositorioPrecio precioDao;
        IRepositorioDireccion direccionDao;
       

        public GestorPlaya gestor;
        public GestorDireccion gestorDireccion;
        public PruebaPlayaBase()
        {
            playaDao = new RepositorioPlayasFalso();
            tipoPlayaDao = new RepositorioTipoPlayasFalso();
            diaAtencionDao = new RepositorioDiaAtencionFalso();
            tipoVehiculoDao = new RepositorioTipoVehiculoFalso();
            horarioDao = new RepositorioHorarioFalso();
            servicioDao = new RepositorioServicioFalso();
            precioDao = new RepositorioPrecioFalso();
            direccionDao = new RepositorioDireccionFalso();
            gestorDireccion = new GestorDireccion(direccionDao);
            gestor = new GestorPlaya(playaDao, tipoPlayaDao, diaAtencionDao, tipoVehiculoDao, horarioDao, servicioDao, precioDao, gestorDireccion);
            
        }
    }
}
