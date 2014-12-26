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
        /// Actualiza la disponibilidad de lugares de una playa de estacionamiento
        /// para un tipo de vehiculo en particular
        /// </summary>
        /// <param name="idPlaya"></param>
        /// <param name="idTipoVehiculo"></param>
        /// <param name="idEvento"></param>
        /// <param name="dia"></param>
        public string GetActualizarDisponibilidad([FromUri]int idPlaya, [FromUri]int idTipoVehiculo, [FromUri]int idEvento, [FromUri]string fecha)
        {
            return gestor.ActualizarDisponibilidadPlaya(idPlaya, idTipoVehiculo, idEvento, DateTime.Parse(fecha), DateTime.Parse(fecha).Day).Ok.ToString();
        }

        // GET api/disponibilidad/GetActualizarDisponibilidadGeneral
        /// <summary>
        /// actualiza la disponibilidad de un tipo de vehiculo
        /// ingresando la cantidad exacta de la disponibilidad
        /// </summary>
        /// <param name="idPlaya"></param>
        /// <param name="idTipoVehiculo"></param>
        /// <param name="disponibilidad"></param>
        /// <param name="idEvento"></param>
        /// <param name="fecha"></param>
        /// <returns>'True' si fue correcta </returns>
        public string GetActualizarDisponibilidadGeneral([FromUri]int idPlaya, [FromUri]int idTipoVehiculo, [FromUri]int disponibilidad, [FromUri]int idEvento, [FromUri]string fecha)
        {
            return gestor.ActualizarDisponibilidadGeneralPlaya(idPlaya, idTipoVehiculo, disponibilidad, idEvento, DateTime.Parse(fecha), DateTime.Parse(fecha).Day).Ok.ToString();
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
        public string GetDisponibilidadesPlayasPorTipoVehiculo([FromUri] String idPlayas, [FromUri]int idTipoVehiculo)
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(gestor.GetDisponibilidadDePlayasPorTipoVehiculo(idPlayas, idTipoVehiculo));
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

        // POST api/disponibilidad
        public void Post([FromBody]string value)
        {
        }

        // PUT api/disponibilidad/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/disponibilidad/5
        public void Delete(int id)
        {
        }
    }
}
