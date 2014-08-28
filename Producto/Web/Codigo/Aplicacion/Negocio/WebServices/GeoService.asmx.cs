﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using Entidades;
using ReglasDeNegocio;
using System.Web.Script.Serialization;


namespace WebServices
{
    /// <summary>
    /// Descripción breve de Service1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class Service1 : System.Web.Services.WebService
    {
        private static GestorBusquedaPlayas gestor = new GestorBusquedaPlayas();        
        
        /// <summary>
        /// Obtiene las playas de estacionamiento de la cudad seleccionada
        /// </summary>
        /// <param name="ciudad">ciudad filtro</param>
        /// <returns>playas de estacionamiento ubicadas en esa ciudad</returns>
        [WebMethod]
        public string ObtenerPlayasDeCiudad(string ciudad)
        {
            //busco en la BD
            IList<PlayaDeEstacionamiento> playas = new List<PlayaDeEstacionamiento>();
            playas = (List<PlayaDeEstacionamiento>)gestor.buscarPlayasPorCiudad(ciudad);

            string json = "[";

            foreach (var p in playas)
            {
                json += p.ToJSONRepresentation() + ",";
            }

            json = json.Substring(0, json.Length - 1);
            json += "]";

            return json;
           
        }

        /// <summary>
        /// Busco la playas en la BD que cumplan con los filtros
        /// </summary>
        /// <param name="tipoPlaya">tipo de playa</param>
        /// <param name="tipoVehiculo"> el tipo de vehiculo</param>
        /// <param name="diaAtencion">dia de atencion</param>
        /// <param name="precioDesde">precio base</param>
        /// <param name="precioHasta">precio maximo</param>
        /// <param name="horaDesde">hora de apertura</param>
        /// <param name="horaHasta">hora de cierre</param>
        /// <returns>lista de playas filtradas</returns>
        [WebMethod]
        public string ObtenerPlayasDeCiudadPorFiltro(string ciudad,int tipoPlaya, int tipoVehiculo, int diaAtencion, string precioDesde, string precioHasta, int horaDesde, int horaHasta)
        {
            //busco en la BD
            IList<PlayaDeEstacionamiento> playas = new List<PlayaDeEstacionamiento>();

            playas = (List<PlayaDeEstacionamiento>)gestor.buscarPlayasPorFiltro(ciudad, tipoPlaya, tipoVehiculo, diaAtencion, Decimal.Parse(precioDesde), Decimal.Parse(precioHasta), horaDesde, horaHasta);

            string json = "[";

            foreach (var p in playas)
            {
                json += p.ToJSONRepresentation() + ",";
            }

            json = json.Substring(0, json.Length - 1);
            json += "]";

            return json;
        }
        
    }
}