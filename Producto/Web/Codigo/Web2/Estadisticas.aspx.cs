using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ReglasDeNegocio;
namespace Web2
{
    public partial class Estadisticas : System.Web.UI.Page
    {
        public static GestorEstadisticas gestor;
        public static GestorPlaya gestorPlaya;
        public static GestorTiposVehiculo gestorTipoVehiculo;
        public static GestorZonas gestorZonas;

        protected void Page_Load(object sender, EventArgs e)
        {
            gestor = new GestorEstadisticas();
            gestorPlaya = new GestorPlaya();
            gestorTipoVehiculo = new GestorTiposVehiculo();
            gestorZonas = new GestorZonas();

            if (!Page.IsPostBack)
            {

            }
        }

        public static string CiudadSeleccionada() {
            return txtBuscarCiudad.Text;
        }

        public static void CargarValores() {
            hdPlayas.Value = gestorPlaya.BuscarPlayasPorCiudadJSON(CiudadSeleccionada());
            hdZonas.Value = gestorZonas.GetZonasJSON();
            hdTiposPlayas.Value = gestorPlaya.BuscarTipoPlayasJSON();
            hdTiposVehiculos.Value = gestorPlaya.BuscarTipoVehiculosJSON();
        }
    }
}