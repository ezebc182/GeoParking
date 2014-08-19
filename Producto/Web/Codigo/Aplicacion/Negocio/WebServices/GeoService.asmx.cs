using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using Entidades;
using WebServices.ClasesJSON;
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

            //mapeo a objeto serializable
            List<PlayaJSON> playasJSON = new List<PlayaJSON>();
            playasJSON = mapearEntityAJSON(playas);

            JavaScriptSerializer js = new JavaScriptSerializer();
            string playasCiudad = js.Serialize(playasJSON);
            return playasCiudad;

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

            //mapeo a objeto serializable
            List<PlayaJSON> playasJSON = new List<PlayaJSON>();
            playasJSON = mapearEntityAJSON(playas);

            JavaScriptSerializer js = new JavaScriptSerializer();
            string playasCiudad = js.Serialize(playasJSON);
            return playasCiudad;

        }

        /// <summary>
        /// Mapea un objeto entity en un objeto serializable a JSON
        /// </summary>
        /// <param name="playasEntity">objeto entity</param>
        /// <returns>lista de objetos serializables a JSON</returns>
        public static List<PlayaJSON> mapearEntityAJSON(IList<PlayaDeEstacionamiento> playasEntity)
        {
            List<PlayaJSON> playas = new List<PlayaJSON>();

            foreach (var p in playasEntity)
            {
                PlayaJSON playa = new PlayaJSON();

                //datos basicos
                playa.Nombre = p.Nombre;
                playa.Mail = p.Mail;
                playa.Telefono = p.Telefono;
                playa.TipoPlaya = p.TipoPlayaStr;

                //datos geograficos
                playa.Latitud = p.Direcciones[0].Latitud;
                playa.Longitud = p.Direcciones[0].Longitud;



                //DIRECCIONES
                playa.Direcciones = new List<DireccionJSON>();
                foreach (var d in p.Direcciones)
                {
                    DireccionJSON direccion = new DireccionJSON();
                    direccion.Calle = d.Calle;
                    direccion.Numero = d.Numero;

                    if (direccion != null)
                        playa.Direcciones.Add(direccion);
                }

                //SERVICIOS
                playa.Servicios = new List<ServicioJSON>();
                foreach (var s in p.Servicios)
                {
                    ServicioJSON servicio = new ServicioJSON();
                    servicio.TipoVehiculo = s.TipoVehiculoStr;
                    servicio.Capacidad = s.Capacidad;

                    playa.Servicios.Add(servicio);
                }

                //HORARIOS
                playa.Horarios = new List<HorarioJSON>();
                foreach (var h in p.Horarios)
                {
                    HorarioJSON horario = new HorarioJSON();
                    horario.Dia = h.DiaAtencionStr;
                    horario.HoraDesde = h.HoraDesde;
                    horario.HoraHasta = h.HoraHasta;

                    playa.Horarios.Add(horario);
                }

                //PRECIOS
                playa.Precios = new List<PrecioJSON>();
                foreach (var pre in p.Precios)
                {
                    PrecioJSON precio = new PrecioJSON();
                    precio.Vehiculo = pre.TipoVehiculoStr;
                    precio.Dia = pre.DiaAtencionStr;
                    precio.Tiempo = pre.TiempoStr;
                    precio.Monto = pre.Monto;

                    playa.Precios.Add(precio);
                }

                playas.Add(playa);
            }
            return playas;
        }
    }
}