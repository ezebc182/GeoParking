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
    public class GestorDireccion
    {
        IRepositorioDireccion direccionDao;

        public GestorDireccion()
        {
            direccionDao = new RepositorioDireccion();
        }

        public GestorDireccion(IRepositorioDireccion direccionDao)
        {
            this.direccionDao = direccionDao;            
        }

        /// <summary>
        /// Busca una direccion por su Id
        /// </summary>
        /// <param name="idDireccion"></param>
        /// <returns></returns>
        public Direccion BuscarDireccionPorId(int idDireccion)
        {
            var direccion = direccionDao.FindById(idDireccion);            
            return direccion;            
        }

        /// <summary>
        /// Busca todas las direcciones de una playa
        /// </summary>
        /// <param name="idPlaya"></param>
        /// <returns></returns>
        public IList<Direccion> BuscarDireccionesPorPlaya(int idPlaya)
        {
            var direcciones = direccionDao.FindWhere(d => d.PlayaDeEstacionamientoId == idPlaya);            
            return direcciones;
        }

        /// <summary>
        /// Busca todas las direcciones de una ciudad
        /// </summary>
        /// <param name="idPlaya"></param>
        /// <returns></returns>
        public IList<Direccion> BuscarDireccionesPorCiudad(string ciudad)
        {
            var direcciones = direccionDao.FindWhere(d => d.Ciudad.Equals(ciudad, StringComparison.OrdinalIgnoreCase));
            return direcciones;
        }

       
        public IList<Direccion> GetDireccionesDePlayasPorCiudadYTipoVehiculo(string ciudad, int tipoVehiculoId)
        {
            return direccionDao.GetDireccionesDePlayasPorCiudadYTipoVehiculo(ciudad, tipoVehiculoId);
        }
        public IList<Direccion> GetDireccionesDePlayasPorDistanciaYTipoVehiculo(string latitud, string longitud, int tipoVehiculoId)
        {
            return direccionDao.GetDireccionesPorDistanciaYTipoVehiculo(latitud, longitud, tipoVehiculoId);
        }
    }
}
