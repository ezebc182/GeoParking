using Entidades;
using ReglasDeNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebServiceGeo.Controllers
{
    public class PlayasController : ApiController
    {
        private static GestorBusquedaPlayas gestor = new GestorBusquedaPlayas();

        // GET api/playas
        public string Get()
        {
            //busco en la BD
            IList<PlayaDeEstacionamiento> playas = new List<PlayaDeEstacionamiento>();
            playas = (List<PlayaDeEstacionamiento>)gestor.buscarPlayasPorCiudad("Cordoba");
            
            string json = "[";

            foreach (var p in playas)
            {
                json += p.ToJSONRepresentation() + ",";
            }

            if (playas.Count != 0)
            {
                json = json.Substring(0, json.Length - 1);
            }
            json += "]";

            return json;            
            
        }

        // GET api/playas/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/playas
        public void Post([FromBody]string value)
        {
        }

        // PUT api/playas/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/playas/5
        public void Delete(int id)
        {
        }
    }
}
