using ReglasDeNegocio;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;
using System.IO;
using System.Data;

namespace WebServiceGeo.Controllers
{
    public class PlayasController : ApiController
    {
        private static GestorBusquedaPlayas gestor = new GestorBusquedaPlayas();
        private static GestorTiposVehiculo gestorTipoVehiculos = new GestorTiposVehiculo();
        private static GestorDireccion gestorDirecciones = new GestorDireccion();
        private static GestorPrecio gestorPrecio = new GestorPrecio();
        // GET api/Playas/GetPlayas?ciudad=cordoba
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

        /**
         * Obtiene solo las ubicaciones de las playas para cargar los puntos en los mapas
         * ej. api/Playas/GetUbicacionesPlayas?ciudad=cordoba&tipoVehiculoId=1
         */
        public string GetUbicacionesPlayas([FromUri] string ciudad, [FromUri] string tipoVehiculoId)
        {
            string json = "[";
            int tipoVehiculo = Int32.Parse(tipoVehiculoId);
            IList<Direccion> direcciones = new List<Direccion>();
            direcciones = (IList<Direccion>)gestorDirecciones.GetDireccionesDePlayasPorCiudadYTipoVehiculo(ciudad,tipoVehiculo);
            foreach (var p in direcciones)
            {
                json += p.GetUbicacionesToJSONRepresentation() + ",";
            }
            if (direcciones.Count > 0)
            {
                json = json.Substring(0, json.Length - 1);
            }
            json += "]";
            return json;
        }
        /**
         * Obtiene los precios de las playas selecionadas para el tipo de vehiculo seleccionado
         * ej. api/Playas/GetPreciosPlayas?tipoVehiculoId=1&idPlayas=1,2,3,5
         */
        public string GetPreciosPlayas([FromUri] string tipoVehiculoId, [FromUri] string idPlayas)
        {
            int tipoVehiculo = int.Parse(tipoVehiculoId);
            IList<Precio> precios = new List<Precio>();
            precios = (List<Precio>)gestorPrecio.GetPreciosDePlayasPorTipoVehiculoEIdPlayas(idPlayas, tipoVehiculo);
            string json = "[";
            foreach (var item in precios)
            {
                json += item.GetPreciosConIdPlayasComoJSON() + ",";
            }
            if (precios.Count > 0)
            {
                json = json.Substring(0, json.Length - 1);
            }
            json += "]";
            return json;
        }
    }
}
