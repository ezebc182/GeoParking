using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidades;
using ReglasDeNegocio;

namespace Web
{
    public partial class SiteMaster : System.Web.UI.MasterPage
    {

        GestorUsuario gestor;

        protected void Page_Load(object sender, EventArgs e)
        {
            gestor = new GestorUsuario();
        }

        public string Alert
        {
            get { return lblMessage.InnerText; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    lblMessage.InnerText = value;
                    Show();
                }                
            }
        }
        private void Show()
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "PopAlerta", "$(function() { Alerta_openModal(); });", true);
        }

        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (txtApellido.Text!="" && txtNombre.Text!="" && txtContraseña.Text!="" && txtContraseñaRepetir.Text!="" 
                && txtEmailRegistro.Text!="" && txtUsuarioRegistro.Text!="")
            {
                Usuario usuario = CargarEntidad();
                var resultado = gestor.RegistrarUsuario(usuario);
            }
        }

        protected void btnIniciarSesion_Click(object sender, EventArgs e)
        {
            if (txtUsuarioLogin.Text != "" && txtContraseñaLogin.Text != "")
            {

            }
        }

        public Usuario CargarEntidad()
        {
            Usuario usuario = new Usuario
            {
                NombreUsuario = UsuarioRegistro,
                Contraseña = ContraseñaRegistro,
                Apellido = ApellidoRegistro,
                Nombre = NombreRegistro,
                Mail = EmailRegistro,
                RolId = 1,
            };
            return usuario;
        }

        #region properties

        public string UsuarioRegistro
        {
            get { return txtUsuarioRegistro.Text; }
            set { txtUsuarioRegistro.Text = value; }
        }

        public string ApellidoRegistro
        {
            get { return txtApellido.Text; }
            set { txtApellido.Text = value; }
        }

        public string NombreRegistro
        {
            get { return txtNombre.Text; }
            set { txtNombre.Text = value; }
        }

        public string EmailRegistro
        {
            get { return txtEmailRegistro.Text; }
            set { txtEmailRegistro.Text = value; }
        }

        public string ContraseñaRegistro
        {
            get { return txtContraseña.Text; }
            set { txtContraseña.Text = value; }
        }

        #endregion


    }
}