using Entidades;
using ReglasDeNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using Web2.Util;

namespace Web2
{
    public partial class BusquedaPlaya : System.Web.UI.Page
    {
        //referencia a la master
        //public static SiteMaster master;

        //Ciudad buscada por el usuario
        public static String ciudadBuscada;

        //gestor de busqueda de playas
        private static GestorBusquedaPlayas gestor;

        protected void Page_Load(object sender, EventArgs e)
        {
            //master = (SiteMaster)Master;

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
            FormHelper.CargarCombo(ddlTipoPlaya, gestor.BuscarTipoPlayas(), "Nombre", "Id", "Seleccione Tipo Playa");
        }

        /// <summary>
        /// Carga el combo Tipos de Vehiculos 
        /// </summary>
        public void CargarComboTiposVehiculos()
        {
            FormHelper.CargarCombo(ddlTipoVehiculo, gestor.BuscarTipoVehiculos(), "Nombre", "Id", "Seleccione Tipo Vehiculo");
        }

        /// <summary>
        /// Carga el combo Dias de Atencion
        /// </summary>
        public void CargarComboDiasAtencion()
        {

            FormHelper.CargarCombo(ddlDiasAtencion, gestor.BuscarDiasDeAtencion(), "Nombre", "Id", "Seleccione Día Atención");
        }

        /// <summary>
        /// Buscar las playas de estacionamiento de la ciudad seleccionada en el Index
        /// </summary>
        /// <returns>Lista de playas de la ciudad</returns>
        [WebMethod]
        public static string ObtenerPlayasDeCiudad()
        {
            IList<PlayaDeEstacionamiento> playas = new List<PlayaDeEstacionamiento>();
            playas = (List<PlayaDeEstacionamiento>)gestor.buscarPlayasPorCiudad(ciudadBuscada);

            string json = "[";

            foreach (var p in playas)
            {
                json += p.ToJSONRepresentation() + ",";
            }

            if (playas.Count != 0)
            {
                json = json.Substring(0, json.Length - 1);
            }
            json += "]";

            if (json == "[]")
            {
                //master.MostrarMensajeInformacion("No hay resultados para la ciudad seleccionada", "Resultado Busqueda");
            }
            return json;
        }

        /// <summary>
        /// Buscar las playas de estacionamiento de la nueva ciudad seleccionada
        /// </summary>
        /// <returns>Lista de playas de la ciudad</returns>
        [WebMethod]
        public static string ObtenerPlayasDeCiudadNueva(string ciudad)
        {
            ciudadBuscada = ciudad;

            IList<PlayaDeEstacionamiento> playas = new List<PlayaDeEstacionamiento>();
            playas = (List<PlayaDeEstacionamiento>)gestor.buscarPlayasPorCiudad(ciudadBuscada);

            string json = "[";

            foreach (var p in playas)
            {
                json += p.ToJSONRepresentation() + ",";
            }

            if (playas.Count != 0)
            {
                json = json.Substring(0, json.Length - 1);
            }
            json += "]";

            if (json == "[]")
            {
                //master.MostrarMensajeInformacion("No hay resultados para la ciudad seleccionada", "Resultado Busqueda");
            }
            return json;
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
            IList<PlayaDeEstacionamiento> playas = new List<PlayaDeEstacionamiento>();

            playas = (List<PlayaDeEstacionamiento>)gestor.buscarPlayasPorFiltro(ciudadBuscada, tipoPlaya, tipoVehiculo, diaAtencion, Decimal.Parse(precioDesde), Decimal.Parse(precioHasta), horaDesde, horaHasta);

            string json = "[";

            foreach (var p in playas)
            {
                json += p.ToJSONRepresentation() + ",";
            }

            if (playas.Count != 0)
            {
                json = json.Substring(0, json.Length - 1);
            }
            json += "]";

            if (json == "[]")
            {
                //master.MostrarMensajeInformacion(TipoMensajeEnum.MensajeModal, "No hay resultados para los filtros aplicados", "Resultado Busqueda");
            }
            return json;
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