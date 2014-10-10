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

        public int rolId;

        protected void Page_Load(object sender, EventArgs e)
        {
            gestor = new GestorUsuario();
            msjConfirmacion.Si += ConfirmarMensaje;
            msjConfirmacion.No += CancelarMensaje;
            if (!IsPostBack)
            {
                if (SessionUsuario != null)
                {
                    if (!Request.Url.AbsolutePath.Equals("/Index.aspx", StringComparison.CurrentCultureIgnoreCase))
                    {
                        if (!SessionUsuario.Rol.Permisos.Any(x => Request.Url.Segments[1].Equals(x.Url, StringComparison.CurrentCultureIgnoreCase)))
                        {
                            Response.Redirect("/Index.aspx?r=" + Request.Url.AbsolutePath);
                        }
                    }
                    lblLogin.Text = SessionUsuario.NombreUsuario;
                    rolId = SessionUsuario.RolId;
                }
                else
                {
                    if (!Request.Url.AbsolutePath.Equals("/Index.aspx", StringComparison.CurrentCultureIgnoreCase))
                    {
                            Response.Redirect("/Index.aspx?r=" + Request.Url.AbsolutePath);
                    }
                }
            }

            btnRegistrar.Enabled = false;

            // Validaciones y Carga para el Login de Usuario
            if (!string.IsNullOrEmpty(txtUsuarioLogin.Text) || !string.IsNullOrEmpty(txtContraseña.Text))
            {
                gestor.Login(txtUsuarioLogin.Text, txtContraseñaLogin.Text);
            }
        }

        #region mensajes
        #region MensajeInformacion
        /// <summary>
        /// Setea el mensaje a mostrar
        /// </summary>
        /// <param name="mensaje">Mensaje a mostrar</param>
        public void MostrarMensajeInformacion(string mensaje)
        {
            MostrarMensajeInformacion(TipoMensajeEnum.MostrarAlertaYModal, mensaje, "Mensaje");
        }
        /// <summary>
        /// Setea el mensaje a mostrar
        /// </summary>
        /// <param name="tipo">Alerta, modal o ambas</param>
        /// <param name="mensaje">mensaje</param>
        public void MostrarMensajeInformacion(TipoMensajeEnum tipo, string mensaje)
        {
            MostrarMensajeInformacion(tipo, mensaje, "Mensaje");
        }
        /// <summary>
        /// Setea el mensaje a mostrar
        /// </summary>
        /// <param name="mensaje">Mensaje</param>
        /// <param name="titulo">Titulo</param>
        public void MostrarMensajeInformacion(string mensaje, string titulo)
        {
            MostrarMensajeInformacion(TipoMensajeEnum.MostrarAlertaYModal, mensaje, titulo);
        }
        /// <summary>
        /// Setea el mensaje a mostrar
        /// </summary>
        /// <param name="tipo">Alerta, modal o ambas</param>
        /// <param name="mensaje">mensaje</param>
        /// <param name="titulo">titulo del modal</param>
        public void MostrarMensajeInformacion(TipoMensajeEnum tipo, string mensaje, string titulo)
        {
            msjInfo.MostrarMensaje(tipo, mensaje, titulo);
        }
        #endregion
        #region MensajeError
        /// <summary>
        /// Setea el mensaje a mostrar
        /// </summary>
        /// <param name="mensaje">mensaje</param>
        public void MostrarMensajeError(string mensaje)
        {
            MostrarMensajeError(TipoMensajeEnum.MostrarAlertaYModal, mensaje, "Mensaje");
        }
        /// <summary>
        /// Setea el mensaje a mostrar
        /// </summary>
        /// <param name="tipo">Alerta,modal o ambas</param>
        /// <param name="mensaje">mensaje</param>
        public void MostrarMensajeError(TipoMensajeEnum tipo, string mensaje)
        {
            MostrarMensajeError(tipo, mensaje, "Mensaje");
        }
        /// <summary>
        /// Setea el mensaje a mostrar
        /// </summary>
        /// <param name="mensaje">mensaje</param>
        /// <param name="titulo">titulo del modal</param>
        public void MostrarMensajeError(string mensaje, string titulo)
        {
            MostrarMensajeError(TipoMensajeEnum.MostrarAlertaYModal, mensaje, titulo);
        }
        /// <summary>
        /// Setea el mensaje a mostrar
        /// </summary>
        /// <param name="tipo">Alerta, Modal o Ambos</param>
        /// <param name="mensaje">mennsaje</param>
        /// <param name="titulo">titulo</param>
        public void MostrarMensajeError(TipoMensajeEnum tipo, string mensaje, string titulo)
        {
            msjError.MostrarMensaje(tipo, mensaje, titulo);
        }
        #endregion
        #region MensajeConfirmacion
        /// <summary>
        /// Setea el mensaje a mostrar
        /// </summary>
        /// <param name="mensaje">mensaje</param>
        /// <param name="eventoConfirmacion">evento que se llama si se confirma</param>
        public void MostrarMensajeConfirmacion(string mensaje, EventHandler eventoConfirmacion)
        {
            MostrarMensajeConfirmacion(mensaje, "Mensaje", eventoConfirmacion, CancelacionMensaje);
        }
        /// <summary>
        /// Setea el mensaje a mostrar
        /// </summary>
        /// <param name="mensaje">mensaje</param>
        /// <param name="eventoConfirmacion">evento que se llama si se confirma</param>
        /// <param name="eventoCancelacion">evento que se llama si no se confirma</param>
        public void MostrarMensajeConfirmacion(string mensaje, EventHandler eventoConfirmacion, EventHandler eventoCancelacion)
        {
            MostrarMensajeConfirmacion(mensaje, "Mensaje", eventoConfirmacion, eventoCancelacion);
        }
        /// <summary>
        /// Setea el mensaje a mostrar
        /// </summary>
        /// <param name="mensaje">mensaje</param>
        /// <param name="titulo">titulo</param>
        /// <param name="eventoConfirmacion">evento que se llama si se confirma</param>
        public void MostrarMensajeConfirmacion(string mensaje, string titulo, EventHandler eventoConfirmacion)
        {
            MostrarMensajeConfirmacion(mensaje, titulo, eventoConfirmacion, CancelacionMensaje);
        }
        /// <summary>
        /// Setea el mensaje a mostrar
        /// </summary>
        /// <param name="mensaje">mensaje</param>
        /// <param name="titulo">titulo</param>
        /// <param name="eventoConfirmacion">evento que se llama si se confirma</param>
        /// <param name="eventoCancelacion">evento que se llama si no se confirma</param>
        public void MostrarMensajeConfirmacion(string mensaje, string titulo, EventHandler eventoConfirmacion, EventHandler eventoCancelacion)
        {
            ConfirmarMensaje = eventoConfirmacion;
            CancelarMensaje = eventoCancelacion;
            msjConfirmacion.MostrarMensaje(mensaje, titulo);
        }
        #endregion
        /// <summary>
        /// Guarda el evento que se debe llamar si se confirma
        /// </summary>
        public EventHandler ConfirmarMensaje
        {
            get { return (EventHandler)Session["EventoConfirmacion"]; }
            set { Session["EventoConfirmacion"] = value; }
        }
        /// <summary>
        /// Guarda el evento que se debe llamar si no se confirma
        /// </summary>
        public EventHandler CancelarMensaje
        {
            get { return (EventHandler)Session["EventoCancelacion"]; }
            set { Session["EventoCancelacion"] = value; }
        }
        #endregion
        protected void ConfirmacionMensaje(object sender, EventArgs e) { }
        protected void CancelacionMensaje(object sender, EventArgs e) { }

        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (txtApellido.Text != "" && txtNombre.Text != "" && txtContraseña.Text != "" && txtContraseñaRepetir.Text != ""
                && txtEmailRegistro.Text != "" && txtUsuarioRegistro.Text != "")
            {
                Usuario usuario = CargarEntidad();
                var resultado = gestor.RegistrarUsuario(usuario);
                MostrarMensajeInformacion(TipoMensajeEnum.MensajeModal,"El usuario "+ usuario.NombreUsuario +" se ha registrado con exito!!" , "Registro de Usuario");
            }
        }

        protected void btnIniciarSesion_Click(object sender, EventArgs e)
        {
            ValidarCampos();
            var guardarContraseña = txtContraseñaLogin.Text;
            var resultado = gestor.Login(txtUsuarioLogin.Text, txtContraseñaLogin.Text);
            if (resultado != null)
            {
                SessionUsuario = resultado;
                lblLogin.Text = SessionUsuario.NombreUsuario;
                Response.Redirect(Request.Url.AbsolutePath);
            }
            else
            {
                ValidarCampos();
                pass.Value = txtContraseñaLogin.Text;
            }
        }

        private void ValidarCampos()
        {
            if (string.IsNullOrWhiteSpace(txtContraseñaLogin.Text) && !string.IsNullOrWhiteSpace(txtUsuarioLogin.Text))
            {
                divContraseñaLogin.Attributes["class"] = "form-group has-feedback has-error";
                iconContraseñaLogin.Attributes["style"] = "top: 7px; display: block;";
                lblContraseñaLogin.Text = "Debe ingresar una contraseña";
                divUsuarioLogin.Attributes["class"] = "form-group";
                iconUsuarioLogin.Attributes["style"] = "none";
                iconUsuarioLogin.Attributes["class"] = "";
                lblUsuarioLogin.Text = "";
            }
            if (string.IsNullOrWhiteSpace(txtUsuarioLogin.Text))
            {
                divUsuarioLogin.Attributes["class"] = "form-group has-feedback has-error";
                iconUsuarioLogin.Attributes["style"] = "top: 7px; display: block;";
                iconUsuarioLogin.Attributes["class"] = "form-control-feedback glyphicon glyphicon-remove";
                lblUsuarioLogin.Text = "Debe ingresar un usuario o e-mail";
                divContraseñaLogin.Attributes["class"] = "form-group";
                iconContraseñaLogin.Attributes["class"] = "";
                iconContraseñaLogin.Attributes["style"] = "none";
                lblContraseñaLogin.Text = "";

            }
            if (!string.IsNullOrWhiteSpace(txtContraseñaLogin.Text) && !string.IsNullOrWhiteSpace(txtUsuarioLogin.Text))
            {
                divUsuarioLogin.Attributes["class"] = "form-group has-feedback has-error";
                iconUsuarioLogin.Attributes["style"] = "top: 7px; display: block;";
                iconUsuarioLogin.Attributes["class"] = "form-control-feedback glyphicon glyphicon-remove";
                lblUsuarioLogin.Text = "";
                divContraseñaLogin.Attributes["class"] = "form-group has-feedback has-error";
                iconContraseñaLogin.Attributes["style"] = "top: 7px; display: block;";
                iconContraseñaLogin.Attributes["class"] = "form-control-feedback glyphicon glyphicon-remove";
                lblContraseñaLogin.Text = "Usuario y/o contraseña incorrectos";
            }
        }

        public Usuario CargarEntidad()
        {
            Usuario usuario = new Usuario
            {
                NombreUsuario = UsuarioRegistro,
                Contraseña = gestor.Encriptar(ContraseñaRegistro),
                Apellido = ApellidoRegistro,
                Nombre = NombreRegistro,
                Mail = EmailRegistro,
                RolId = gestor.BuscarRoles().First().Id,
            };
            return usuario;
        }

        #region properties

        public Usuario SessionUsuario
        {
            get { return (Usuario)Session["Usuario"]; }
            set { Session["Usuario"] = value; }
        }

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

        protected void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            SessionUsuario = null;
            rolId = 0;

            string[] segmentosURL = HttpContext.Current.Request.Url.Segments;
            string pagina = segmentosURL[segmentosURL.Length - 1];

            if (pagina == "Playa.aspx" || pagina == "AdministracionUsuarios.aspx")
            {
                Response.Redirect("Index.aspx");
            }

        }

        protected void txtUsuarioRegistro_TextChanged(object sender, EventArgs e)
        {
            var resultado = gestor.ValidarUsuarioIngresado(txtUsuarioRegistro.Text);
            if (resultado != null)
            {

            }
        }

    }
}