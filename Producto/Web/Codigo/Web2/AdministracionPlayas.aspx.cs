﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ReglasDeNegocio;
using Web2.Util;
using Entidades;
using System.Web.Services;
using ReglasDeNegocio.Util;

namespace Web2
{
    public partial class AdministracionPlayas : System.Web.UI.Page
    {
        //gestor encargado de todas las funcionalidades del ABM
        private static GestorPlaya gestor;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (SessionUsuario == null)
            {
                Response.Redirect("/web.aspx");
            }

            gestor = new GestorPlaya();

            if (!Page.IsPostBack)
            {
                CargarCombos();
                hfTiempos.Value = gestor.BuscarTiemposDeAtencionJSON();
            }


        }

        public Usuario SessionUsuario
        {
            get
            {
                if (Request.Cookies["SessionUsuario"] != null)
                {
                    Usuario sesion = new Usuario();
                    sesion.RolId = Int32.Parse(Request.Cookies["SessionUsuario"]["Rol"]);
                    sesion.NombreUsuario = Request.Cookies["SessionUsuario"]["NombreUsuario"];
                    sesion.Contraseña = Request.Cookies["SessionUsuario"]["Contraseña"];
                    sesion.Id = Int32.Parse(Request.Cookies["SessionUsuario"]["IdUsuario"]);
                    sesion.Nombre = Request.Cookies["SessionUsuario"]["Nombre"];
                    sesion.Apellido = Request.Cookies["SessionUsuario"]["Apellido"];
                    sesion.Mail = Request.Cookies["SessionUsuario"]["Mail"];
                    return sesion;
                }
                else
                {
                    return null;
                }
            }
        }

        [WebMethod]
        public static string EliminarPlaya(int id)
        {
            var resultado = gestor.EliminarPlaya(id);

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

        [WebMethod]
        public static string BuscarPlayas(string idPlaceCiudad)
        {
            var playas = gestor.BuscarPlayasPorCiudadJSON(idPlaceCiudad);
            return playas;
        }

        [WebMethod]
        public static string GuardarPlaya(string playaJSON)
        {
            Resultado resultado = new Resultado();
            var playa = new PlayaDeEstacionamiento().ToObjectRepresentation(playaJSON);
            if (playa.Id == 0)
            {
                resultado = gestor.RegistrarPlaya(playa);
            }
            else resultado = gestor.ActualizarPlaya(playa); 

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