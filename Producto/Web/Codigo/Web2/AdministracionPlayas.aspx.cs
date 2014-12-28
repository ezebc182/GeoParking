using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ReglasDeNegocio;
using Web2.Util;
using Entidades;
using System.Web.Services;

namespace Web2
{
    public partial class AdministracionPlayas : System.Web.UI.Page
    {
        //gestor encargado de todas las funcionalidades del ABM
        private static GestorPlaya gestor;

        protected void Page_Load(object sender, EventArgs e)
        {
            gestor = new GestorPlaya();

            if (!Page.IsPostBack)
            {
                CargarCombos();
                hfTiempos.Value = gestor.BuscarTiemposDeAtencionJSON();
            }

        }

        [WebMethod]
        public static string GuardarPlaya(string playaJSON)
        {
            var playa = new PlayaDeEstacionamiento().ToObjectRepresentation(playaJSON);
            var resultado = gestor.RegistrarPlaya(playa);


            if (resultado.Ok)
            {
                return "true";
            }
            HttpResponse Response = HttpContext.Current.Response;

            Response.Clear();
            Response.StatusCode = 500;
            Response.Write(resultado.MensajesString());

            return "false";
        }

        private void CargarCombos()
        {
            CargarComboTipoPlayas();
            CargarComboTipoVehiculos();
            CargarComboDias();
        }

        private void CargarComboTipoPlayas()
        {
            FormHelper.CargarCombo(ddlTipoPlaya, gestor.BuscarTipoPlayas(), "Nombre", "Id", "Seleccione");
        }

        private void CargarComboTipoVehiculos()
        {
            FormHelper.CargarCombo(ddlTipoVehiculo, gestor.BuscarTipoVehiculos(), "Nombre", "Id", "Seleccione");
        }

        private void CargarComboDias()
        {
            FormHelper.CargarCombo(ddlDias, gestor.BuscarDiasDeAtencion(), "Nombre", "Id", "Seleccione");
        }
    }
}