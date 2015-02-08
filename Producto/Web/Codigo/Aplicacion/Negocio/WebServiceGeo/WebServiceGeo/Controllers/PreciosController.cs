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
    public class PreciosController : ApiController
    {

        private GestorPrecio gestor = new GestorPrecio();

        /// <summary>
        /// Actualiza el precio para un tiempo de estacionamiento de un tipo
        /// de vehiculo de una playa
        /// </summary>
        /// <param name="idPlaya"></param>
        /// <param name="idTiempo"></param>
        /// <param name="idTipoVehiculo"></param>
        /// <param name="precio"></param>
        /// <returns>'True' si la accion se concreto</returns>
        public string SetActualizarPrecio([FromUri]int idPlaya, [FromUri]int idTiempo, [FromUri]int idTipoVehiculo, [FromUri] double precio)
        {
            return gestor.ActualizarPrecioPlaya(idPlaya, idTiempo, idTipoVehiculo, precio).Ok.ToString();
        }

        public string SetRegistrarPrecio([FromUri]int idPlaya, [FromUri]int idTiempo, [FromUri]int idTipoVehiculo, [FromUri] double precio)
        {
            return gestor.RegistrarPrecioPlaya(idPlaya, idTiempo, idTipoVehiculo, precio).Ok.ToString();
        }

        /**
         * Obtiene los precios de las playas selecionadas para el tipo de vehiculo seleccionado
         * ej. api/Playas/GetPreciosPlayas?tipoVehiculoId=1&idPlayas=1,2,3,5
         */
        public string PostObtenerPreciosPlayas([FromBody] ListadoIdPlayas datos)
        {
            IList<Precio> precios = new List<Precio>();
            precios = (List<Precio>)gestor.GetPreciosDePlayasPorTipoVehiculoEIdPlayas(datos.idPlayas, datos.idTipoVehiculo);
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
