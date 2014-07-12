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
    public class GestorServicio
    {
        IRepositorioTipoVehiculo tipoVehiculoDao;
        IRepositorioServicio servicioDao;

        public GestorServicio()
        {
            tipoVehiculoDao = new RepositorioTipoVehiculo();
            servicioDao = new RepositorioServicio();
        }

        public GestorServicio(IRepositorioTipoVehiculo tipoVehiculoDao,
        IRepositorioServicio servicioDao)
        {
            this.servicioDao = servicioDao;
            this.tipoVehiculoDao = tipoVehiculoDao;
        }

        /// <summary>
        /// Busca un servicio por su id
        /// </summary>
        /// <param name="idServicio"></param>
        /// <returns></returns>
        public Servicio BuscarServicioPorId(int idServicio)
        {
            return servicioDao.FindById(idServicio);
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
        /// Busca todos los tipos de vehiculos
        /// </summary>
        /// <returns></returns>
        public IList<TipoVehiculo> BuscarTipoVehiculos()
        {
            return tipoVehiculoDao.FindAll();
        }

    }
}
