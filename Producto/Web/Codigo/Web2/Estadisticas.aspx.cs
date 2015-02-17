using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ReglasDeNegocio;
using System.Web.Services;
using Web2.Util;

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
                hdZonas.Value = gestorZonas.GetZonasJSON();
                hdTiposPlayas.Value = gestorPlaya.BuscarTipoPlayasJSON();
                hdTiposVehiculos.Value = gestorPlaya.BuscarTipoVehiculosJSON();
            }
        }

        [WebMethod]
        public static string BuscarEstadisticas(string ciudad, int tipoEstadistica, int buscarPor, string desde, string hasta)
        {
            switch (tipoEstadistica)
            {
                case 1://Disponibilidad
                    switch (buscarPor)
                    {
                        case 1://playas
                            return "gestor.DisponibilidadPorPlayas()";
                        case 2://zonas
                            return "disponibilidadPorZonas";
                    }
                    break;
                case 2://Consultas
                    switch (buscarPor)
                    {
                        case 1://playas
                            return gestor.ConsultasPorPlayasJSON(ciudad, 1009, FormHelper.ObtenerFecha(desde), FormHelper.ObtenerFecha(hasta));
                        case 2://zonas
                            return gestor.ConsultasPorZonasJSON(ciudad, 1009, FormHelper.ObtenerFecha(desde), FormHelper.ObtenerFecha(hasta));
                    }
                    break;
            }
            return "error";
        }

        [WebMethod]
        public static string BuscarPlayas(string ciudad)
        {
            return gestorPlaya.BuscarPlayasPorCiudadJSON(ciudad);
        }
    }
}