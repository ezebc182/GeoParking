using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ReglasDeNegocio;
using Entidades;

namespace WebServiceGeo.Controllers
{
    public class EstadisticasController : ApiController    {

        private static GestorEstadisticas gestor = new GestorEstadisticas();       

        // GET api/estadisticas
        public void PostGuardarConsulta([FromBody] PostConsultaEstadistica consulta)
        {
            gestor.GuardarConsulta(consulta.idPlaya, consulta.idTipoVehiculo, consulta.latitud, consulta.longitud);
        }
                      
    }

    public class PostConsultaEstadistica
    {
        public int idPlaya { get; set; }
        public int idTipoVehiculo { get; set; }
        public string latitud { get; set; }
        public string longitud { get; set; }
    }
    
}
