using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Entidades;
using ReglasDeNegocio;

namespace WebServiceGeo.Controllers
{
    public class DisponibilidadController : ApiController
    {
        
        private GestorDisponibilidad gestor = new GestorDisponibilidad();

        // GET api/disponibilidad
        
        /// <summary>
        /// Actualiza la disponibilida de una playa
        /// </summary>
        /// <param name="disponibilidad">Objeto disponibilidad del controlador</param>
        /// <returns>'True' si la accion se realizo correctamente</returns>
        public string PostActualizarDisponibilidad([FromBody]DisponibilidadControlador disponibilidad)
        {
            return gestor.ActualizarDisponibilidadPlaya(disponibilidad.IdPLaya, disponibilidad.IdTipoVehiculo, disponibilidad.IdEvento, DateTime.Parse(disponibilidad.Fecha), DateTime.Parse(disponibilidad.Fecha).Day).Ok.ToString();
        }
        
        /// <summary>
        /// Actualiza la disponibilida general de una playa
        /// </summary>
        /// <param name="disponibilidad">Objeto disponibilidad del controlador</param>
        /// <returns>'True' si la accion se realizo correctamente</returns>
        public string PostActualizarDisponibilidadGeneral([FromBody]DisponibilidadControlador disponibilidad)
        {
            return gestor.ActualizarDisponibilidadGeneralPlaya(disponibilidad.IdPLaya, disponibilidad.IdTipoVehiculo, disponibilidad.Disponibilidad, disponibilidad.IdEvento, DateTime.Parse(disponibilidad.Fecha), DateTime.Parse(disponibilidad.Fecha).Day).Ok.ToString();
        }

        // GET api/disponibilidad/GetDisponibilidadesPlayasPorTipoVehiculo
        /// <summary>
        /// Retorna la disponibilidad de una lista de playas de estacionamientos
        /// de acuerdo a un tipo de vehiculo
        /// cada registro devuelve [idPlaya, TipoVehiculo, Disponibilidad]
        /// </summary>
        /// <param name="idPlayas"></param>
        /// <param name="idTipoVehiculo"></param>
        /// <returns></returns>
        public string PostObtenerDisponibilidadesPlayasPorTipoVehiculo([FromBody] ListadoIdPlayas playas)
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(gestor.GetDisponibilidadDePlayasPorTipoVehiculo(playas.idPlayas, playas.idTipoVehiculo));
        }

        // GET api/disponibilidad/GetDisponibilidadPlayaPorTipoVehiculo
        /// <summary>
        /// Retorna la disponibilidad de una playa de estacionamiento
        /// de acuerdo a un tipo de vehiculo
        /// cada registro devuelve [idPlaya, TipoVehiculo, Disponibilidad]
        /// </summary>
        /// <param name="idPlayas"></param>
        /// <param name="idTipoVehiculo"></param>
        /// <returns></returns>
        public int GetDisponibilidadPlayaPorTipoVehiculo([FromUri] int idPlaya, [FromUri]int idTipoVehiculo)
        {
            return gestor.GetDisponibilidadPlayaPorTipoVehiculo(idPlaya, idTipoVehiculo);
        }
        
    }

    /// <summary>
    /// Objeto disponibilidad que se genera por datos recibidos por la peticion
    /// </summary>
    public class DisponibilidadControlador
    {
        public int IdPLaya { get; set; }
        public int IdTipoVehiculo { get; set; }
        public int Disponibilidad { get; set; }
        public int IdEvento { get; set; }
        public string Fecha { get; set; }        
    }

    public class ListadoIdPlayas
    {
        public String idPlayas { get; set; }
        public int idTipoVehiculo { get; set; }
    }
}
