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
        //referencia a la master
        private static SiteMaster master;

        //Ciudad buscada por el usuario
        public static String ciudadBuscada;

        //gestor de busqueda de playas
        private static GestorBusquedaPlayas gestor;

        //Referencia al servicio web "GeoService"
        private static GeoService.Service1 geoServicio = new GeoService.Service1();

        protected void Page_Load(object sender, EventArgs e)
        {
            master = (SiteMaster)Master;
         
            gestor = new GestorBusquedaPlayas();

            if (!Page.IsPostBack)
            {

                if (Session["ciudad"] != null)
                {
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
            FormHelper.CargarCombo(ddlTipoPlaya, gestor.BuscarTipoPlayas(), "Nombre", "Id", "Tipo de playa");
        }

        /// <summary>
        /// Carga el combo Tipos de Vehiculos 
        /// </summary>
        public void CargarComboTiposVehiculos()
        {
            FormHelper.CargarCombo(ddlTipoVehiculo, gestor.BuscarTipoVehiculos(), "Nombre", "Id", "Tipo de vehículo");
        }

        /// <summary>
        /// Carga el combo Dias de Atencion
        /// </summary>
        public void CargarComboDiasAtencion()
        {

            FormHelper.CargarCombo(ddlDiasAtencion, gestor.BuscarDiasDeAtencion(), "Nombre", "Id", "Días de atención");
        }



        /// <summary>
        /// Buscar las playas de estacionamiento de la ciudad seleccionada en el Index
        /// </summary>
        /// <returns>Lista de playas de la ciudad</returns>
        [WebMethod]
        public static string ObtenerPlayasDeCiudad()
        {
            string playasDeCiudad = geoServicio.ObtenerPlayasDeCiudad(ciudadBuscada);
            if (playasDeCiudad=="[]")
            {                
                master.MostrarMensajeInformacion("No hay resultados para la ciudad seleccionada", "Resultado Busqueda");                
            }
            return playasDeCiudad;
        }

        /// <summary>
        /// Buscar las playas de estacionamiento de la nueva ciudad seleccionada
        /// </summary>
        /// <returns>Lista de playas de la ciudad</returns>
        [WebMethod]
        public static string ObtenerPlayasDeCiudadNueva(string ciudad)
        {
            ciudadBuscada = ciudad;

            string playasDeCiudad = geoServicio.ObtenerPlayasDeCiudad(ciudadBuscada);
            if (playasDeCiudad == "[]")
            {
                master.MostrarMensajeInformacion("No hay resultados para la ciudad seleccionada", "Resultado Busqueda");
            }
            return playasDeCiudad;
        }

        /// <summary>
        /// Busca las playas de estacionamiento segun los criterios por
        /// los que haya filtrado el usuario
        /// </summary>
        /// <param name="tipoPlaya">tipo de playa</param>
        /// <param name="tipoVehiculo">tipo de vehiculo</param>
        /// <param name="diaAtencion">dia de atencion</param>
        /// <param name="precioDesde">precio minimo</param>
        /// <param name="precioHasta">precio maximo</param>
        /// <param name="horaDesde">hora de apertura</param>
        /// <param name="horaHasta">hora de cierre</param>
        /// <returns>Lista de playas que cumplan con los criterios especificados</returns>
        [WebMethod]
        public static string ObtenerPlayasDeCiudadPorFiltro(int tipoPlaya, int tipoVehiculo, int diaAtencion, string precioDesde, string precioHasta, int horaDesde, int horaHasta)
        {
            string playasFiltradas = geoServicio.ObtenerPlayasDeCiudadPorFiltro(ciudadBuscada,tipoPlaya, tipoVehiculo, diaAtencion, precioDesde, precioHasta, horaDesde, horaHasta);
            if (playasFiltradas == "[]")
            {
                master.MostrarMensajeInformacion(TipoMensajeEnum.MensajeModal, "No hay resultados para los filtros aplicados", "Resultado Busqueda");
            }
            return playasFiltradas;
        }

        /// <summary>
        /// Busca el nombre de la ciudad buscada en la session
        /// </summary>
        /// <returns>ciudad de la session</returns>
        [WebMethod]
        public static string ObtenerCiudadSession()
        {
            return ciudadBuscada;
        }

    }
      
}