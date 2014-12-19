using ReglasDeNegocio;
using Entidades;
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
        private static GestorTiposVehiculo gestorTipoVehiculos = new GestorTiposVehiculo();
        // GET api/Playas/GetPlayas/cordoba
        public string GetPlayas([FromUri] String ciudad)
        {
            //busco en la BD
            IList<PlayaDeEstacionamiento> playas = new List<PlayaDeEstacionamiento>();
            playas = (IList<PlayaDeEstacionamiento>)gestor.buscarPlayasPorCiudad(ciudad);
            
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
        //api/Playas/GetTiposVehiculos
        public string GetTiposVehiculo()
        {
            string json = "[";
            IList<TipoVehiculo> lista = gestorTipoVehiculos.ObtenerTiposDeVehiculo();
            foreach (TipoVehiculo item in lista)
            {
                json += item.ToJSONRepresentation();
                json += ",";
            }
            if (lista.Count != 0)
            {
                json = json.Substring(0, json.Length - 1);
            }
            json += "]";
            return json;

        }

        // GET api/playas/5
        public string Get(int id)
        {
            //busco en la BD
            PlayaDeEstacionamiento playas = new PlayaDeEstacionamiento();
            playas = gestor.buscarPlayaPorId(id);

            return playas.ToJSONRepresentation();
            
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
