using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;
using Entidades;
using System.Data.Entity.Spatial;
using Newtonsoft.Json;

namespace ReglasDeNegocio
{
    public class GestorEstadisticas
    {
        RepositorioEstadisticaConsultas estadisticaConsultasDao;
        RepositorioDisponibilidadPlayas disponibilidadPlayasDao;
        IRepositorioPlayaDeEstacionamiento playaDao;

        public GestorEstadisticas()
        {
            estadisticaConsultasDao = new RepositorioEstadisticaConsultas();
            disponibilidadPlayasDao = new RepositorioDisponibilidadPlayas();
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
            consulta.Posicion = DbGeography.FromText(string.Format("POINT({0} {1})", longitud, latitud));

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


        //public IList<EstadisticaDisponibilidadDto> DisponibilidadesUltimoMinutoPorPlayas(string ciudad, Usuario usuario)
        //{

        //}


        //public IList<EstadisticaDisponibilidadDto> DisponibilidadesUltimoMinutoPorZonas(string ciudad, Usuario usuario)
        //{

        //}

        //public IList<EstadisticaDisponibilidadDto> DisponibilidadesPorZonas(string ciudad, Usuario usuario, DateTime desde, DateTime hasta)
        //{

        //}

        public IList<EstadisticaDisponibilidadDto> GetDisponibilidades(string ciudad, int usuarioId, int buscarPor, DateTime? desde, DateTime? hasta)
        {
            return disponibilidadPlayasDao.GetDisponibilidades(ciudad, usuarioId, buscarPor, desde, hasta);
        }

        public string GetDisponibilidadesJSON(string ciudad, int usuarioId, int buscarPor, DateTime? desde, DateTime? hasta)
        {
            return JsonConvert.SerializeObject(GetDisponibilidades(ciudad, usuarioId, buscarPor, desde, hasta));
        }

        
        public IList<EstadisticaConsultasDto> ConsultasUltimoMinutoPorPlayas(string ciudad, int usuarioId)
        {
            var desde = DateTime.Now.Subtract(new TimeSpan(0, 1, 0));
            var hasta = DateTime.Now;
            return estadisticaConsultasDao.GetConsultas(ciudad, usuarioId, 1, desde, hasta);
        }

        public IList<EstadisticaConsultasDto> ConsultasPorPlayas(string ciudad, int usuarioId, DateTime? desde, DateTime? hasta)
        {
            return estadisticaConsultasDao.GetConsultas(ciudad, usuarioId, 1, desde, hasta);
        }

        public string ConsultasPorPlayasJSON(string ciudad, int usuarioId, DateTime? desde, DateTime? hasta)
        {
            return JsonConvert.SerializeObject(ConsultasPorPlayas(ciudad, usuarioId, desde, hasta));
        }

        public IList<EstadisticaConsultasDto> ConsultasUltimoMinutoPorZonas(string ciudad, int usuarioId)
        {
            var desde = DateTime.Now.Subtract(new TimeSpan(0, 1, 0));
            var hasta = DateTime.Now;
            return estadisticaConsultasDao.GetConsultas(ciudad, usuarioId, 2, desde, hasta);
        }

        public IList<EstadisticaConsultasDto> ConsultasPorZonas(string ciudad, int usuarioId, DateTime? desde, DateTime? hasta)
        {
            return estadisticaConsultasDao.GetConsultas(ciudad, usuarioId, 2, desde, hasta);
        }

        public string ConsultasPorZonasJSON(string ciudad, int usuarioId, DateTime? desde, DateTime? hasta)
        {
            return JsonConvert.SerializeObject(ConsultasPorZonas(ciudad, usuarioId, desde, hasta));
        }

        public IList<EstadisticaConsultas> GetEstadisticasConsultas()
        {
            return estadisticaConsultasDao.FindAll();
        }
    }
}
