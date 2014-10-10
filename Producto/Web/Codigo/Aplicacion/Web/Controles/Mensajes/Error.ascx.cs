using System;
using System.Web.UI;
using Web.Util;

namespace SIRAD.Web.Controls.Alerts
{
    public partial class ErrorAlert : UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
                Alert.Visible = false;
         }
        /// <summary>
        /// Setea el mensaje de error
        /// </summary>
        public string Mensaje
        {
            get { return lblMensaje.InnerHtml; }
            set
            {
                lblMensaje.InnerHtml = value;
                lblMensajeModal.InnerHtml = value;
            }
        }
        public string Titulo
        {
            get { return lblTitulo.InnerHtml; }
            set
            {
                lblTitulo.InnerHtml = value;
            }
        }
        public void MostrarMensaje(string msj)
        {
            MostrarMensaje(TipoMensajeEnum.MostrarAlertaYModal, BotonesEnum.Aceptar, msj, "Error");
        }

        public void MostrarMensaje(string msj, string titulo)
        {
            MostrarMensaje(TipoMensajeEnum.MostrarAlertaYModal, BotonesEnum.Aceptar, msj, titulo);
        }
        
        public void MostrarMensaje(TipoMensajeEnum tipo, string msj, string titulo)
        {
            MostrarMensaje(tipo, BotonesEnum.Aceptar, msj, titulo);
        }

        public void MostrarMensaje(TipoMensajeEnum tipo, BotonesEnum botones, string msj, string titulo)
        {
            Mensaje = msj;
            Titulo = titulo;
            switch (tipo)
            {
                case TipoMensajeEnum.MensajeAlerta: 
                    MostrarAlert();
                    break;
                case TipoMensajeEnum.MensajeModal:
                    MostrarModal();
                    break;
                case TipoMensajeEnum.MostrarAlertaYModal:
                    MostrarAlert();
                    MostrarModal();
                    break;               
            }
        }
        /// <summary>
        /// Muestra el mensaje de error en el margen superior de la pagina
        /// </summary>
        private void MostrarAlert()
        {
            Alert.Visible = true;
        }
        /// <summary>
        /// Oculta el mensaje de error en el margen superior de la pagina
        /// </summary>
        public void OcultarAlert()
        {
            Alert.Visible = false;
        }
        /// <summary>
        /// Muestra el mensaje de error en un modal
        /// </summary>
        private void MostrarModal()
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "MensajeModal", "$(function() { Alerta_openModalError(); });", true);
        }
        
    }
}