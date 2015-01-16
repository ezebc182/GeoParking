using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ReglasDeNegocio;

namespace WebServiceGeo.Controllers
{
    public class ServiciosController : ApiController
    {
        GestorServicio gestor = new GestorServicio();

        // GET api/servicios
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        /// <summary>
        /// cancela o da de baja el servicio
        /// </summary>
        /// <param name="idPlaya">id de la playa</param>
        /// <param name="idTipoVechiculo">id del tipo de vehiculo</param>
        /// <returns>'True' si la operacion se realizo correctamente</returns>
        public string GetCancelarServicio([FromUri]int idPlaya, [FromUri]int idTipoVehiculo)
        {
            return gestor.CancelarServicioPlaya(idPlaya, idTipoVehiculo).Ok.ToString();
        }

        /// <summary>
        /// registra un nuevo servicio de la playa
        /// </summary>
        /// <param name="idPlaya">id de la playa</param>
        /// <param name="idTipoVechiculo">id del tipo de vehiculo</param>
        /// <param name="capacidad">capacidad(lugares para el tipo de vehiculo)</param>
        /// <param name="x1">precio por hora</param>
        /// <param name="x6">precio por 6 horas</param>
        /// <param name="x12">precio por 12 horas</param>
        /// <param name="x24">precio por 24 horas</param>
        /// <param name="abono">precio por mes</param>
        /// <returns></returns>
        public string GetRegistrarServicio([FromUri]int idPlaya, [FromUri]int idTipoVehiculo, [FromUri]int capacidad, [FromUri]double x1, [FromUri]double x6, [FromUri]double x12, [FromUri]double x24, [FromUri]double abono)
        {
            return gestor.RegistrarServicioPlaya( idPlaya,  idTipoVehiculo,  capacidad,  x1, x6, x12, x24, abono).Ok.ToString();
        }

        /// <summary>
        /// actualiza la capacidad de un servicio
        /// </summary>
        /// <param name="idPlaya">id de la playa</param>
        /// <param name="idTipoVechiculo">id del tipo de vehiculo del servicio</param>
        /// <param name="capacidad">capacidad</param>
        /// <returns>'True' si la operacion se realizo correctamente</returns>
        public string GetActualizarCapacidadServicio([FromUri]int idPlaya, [FromUri]int idTipoVechiculo, [FromUri]int capacidad)
        {
            return gestor.ActualizarCapacidadServicio(idPlaya, idTipoVechiculo, capacidad).Ok.ToString();
        }
        
        // GET api/servicios/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/servicios
        public void Post([FromBody]string value)
        {
        }

        // PUT api/servicios/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/servicios/5
        public void Delete(int id)
        {
        }
    }
}
