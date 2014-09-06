﻿using System;
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
        GestorRol gestorRol;

        protected void Page_Load(object sender, EventArgs e)
        
        {
            gestor = new GestorUsuario();
            msjConfirmacion.Si += ConfirmarMensaje;
            msjConfirmacion.No += CancelarMensaje;

            if (SessionUsuario != null)
            {
                lblLogin.Text = SessionUsuario.NombreUsuario;
               
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
        public void MostrarMensajeError( string mensaje)
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
                var resultado = gestor.Login(txtUsuarioLogin.Text, txtContraseñaLogin.Text);
                if (resultado != null)
                {
                    SessionUsuario = resultado;
                    lblLogin.Text = SessionUsuario.NombreUsuario;
                    Response.Redirect(Request.RawUrl); 
                }
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

        private void OcultarOpciones(int id)
        {
           var resultado = gestorRol.BuscarPermisosPorRol(gestorRol.BuscarRol(id));
           foreach (var item in resultado)
	        {
		        switch (item.Id)
	            {
                    case 1: 
                    break;
                    case 2:
                    break;
                    case 3:
                    break;
                    case 4:
                    break;
                    case 5:
                    break;
                    case 6:
                    break;
                }
	        }
        }

        #endregion

        protected void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            SessionUsuario = null;
        }

    }
}