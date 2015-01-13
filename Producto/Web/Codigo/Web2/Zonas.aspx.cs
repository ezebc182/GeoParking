using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidades;
using System.Web.Services;
using ReglasDeNegocio;

namespace Web2
{
    public partial class Zonas : System.Web.UI.Page
    {
        private static GestorZonas gestor;
        private static Usuario usuarioLogueado;
        protected void Page_Load(object sender, EventArgs e)
        {
            gestor = new GestorZonas();

            usuarioLogueado = Session["usuario"] as Usuario;
        }
        
        [WebMethod]
        public static string GuardarZona(string zonaJSON)
        {
            var zona = new Zona().ToObjectRepresentation(zonaJSON);
            zona.Usuario = usuarioLogueado;
            var resultado = gestor.RegistrarZona(zona);
            
            if (resultado.Ok)
            {
                return "true";
            }
            HttpResponse Response = HttpContext.Current.Response;

            Response.Clear();
            Response.StatusCode = 200;
            Response.Write(resultado.MensajesString());

            return "false";

        }
    }
}