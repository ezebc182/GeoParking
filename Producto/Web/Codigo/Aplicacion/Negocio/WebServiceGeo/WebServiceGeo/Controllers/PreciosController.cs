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
        private GestorAutenticacion gestorAutenticacion = new GestorAutenticacion();
        
        /// <summary>
        /// Actualiza el precio de una playa
        /// </summary>
        /// <param name="precio">Objeto Precio del controlador</param>
        /// <returns>'True' si la accion se concreto</returns>
        public string PostActualizarPrecio([FromBody]PrecioControler precio)
        {
            if (gestorAutenticacion.verificarAutenticacion(precio.IdPLaya, precio.Token).Ok)
            {
                return gestor.ActualizarPrecioPlaya(precio.IdPLaya, precio.IdTiempo, precio.IdTipoVehiculo, precio.Precio).Ok.ToString();
            }
            return "False";
            
        }
       

        /// <summary>
        /// Registra el precio de una playa
        /// </summary>
        /// <param name="precio">Objeto Precio del controlador</param>
        /// <returns>'True' si la accion se concreto</returns>
        public string PostRegistrarPrecio([FromBody]PrecioControler precio)
        {
            return gestor.RegistrarPrecioPlaya(precio.IdPLaya, precio.IdTiempo, precio.IdTipoVehiculo, precio.Precio).Ok.ToString();
        }

        /**
         * Obtiene los precios de las playas selecionadas para el tipo de vehiculo seleccionado
         * ej. api/Playas/GetPreciosPlayas?tipoVehiculoId=1&idPlayas=1,2,3,5
         */
        public string GetObtenerPreciosPlayas([FromUri] string idPlayas,[FromUri] int idTipoVehiculo)
        {
            IList<Precio> precios = new List<Precio>();
            precios = (List<Precio>)gestor.GetPreciosDePlayasPorTipoVehiculoEIdPlayas(idPlayas, idTipoVehiculo);
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

    /// <summary>
    /// Objeto que se genera a partir de la informacion de la peticion
    /// </summary>
    public class PrecioControler
    {
        public int IdPLaya { get; set; }
        public int IdTiempo { get; set; }
        public int IdTipoVehiculo { get; set; }
        public double Precio { get; set; }
        public string Token { get; set; }
    }
}
