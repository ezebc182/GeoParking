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
    public partial class Estadisticas : System.Web.UI.Page
    {
        //referencia a la master
        public static SiteMaster master;

        //gestor de busqueda de playas
        private static GestorEstadisticas gestor;
       

        protected void Page_Load(object sender, EventArgs e)
        {
            master = (SiteMaster)Master;

            gestor = new GestorEstadisticas();

            if (!Page.IsPostBack)
            {

               
            }
        }

        /// <summary>
        /// Buscar las consultas de la ciudad seleccionada
        /// </summary>
        /// <returns>Lista de consultas en la ciudad</returns>
        [WebMethod]
        public static string ObtenerConsultasDeCiudad(string ciudadNombre)
        {
            var consultas = gestor.GetEstadisticasConsultasPorCiudad(ciudadNombre);

            string json = "[";

            foreach (var p in consultas)
            {
                json += p.ToJSONRepresentation() + ",";
            }

            if (consultas.Count != 0)
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