using System;
using System.Web.UI;
using Web.Util;

namespace SIRAD.Web.Controls.Alerts
{
    public partial class Confirmacion : UserControl
    {
        public event EventHandler Si;
        public event EventHandler No;

        protected void Page_Load(object sender, EventArgs e)
        {
            Alert.Visible = false;
            if (!Page.IsPostBack)
            {
                //Si = null;
                //No = null;
            }
        }
        /// <summary>
        /// Setea el mensaje de error
        /// </summary>
        public string Mensaje
        {
            get { return lblMensaje.Text; }
            set
            {
                lblMensaje.Text = value;
                lblMensajeModal.Text = value;
            }
        }

        public string Titulo
        {
            get { return lblTitulo.Text; }
            set
            {
                lblTitulo.Text = value;
            }
        }

        public void MostrarMensaje(string mensaje, string titulo)
        {
            Mensaje = mensaje;
            Titulo = titulo;

            MostrarModal();
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
            ScriptManager.RegisterStartupScript(this, this.GetType(), "MensajeModal", "$(function() { Alerta_openModalConfirmacion(); });", true);
        }

        protected void btnSi_Click(object sender, EventArgs e)
        {
            if (Si != null)
                Si.Invoke(this, e);
        }

        protected void btnNo_Click(object sender, EventArgs e)
        {
            if (No != null)
                No.Invoke(this, e);
        }
    }
}