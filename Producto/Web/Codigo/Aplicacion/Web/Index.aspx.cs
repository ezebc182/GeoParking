using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using ReglasDeNegocio;

namespace Web
{
    public partial class Index : System.Web.UI.Page
    {
        
        static GestorBusquedaPlayas gestor;
        SiteMaster master;

        //Referencia al servicio web "GeoService"
        private static GeoService.Service1 geoServicio = new GeoService.Service1();

        protected void Page_Load(object sender, EventArgs e)
        {
            master = (SiteMaster)Master;
            txtBuscar.Focus();
            gestor = new GestorBusquedaPlayas();
        }
        

        /// <summary>
        /// Retorna una lista de string con las posibles ciudades de acuerdo
        /// a lo que el ususario va ingresando(prefijo)
        /// </summary>
        /// <param name="pre">prefijo o principio del nombre de la ciudad</param>
        /// <returns>Lista de string con nombre de ciudades que comienzan con "pre"</returns>
        [WebMethod]
        public static string GetNombreCiudades(string pre)
        {
            return geoServicio.GetNombreCiudades(pre);            
        }

        /// <summary>
        /// Obtiene la ciudad para filtrar la busqueda y la guarda en la session
        /// </summary>
        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            if (txtBuscar.Text != "")
            {
                //Objeto session con la ciudad
                Session["ciudad"] = txtBuscar.Text;

                //redirijo a la pagina que mostrara los resultados
                Response.Redirect("BusquedaPlaya.aspx");
            }
        }

        
    }
}