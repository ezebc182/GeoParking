using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;
using Entidades;

namespace ReglasDeNegocio
{
    public class GestorEstadisticas
    {
        RepositorioEstadisticaConsultas estadisticaConsultasDao;
        IRepositorioPlayaDeEstacionamiento playaDao;

        public GestorEstadisticas()
        {
            estadisticaConsultasDao = new RepositorioEstadisticaConsultas();
            playaDao =  new RepositorioPlayaDeEstacionamiento();
        }

        public void GuardarConsulta(int idPlaya,int idTipoVehiculo,string latitud,string longitud)
        {
            EstadisticaConsultas consulta = new EstadisticaConsultas();
            consulta.Hora = DateTime.Now;
            PlayaDeEstacionamiento playa = playaDao.FindWhere(p =>p.Id == idPlaya)[0];
            consulta.IdTipoVehiculo = idTipoVehiculo;
            
            consulta.IdPlaya = idPlaya;
            consulta.IdTipoPlaya = (int)playa.TipoPlayaId;
            consulta.Latitud = latitud;
            consulta.Longitud = longitud;

            estadisticaConsultasDao.Create(consulta);
        }
        //private Ciudad getCiudad(string nombre)
        //{
        //    return ciudadDao.FindWhere(c => c.Nombre.Equals(nombre, StringComparison.OrdinalIgnoreCase)).FirstOrDefault();
        //}

        //public IList<EstadisticaDensidadDto> GetEstadisticasConsultasPorCiudad(String ciudadNombre, DateTime? desde, DateTime? hasta)
        //{
        //    var ciudadId = getCiudad(ciudadNombre).Id;
        //    return estadisticaConsultasDao.GetConsultasByCiudad(ciudadId, desde, hasta);
        //}

        //public IList<EstadisticaPorTipoVehiculoDto> GetEstadisticasPorCiudadYTipoVehiculo(String ciudadNombre, DateTime? desde, DateTime? hasta)
        //{
        //    var ciudadId = getCiudad(ciudadNombre).Id;
        //    return estadisticaConsultasDao.GetConsultasTipoVehiculoByCiudad(ciudadId, desde, hasta);
        //}

        //public IList<EstadisticaPorTipoPlayaDto> GetEstadisticasPorCiudadYTipoPlaya(String ciudadNombre, DateTime? desde, DateTime? hasta)
        //{
        //    var ciudadId = getCiudad(ciudadNombre).Id;
        //    return estadisticaConsultasDao.GetConsultasTipoPlayaByCiudad(ciudadId, desde, hasta);
        //}

        public IList<EstadisticaConsultas> GetEstadisticasConsultas()
        {
            return estadisticaConsultasDao.FindAll();
        }
    }
}
