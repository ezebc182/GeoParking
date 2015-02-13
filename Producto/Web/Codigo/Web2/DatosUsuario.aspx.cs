﻿using Entidades;
using ReglasDeNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web2
{
    public partial class DatosUsuario : System.Web.UI.Page
    {
        private static GestorUsuario gestor;

        protected void Page_Load(object sender, EventArgs e)
        {
            gestor = new GestorUsuario();
            if (SessionUsuario != null)
            {
                CargarDatosUsuario();
            }
        }

        public void CargarDatosUsuario()
        {
            Usuario usuario = gestor.BuscarUsuario(SessionUsuario.Id);
            txtNombreEditar.Text = usuario.Nombre;
            txtApellidoEditar.Text = usuario.Apellido;
            txtEmailEditar.Text = usuario.Mail;
            lblUsuarioEditar.Text = usuario.NombreUsuario;
            if (usuario.DNI != 0)
            {
                txtDni.Text = usuario.DNI.ToString();
            }
            if (usuario.Direccion != null)
            {
                txtDireccion.Text = usuario.Direccion.ToString();
            }
            if (usuario.FechaDeNacimiento.Year != 1900)
            {
                txtfechaNacimiento.Text = usuario.FechaDeNacimiento.ToString("yyyy-MM-dd");
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
    }
}