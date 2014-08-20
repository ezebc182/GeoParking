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
        private static String ciudadBuscada;

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

        /*NOTA IMPORTANTE:
         Se ha heliminado el codigo de busqueda y filtrado de playas, 
         el mismo a pasado a formar parte de un servicio web "GeoService".
         Por motivos de implementacion aun los meotodos de esta pagina se
         siguen implementando como WebMethod, ya que aun no se puede realizar
         la conexion directa de ajax al servicio web. Lo importante es que 
         el codigo ya no esta en behind*/
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

    }
      
}