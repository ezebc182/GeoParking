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
        public void GetGuardarConsulta([FromUri]int idPlaya, [FromUri]int idTipoVehiculo, [FromUri]string latitud, [FromUri]string longitud)
        {
            gestor.GuardarConsulta(idPlaya, idTipoVehiculo, latitud, longitud);
        }
                      
    }
}
