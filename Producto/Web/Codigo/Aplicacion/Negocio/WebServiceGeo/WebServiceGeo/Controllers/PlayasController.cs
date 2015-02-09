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
        private static GestorPlaya gestorPlaya = new GestorPlaya();
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

        public string GetUbicacionesPlayasPorDistancia([FromUri] string latitud, [FromUri] string longitud, [FromUri] int tipoVehiculoId)
        {
            string json = "[";
            IList<Direccion> direcciones = new List<Direccion>();
            direcciones = (IList<Direccion>)gestorDirecciones.GetDireccionesDePlayasPorDistanciaYTipoVehiculo(latitud, longitud, tipoVehiculoId);
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
    
        /// <summary>
        /// Actualiza el tipo de la playa
        /// </summary>
        /// <param name="playa">Objeto playa del controlador</param>
        /// <returns>'True' si la operacion se realizo correctamente</returns>
        public string PostActualizarTipoPlaya([FromBody]PlayaControlador playa)
        {
            return gestorPlaya.ActualizarTipoPlaya(playa.IdPlaya, playa.TipoPlayaId).Ok.ToString();
        }
               
        /// <summary>
        /// Actuliza nombre y email de la playa
        /// </summary>
        /// <param name="playa">Objeto playa del controlador</param>
        /// <returns>'True' si la operacion se realizo correctamente</returns>
        public string PostActualizarNombreEmailPlaya([FromBody]PlayaControlador playa)
        {
            return gestorPlaya.ActualizarNombreEmailPlaya(playa.IdPlaya, playa.Nombre, playa.Mail).Ok.ToString();
        }

        /// <summary>
        /// Actualiza el horario de la playa
        /// </summary>
        /// <param name="playa">Objeto playa del controlador</param>
        /// <returns>'True' si la operacion se realizo correctamente</returns>
        public string PostActualizarHorarioPlaya([FromBody]PlayaControlador playa)
        {
            return gestorPlaya.ActualizarHorarioPlaya(playa.IdPlaya, playa.DiaAtencionId, playa.HoraDesde, playa.HoraHasta).Ok.ToString();
        }
        
    }

    /// <summary>
    /// Objeto que se genera a partir de los datos obtenidos por la peticion
    /// </summary>
    public class PlayaControlador
    {
        public int IdPlaya { get; set; }
        public string Nombre { get; set; }
        public string Mail { get; set; }        
        public int TipoPlayaId { get; set; }
        public int DiaAtencionId { get; set; }
        public string HoraDesde { get; set; }
        public string HoraHasta { get; set; }
    }

    public class BusquedaPorCoordenadas
    {
        public string latitud { get; set; }
        public string longitud { get; set; }
        public int tipoVehiculoId { get; set; }

    }
}
