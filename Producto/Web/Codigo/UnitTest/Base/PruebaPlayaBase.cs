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
        IRepositorioCiudad ciudadDao;
        IRepositorioDepartamento departamentoDao;
        IRepositorioProvincia provinciaDao;

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
            ciudadDao = new RepositorioCiudadFalso();
            departamentoDao = new RepositorioDepartamentoFalso();
            provinciaDao = new RepositorioProvinciaFalso();
            gestorDireccion = new GestorDireccion(direccionDao, ciudadDao, departamentoDao, provinciaDao);
            gestor = new GestorPlaya(playaDao, tipoPlayaDao, diaAtencionDao, tipoVehiculoDao, horarioDao, servicioDao, precioDao, gestorDireccion);
            
        }
    }
}
