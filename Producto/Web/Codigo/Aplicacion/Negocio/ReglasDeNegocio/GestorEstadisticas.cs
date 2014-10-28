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
        IRepositorioEstadisticaConsultas estadisticaConsultasDao;
        IRepositorioPlayaDeEstacionamiento playaDao;
        IRepositorioCiudad ciudadDao;

        public GestorEstadisticas()
        {
            ciudadDao = new RepositorioCiudad();
            estadisticaConsultasDao = new RepositorioEstadisticaConsultas();
            playaDao =  new RepositorioPlayaDeEstacionamiento();
        }

        public void GuardarConsulta(int idPlaya,int idTipoVehiculo,string latitud,string longitud)
        {
            EstadisticaConsultas consulta = new EstadisticaConsultas();
            consulta.Hora = DateTime.Now;
            PlayaDeEstacionamiento playa = playaDao.FindWhere(p =>p.Id == idPlaya)[0];
            consulta.IdTipoVehiculo = idTipoVehiculo;
            consulta.Ciudad = playa.Direcciones[0].CiudadId;
            consulta.IdPlaya = idPlaya;
            consulta.IdTipoPlaya = (int)playa.TipoPlayaId;
            consulta.Latitud = latitud;
            consulta.Longitud = longitud;

            estadisticaConsultasDao.Create(consulta);
        }
        private Ciudad getCiudad(string nombre)
        {
            return ciudadDao.FindWhere(c => c.Nombre.Equals(nombre, StringComparison.OrdinalIgnoreCase)).FirstOrDefault();
        }
        public IList<EstadisticaConsultas> GetEstadisticasConsultasPorCiudad(String ciudadNombre)
        {
            var ciudadId = getCiudad(ciudadNombre).Id;
            return estadisticaConsultasDao.FindWhere(e => e.Ciudad == ciudadId);
        }

        public IList<EstadisticaConsultas> GetEstadisticasPorCiudadYTipoVehiculo(string ciudadNombre, int idTipoVehiculo)
        {
            return estadisticaConsultasDao.FindWhere(e => e.Ciudad == getCiudad(ciudadNombre).Id && e.IdTipoVehiculo == idTipoVehiculo);
        }

        public IList<EstadisticaConsultas> GetEstadisticasConsultas()
        {
            return estadisticaConsultasDao.FindAll();
        }
    }
}
