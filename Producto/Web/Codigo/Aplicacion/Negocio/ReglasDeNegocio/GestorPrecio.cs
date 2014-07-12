using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using ReglasDeNegocio.Util;
using Datos;

namespace ReglasDeNegocio
{
    public class GestorPrecio
    {
        IRepositorioDiaAtencion diaAtencionDao;
        IRepositorioTiempo tiempoDao;
        IRepositorioTipoVehiculo tipoVehiculoDao;
        IRepositorioPrecio precioDao;

        public GestorPrecio()
        {
            diaAtencionDao = new RepositorioDiaAtencion();
            tiempoDao = new RepositorioTiempo();
            tipoVehiculoDao = new RepositorioTipoVehiculo();
            precioDao = new RepositorioPrecio();
        }

        public GestorPrecio(IRepositorioDiaAtencion diaAtencionDao,
        IRepositorioTiempo tiempoDao,
        IRepositorioTipoVehiculo tipoVehiculoDao,
        IRepositorioPrecio precioDao)
        {
            this.precioDao = precioDao;
            this.tiempoDao = tiempoDao;
            this.tipoVehiculoDao = tipoVehiculoDao;
            this.diaAtencionDao = diaAtencionDao;
        }

        /// <summary>
        /// Busca un precio por su id
        /// </summary>
        /// <param name="idPrecio"></param>
        /// <returns></returns>
        public Precio BuscarPrecioPorId(int idPrecio)
        {
            return precioDao.FindById(idPrecio);
        }
        /// <summary>
        /// Busca un dia de atencion por su id
        /// </summary>
        /// <param name="IdDiaAtencionSeleccionado"></param>
        /// <returns></returns>
        public DiaAtencion BuscarDiaAtencionPorId(int IdDiaAtencionSeleccionado)
        {
            return diaAtencionDao.FindById(IdDiaAtencionSeleccionado);
        }
        /// <summary>
        /// Busca un tipo de vehiculo por su id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public TipoVehiculo BuscarTipoVehiculoPorId(int id)
        {
            return tipoVehiculoDao.FindById(id);
        }
        /// <summary>
        /// Busca un tiempo por  su id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Tiempo BuscarTiempoPorId(int id)
        {
            return tiempoDao.FindById(id);
        }
        /// <summary>
        /// Busca todos los tiempos
        /// </summary>
        /// <returns></returns>
        public IList<Tiempo> BuscarTiempos()
        {
            return tiempoDao.FindAll();
        }
        /// <summary>
        /// Busca todos los tipos de vehiculos
        /// </summary>
        /// <returns></returns>
        public IList<TipoVehiculo> BuscarTipoVehiculos()
        {
            return tipoVehiculoDao.FindAll();
        }
        /// <summary>
        /// Busca todos los dias de atencion
        /// </summary>
        /// <returns></returns>
        public IList<DiaAtencion> BuscarDiasDeAtencion()
        {
            return diaAtencionDao.FindAll();
        }
    }
}
