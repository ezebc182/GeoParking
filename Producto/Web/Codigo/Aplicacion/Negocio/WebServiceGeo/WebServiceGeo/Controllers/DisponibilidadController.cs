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
        public void GetActualizarDisponibilidad([FromUri]int idPlaya, [FromUri]int idTipoVehiculo, [FromUri]int idEvento, [FromUri]int dia)
        {
            gestor.ActualizarDisponibilidadPlaya(idPlaya, idTipoVehiculo, idEvento, DateTime.Now, dia);
        }
                
        // GET api/disponibilidad/5
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
            String[] idPlayasArray = idPlayas.Split(',');
            int[] idPlayasInt = new int[idPlayasArray.Length];
            for (int i = 0; i < idPlayasArray.Length; i++)
			{
                idPlayasInt[i] = Int32.Parse(idPlayasArray[i]);
			}
            return Newtonsoft.Json.JsonConvert.SerializeObject(gestor.GetDisponibilidadPlayasPorTipoVehiculo(idPlayasInt, idTipoVehiculo));
        }

        // GET api/disponibilidad/5
        /// <summary>
        /// Retorna la disponibilidad de una playa de estacionamiento
        /// de acuerdo a un tipo de vehiculo
        /// cada registro devuelve [idPlaya, TipoVehiculo, Disponibilidad]
        /// </summary>
        /// <param name="idPlayas"></param>
        /// <param name="idTipoVehiculo"></param>
        /// <returns></returns>
        public string GetDisponibilidadPlayaPorTipoVehiculo([FromUri] int idPlaya, [FromUri]int idTipoVehiculo)
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(gestor.GetDisponibilidadPlayaPorTipoVehiculo(idPlaya, idTipoVehiculo));
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
