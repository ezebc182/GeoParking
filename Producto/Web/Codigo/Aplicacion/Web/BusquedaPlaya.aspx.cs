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
using Web.Util;
using Web.ClasesJsonVista;
namespace Web
{
    public partial class BusquedaPlaya : System.Web.UI.Page
    {
        private static GestorBusquedaPlayas gestor;
        private static String ciudadBuscada;

        protected void Page_Load(object sender, EventArgs e)
        {
            gestor = new GestorBusquedaPlayas();

            if (!Page.IsPostBack)
            {

                if (Session["ciudad"] != null)
                {
                    txtBuscar.Text = Session["ciudad"].ToString();
                    ciudadBuscada = Session["ciudad"].ToString();
                }

                //cargo los combos de los filtros
                CargarComboTiposPlayas();
                CargarComboTiposVehiculos();
                CargarComboDiasAtencion();
            }

        }

        /// <summary>
        /// Carga el combo Tipos de playas con todas las playas nod adas de baja en la BD
        /// </summary>
        public void CargarComboTiposPlayas()
        {
            FormHelper.CargarCombo(ddlTipoPlaya, gestor.BuscarTipoPlayas(), "Nombre", "Id", "Seleccione");
        }

        /// <summary>
        /// Carga el combo Tipos de Vehiculos 
        /// </summary>
        public void CargarComboTiposVehiculos()
        {
            FormHelper.CargarCombo(ddlTipoVehiculo, gestor.BuscarTipoVehiculos(), "Nombre", "Id", "Seleccione");
        }

        /// <summary>
        /// Carga el combo Dias de Atencion
        /// </summary>
        public void CargarComboDiasAtencion()
        {
            FormHelper.CargarCombo(ddlDiasAtencion, gestor.BuscarDiasDeAtencion(), "Nombre", "Id", "Seleccione");
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
        public static List<PlayaJSON> ObtenerPlayasDeCiudadPorFiltro(int tipoPlaya, int tipoVehiculo, int diaAtencion, string precioDesde, string precioHasta, int horaDesde, int horaHasta)
        {
            //busco en la BD
            IList<PlayaDeEstacionamiento> playas = new List<PlayaDeEstacionamiento>();
                       
            playas = (List<PlayaDeEstacionamiento>)gestor.buscarPlayasPorFiltro(ciudadBuscada, tipoPlaya, tipoVehiculo, diaAtencion,Decimal.Parse(precioDesde),Decimal.Parse(precioHasta),horaDesde,horaHasta);
           
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
      
}