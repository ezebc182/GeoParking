using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidades;
using ReglasDeNegocio;
using Web.Util;

namespace Web
{
    public partial class SiteMaster : System.Web.UI.MasterPage
    {
        GestorUsuario gestor;

        protected void Page_Load(object sender, EventArgs e)
        {
            gestor = new GestorUsuario();
            msjConfirmacion.Si += ConfirmarMensaje;
        }

        #region mensajes
        public void MostrarMensaje(string mensaje)
        {
            MostrarMensaje(MensajeEnum.Info, TipoMensajeEnum.MostrarAlertaYModal, mensaje, "Mensaje");
        }
        public void MostrarMensaje(MensajeEnum msj, string mensaje)
        {
            MostrarMensaje(msj, TipoMensajeEnum.MostrarAlertaYModal, mensaje, "Mensaje");
        }
        public void MostrarMensaje(MensajeEnum msj, TipoMensajeEnum tipo, string mensaje)
        {
            MostrarMensaje(msj, tipo, mensaje, "Mensaje");
        }
        public void MostrarMensaje(MensajeEnum msj, string mensaje, string titulo)
        {
            MostrarMensaje(msj, TipoMensajeEnum.MostrarAlertaYModal, mensaje, titulo);
        }

        public void MostrarMensaje(MensajeEnum msj, TipoMensajeEnum tipo, string mensaje, string titulo)
        {
            switch (msj)
            {
                case MensajeEnum.Confirmacion: msjConfirmacion.MostrarMensaje(tipo, mensaje, titulo);
                    break;
                case MensajeEnum.Error: msjError.MostrarMensaje(tipo, mensaje, titulo);
                    break;
                case MensajeEnum.Info:
                    break;
            }
        }

        public EventHandler ConfirmarMensaje
        {
            get { return (EventHandler)Session["EventoConfirmacion"]; }
            set { Session["EventoConfirmacion"] = value; }
        }
        #endregion

        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (txtApellido.Text != "" && txtNombre.Text != "" && txtContraseña.Text != "" && txtContraseñaRepetir.Text != ""
                && txtEmailRegistro.Text != "" && txtUsuarioRegistro.Text != "")
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