using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ReglasDeNegocio;
using Entidades;

namespace WebServiceGeo.Controllers
{
    public class ServiciosController : ApiController
    {
        GestorServicio gestor = new GestorServicio();       

        /// <summary>
        /// Registra un nuevo servicio
        /// </summary>
        /// <param name="servicio">Objeto servicio utilizado por el controlador</param>
        /// <returns>'True' si la operacion se realizo correctamente</returns>
        public string PostRegistrarServicio([FromBody] ServicioControlador servicio)
        {
            List<Precio> precios = new List<Precio>();

            foreach (var item in servicio.Precios)
	        {
                Precio p = new Precio();
                p.TiempoId = item.IdTiempo;
                p.Monto = Decimal.Parse(item.Monto.ToString());
                precios.Add(p);
	        }
            
            return gestor.RegistrarServicioPlaya(servicio.IdPlaya, servicio.IdTipoVehiculo, servicio.Capacidad, precios).Ok.ToString();
        }

        /// <summary>
        /// Cancela un servicio
        /// </summary>
        /// <param name="servicio"Objeto servicio utilizado por el controlador></param>
        /// <returns>'True' si la operacion se realizo correctamente</returns>
        public string PostCancelarServicio([FromBody] ServicioControlador servicio)
        {
            return gestor.CancelarServicioPlaya(servicio.IdPlaya, servicio.IdTipoVehiculo).Ok.ToString();
        }

        /// <summary>
        /// Actualiza la capacidad de un servicio
        /// </summary>
        /// <param name="servicio">Objeto servicio utilizado por el controlador</param>
        /// <returns>'True' si la operacion se realizo correctamente</returns>
        public string PostActualizarCapacidadServicio([FromBody] ServicioControlador servicio)
        {
            return gestor.ActualizarCapacidadServicio(servicio.IdPlaya, servicio.IdTipoVehiculo, servicio.Capacidad).Ok.ToString();
        }
       
    }


    /// <summary>
    /// Clase que representa un servicio, y que se forma de recibir los datos
    /// de una consulta por Post
    /// </summary>
    public class ServicioControlador
    {
        public int IdPlaya { get; set; }
        public int IdTipoVehiculo { get; set; }
        public int Capacidad { get; set; }
        public TipoPrecio[] Precios { get; set; }
    }

    public class TipoPrecio
    {
        public int IdTiempo { get; set; }
        public Double Monto { get; set; }
    }

    



    

}
