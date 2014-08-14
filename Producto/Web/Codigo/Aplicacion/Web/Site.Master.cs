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
        #region MensajeInformacion
        public void MostrarMensajeInformacion(string mensaje)
        {
            MostrarMensajeInformacion(TipoMensajeEnum.MostrarAlertaYModal, mensaje, "Mensaje");
        }
        
        public void MostrarMensajeInformacion(TipoMensajeEnum tipo, string mensaje)
        {
            MostrarMensajeInformacion(tipo, mensaje, "Mensaje");
        }
        public void MostrarMensajeInformacion(string mensaje, string titulo)
        {
            MostrarMensajeInformacion(TipoMensajeEnum.MostrarAlertaYModal, mensaje, titulo);
        }

        public void MostrarMensajeInformacion(TipoMensajeEnum tipo, string mensaje, string titulo)
        {
            msjInfo.MostrarMensaje(tipo, mensaje, titulo);
        }
#endregion
        #region MensajeError
        
        public void MostrarMensajeError( string mensaje)
        {
            MostrarMensajeError(TipoMensajeEnum.MostrarAlertaYModal, mensaje, "Mensaje");
        }
        public void MostrarMensajeError(TipoMensajeEnum tipo, string mensaje)
        {
            MostrarMensajeError(tipo, mensaje, "Mensaje");
        }
        public void MostrarMensajeError(string mensaje, string titulo)
        {
            MostrarMensajeError(TipoMensajeEnum.MostrarAlertaYModal, mensaje, titulo);
        }

        public void MostrarMensajeError(TipoMensajeEnum tipo, string mensaje, string titulo)
        {
            msjError.MostrarMensaje(tipo, mensaje, titulo);
        }
        #endregion
        #region MensajeConfirmacion
        public void MostrarMensajeConfirmacion(string mensaje, EventHandler eventoConfirmacion)
        {
            MostrarMensajeConfirmacion(mensaje, "Mensaje", eventoConfirmacion, CancelacionMensaje);
        }
        public void MostrarMensajeConfirmacion(string mensaje, EventHandler eventoConfirmacion, EventHandler eventoCancelacion)
        {
            MostrarMensajeConfirmacion(mensaje, "Mensaje", eventoConfirmacion, eventoCancelacion);
        }

        public void MostrarMensajeConfirmacion(string mensaje, string titulo, EventHandler eventoConfirmacion)
        {
            MostrarMensajeConfirmacion(mensaje, titulo, eventoConfirmacion, CancelacionMensaje);
        }
        public void MostrarMensajeConfirmacion(string mensaje, string titulo, EventHandler eventoConfirmacion, EventHandler eventoCancelacion)
        {
            ConfirmarMensaje = eventoConfirmacion;
            CancelarMensaje = eventoCancelacion;
            msjConfirmacion.MostrarMensaje(mensaje, titulo);
        }
        #endregion
        public EventHandler ConfirmarMensaje
        {
            get { return (EventHandler)Session["EventoConfirmacion"]; }
            set { Session["EventoConfirmacion"] = value; }
        }
        public EventHandler CancelarMensaje
        {
            get { return (EventHandler)Session["EventoCancelacion"]; }
            set { Session["EventoCancelacion"] = value; }
        }
        #endregion
        protected void ConfirmacionMensaje(object sender, EventArgs e){}
        protected void CancelacionMensaje(object sender, EventArgs e){}
        
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