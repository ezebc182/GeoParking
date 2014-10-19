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
            consulta.Ciudad = playa.Direcciones[0].CiudadId;
            consulta.IdPlaya = idPlaya;
            consulta.IdTipoPlaya = (int)playa.TipoPlayaId;
            consulta.latitud = latitud;
            consulta.longitud = longitud;

            estadisticaConsultasDao.Create(consulta);
        }

        public IList<EstadisticaConsultas> GetEstadisticasConsultas()
        {
            return estadisticaConsultasDao.FindAll();
        }
    }
}
