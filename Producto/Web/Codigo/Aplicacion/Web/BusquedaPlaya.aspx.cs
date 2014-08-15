using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using ReglasDeNegocio;
using Entidades;
using System.Text;
using System.Web.Script.Serialization;
namespace Web
{
    public partial class BusquedaPlaya : System.Web.UI.Page
    {
        private static GestorBusquedaPlayas gestor;
        private static String ciudadBuscada;

        protected void Page_Load(object sender, EventArgs e)
        {
            gestor = new GestorBusquedaPlayas();

            if (Session["ciudad"] != null)
            {
                txtBuscar.Text = Session["ciudad"].ToString();
                ciudadBuscada = Session["ciudad"].ToString();
            }

        }

        /// <summary>
        /// Obtiene las playas de estacionamiento de la cudad seleccionada
        /// </summary>
        /// <param name="ciudad">ciudad filtro</param>
        /// <returns>playas de estacionamiento ubicadas en esa ciudad</returns>
        [WebMethod]
        public static List<PlayaJSON> ObtenerPlayasDeCiudad()
        {
            //busco en la BD
            IList<PlayaDeEstacionamiento> playas = new List<PlayaDeEstacionamiento>();
            playas = (List<PlayaDeEstacionamiento>)gestor.buscarPlayasPorCiudad(ciudadBuscada);

            //mapeo a objeto serializable
            List<PlayaJSON> playasJSON = new List<PlayaJSON>();
            playasJSON=mapearEntityAJSON(playas);            

            return playasJSON;

        }

        //, string tipoVehiculo, string precioDesde, string precioHasta, string diasAtencion, string horaDesde, string HoraHasta
       
        //string precioDesde, string precioHasta, , string horaDesde, string horaHasta

        [WebMethod]
        public static List<PlayaJSON> ObtenerPlayasDeCiudadPorFiltro(int tipoPlaya, int tipoVehiculo, int diaAtencion, string precioDesde, string precioHasta, int horaDesde, int horaHasta)
        {
            int tipo = tipoPlaya;
            int ve = tipoVehiculo;
            int di = diaAtencion;
            string preciod = precioDesde;
            string precioh = precioHasta;
            int horad = horaDesde;
            int horah = horaHasta;

            //busco en la BD
            IList<PlayaDeEstacionamiento> playas = new List<PlayaDeEstacionamiento>();
           
            //playas = (List<PlayaDeEstacionamiento>)gestor.buscarPlayasPorFiltro(ciudadBuscada, ddlT, tipoVehiculo, diasAtencion, txtpre, precioHasta, horaDesde, HoraHasta);
            playas = (List<PlayaDeEstacionamiento>)gestor.buscarPlayasPorFiltro(ciudadBuscada, tipoPlaya, tipoVehiculo, diaAtencion,Decimal.Parse(precioDesde),Decimal.Parse(precioHasta),horaDesde,horaHasta);
            //playas = (List<PlayaDeEstacionamiento>)gestor.buscarPlayasPorCiudad(ciudadBuscada);

            //mapeo a objeto serializable
            List<PlayaJSON> playasJSON = new List<PlayaJSON>();
            playasJSON = mapearEntityAJSON(playas);

            return playasJSON;

        }

        /// <summary>
        /// Mapea un objeto entity en un objeto serializable a JSON
        /// </summary>
        /// <param name="playasEntity">objeto entity</param>
        /// <returns>lista de objetos serializables a JSON</returns>
        public static List<PlayaJSON> mapearEntityAJSON(IList<PlayaDeEstacionamiento>playasEntity)
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

                    if(direccion != null)
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

    public class PlayaJSON
    {
        public int id { get; set; }
        //Nombre
        public string Nombre { get; set; }
        //Mail
        public string Mail { get; set; }
        //Telefono
        public string Telefono { get; set; }
        //tipo playa
        public string TipoPlaya { get; set; }

        //x e y
        public string Latitud { get; set; }
        public string Longitud { get; set; }

        //Direcciones (calle, numero,ciudad y coordenadas)
        public List<DireccionJSON> Direcciones { get; set; }

        //Servicios (tipo de vehculo y capacidad)
        public List<ServicioJSON> Servicios { get; set; }

        //Horarios (dia, horaDesde, HoraHasta)
        public List<HorarioJSON> Horarios { get; set; }

        //Precios (Vehiculo, dia, tiempo, precio)
        public List<PrecioJSON> Precios { get; set; }       

    }

    public class DireccionJSON
    {
        public string Calle { get; set; }
        public int Numero { get; set; }
    }

    public class ServicioJSON
    {
        public string TipoVehiculo { get; set; }
        public int Capacidad { get; set; }
    }

    public class HorarioJSON
    {
        public string Dia { get; set; }
        public string HoraDesde { get; set; }
        public string HoraHasta { get; set; }
    }

    public class PrecioJSON
    {
        public string Vehiculo { get; set; }
        public string Dia { get; set; }
        public string Tiempo { get; set; }
        public decimal Monto { get; set; }       
    }
}