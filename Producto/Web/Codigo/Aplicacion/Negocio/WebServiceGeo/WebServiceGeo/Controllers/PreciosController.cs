using ReglasDeNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebServiceGeo.Controllers
{
    public class PreciosController : ApiController
    {

        private GestorPrecio gestor = new GestorPrecio();

        // GET api/precios
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }       
        
       
        /// <summary>
        /// Actualiza el precio para un tiempo de estacionamiento de un tipo
        /// de vehiculo de una playa
        /// </summary>
        /// <param name="idPlaya"></param>
        /// <param name="idTiempo"></param>
        /// <param name="idTipoVehiculo"></param>
        /// <param name="precio"></param>
        /// <returns>'True' si la accion se concreto</returns>
        public string GetActualizarPrecio([FromUri]int idPlaya, [FromUri]int idTiempo, [FromUri]int idTipoVehiculo, [FromUri] double precio)
        {
            return gestor.ActualizarPrecioPlaya(idPlaya, idTiempo, idTipoVehiculo, precio).Ok.ToString();
        }

        public string GetRegistrarPrecio([FromUri]int idPlaya, [FromUri]int idTiempo, [FromUri]int idTipoVehiculo, [FromUri] double precio)
        {
            return gestor.RegistrarPrecioPlaya(idPlaya, idTiempo, idTipoVehiculo, precio).Ok.ToString();
        }

        // GET api/precios/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/precios
        public void Post([FromBody]string value)
        {
        }

        // PUT api/precios/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/precios/5
        public void Delete(int id)
        {
        }
    }
}
