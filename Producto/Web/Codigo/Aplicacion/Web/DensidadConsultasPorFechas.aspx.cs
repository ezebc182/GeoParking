using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ReglasDeNegocio;
using System.Web.Services;

namespace Web
{
    public partial class DensidadConsultasPorFechas : System.Web.UI.Page
    {
        //referencia a la master
        public static SiteMaster master;

        //gestor de busqueda de playas
        private static GestorBusquedaPlayas gestor;

        protected void Page_Load(object sender, EventArgs e)
        {
            master = (SiteMaster)Master.Master;

            gestor = new GestorBusquedaPlayas();

            if (!Page.IsPostBack)
            {

               
            }

        }

        /// <summary>
        /// Buscar las playas de estacionamiento de la ciudad seleccionada en el Index
        /// </summary>
        /// <returns>Lista de playas de la ciudad</returns>
        [WebMethod]
        public static string ObtenerPlayasDeCiudad()
        {
            var playas = gestor.buscarPlayasPorCiudad("Cordoba");

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
                master.MostrarMensajeInformacion("No hay resultados para la ciudad seleccionada", "Resultado Busqueda");
            }
            return json;
        }


    }
}