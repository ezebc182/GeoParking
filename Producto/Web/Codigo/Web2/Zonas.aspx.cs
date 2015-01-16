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
        private static MasterAdmin master;
        protected void Page_Load(object sender, EventArgs e)
        {
            gestor = new GestorZonas();
            master = Master;
            usuarioLogueado = master.SessionUsuario;
            CargarZonas();
        }

        public void CargarZonas()
        {
            hdZonas.Value = gestor.GetZonasJSON();
        }

        [WebMethod]
        public static string RecargarZonas()
        {
            return gestor.GetZonasJSON();
        }

        [WebMethod]
        public static string GuardarZona(string zonaJSON)
        {
            var zona = new Zona().ToObjectRepresentation(zonaJSON);
            zona.UsuarioId = 1009;
            var resultado = new ReglasDeNegocio.Util.Resultado();
            if (zona.Id == 0)
            {
                resultado = gestor.RegistrarZona(zona);
            }
            else
            {
                resultado = gestor.ActualizarZona(zona);
            }
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

        [WebMethod]
        public static string EliminarZona(string zonaId)
        {
            var id = Int32.Parse(zonaId);
              var  resultado = gestor.EliminarZona(id);
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