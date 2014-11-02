using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ReglasDeNegocio;
using System.Web.Services;
using System.Text;
using Web.Util;

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
        public static string ObtenerConsultasDeCiudad(string ciudadNombre, string desde, string hasta)
        {
            var fechaDesde = FormHelper.ObtenerFecha(desde);
            var fechaHasta = FormHelper.ObtenerFecha(hasta);
            
            var consultas = gestor.GetEstadisticasConsultasPorCiudad(ciudadNombre, fechaDesde, fechaHasta);

            StringBuilder json = new StringBuilder("[");

            foreach (var p in consultas)
            {
                json.Append(p.ToJSONRepresentation());
                json.Append(",");
            }

            if (consultas.Count != 0)
            {
                json.Remove(json.Length-1, 1);
            }
            json.Append("]");

            if (json.Equals("[]"))
            {
                master.MostrarMensajeInformacion("No hay resultados para la ciudad seleccionada", "Resultado Busqueda");
            }
            return json.ToString();
        }

        /// <summary>
        /// busca la cantidad de consultas por ano agrupadas por tipo de playa
        /// </summary>
        /// <returns>Lista de consultas en la ciudad</returns>
        [WebMethod]
        public static string ObtenerCantidadConsultasDeCiudadPorTipoPlaya(string ciudadNombre, string desde, string hasta)
        {
            var fechaDesde = FormHelper.ObtenerFecha(desde);
            var fechaHasta = FormHelper.ObtenerFecha(hasta);

            var consultas = gestor.GetEstadisticasPorCiudadYTipoPlaya(ciudadNombre, fechaDesde, fechaHasta);

            StringBuilder json = new StringBuilder("[");

            foreach (var p in consultas)
            {
                json.Append(p.ToJSONRepresentation());
                json.Append(",");
            }

            if (consultas.Count != 0)
            {
                json.Remove(json.Length - 1, 1);
            }
            json.Append("]");

            if (json.Equals("[]"))
            {
                master.MostrarMensajeInformacion("No hay resultados para la ciudad seleccionada", "Resultado Busqueda");
            }
            return json.ToString();
        }


        /// <summary>
        /// busca la cantidad de consultas por ano agrupadas por tipo de vehiculo
        /// </summary>
        /// <returns>Lista de consultas en la ciudad</returns>
        [WebMethod]
        public static string ObtenerCantidadConsultasDeCiudadPorTipoVehiculo(string ciudadNombre, string desde, string hasta)
        {
            var fechaDesde = FormHelper.ObtenerFecha(desde);
            var fechaHasta = FormHelper.ObtenerFecha(hasta);

            var consultas = gestor.GetEstadisticasPorCiudadYTipoVehiculo(ciudadNombre, fechaDesde, fechaHasta);

            StringBuilder json = new StringBuilder("[");

            foreach (var p in consultas)
            {
                json.Append(p.ToJSONRepresentation());
                json.Append(",");
            }

            if (consultas.Count != 0)
            {
                json.Remove(json.Length - 1, 1);
            }
            json.Append("]");

            if (json.Equals("[]"))
            {
                master.MostrarMensajeInformacion("No hay resultados para la ciudad seleccionada", "Resultado Busqueda");
            }
            return json.ToString();
        }

    }
}