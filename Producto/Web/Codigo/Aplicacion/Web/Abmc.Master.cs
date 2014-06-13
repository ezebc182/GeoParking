using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace appWeb1.app
{
    public partial class Abmc : System.Web.UI.MasterPage
    {
        #region ABMC View Events

        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Form.DefaultButton = btnConsultar.UniqueID;
        }

        #endregion

        #region ABMC View Properties

        public string Estado
        {
            get { return lblEstado.Text; }
            set { lblEstado.Text = value; }
        }

        public string Entidad
        {
            get { return lblEntidad.Text; }
            set { lblEntidad.Text = value; }
        }

        public bool SectionConsultaVisible
        {
            get { return secConsulta.Visible; }
            set
            {
                btnAgregar.Visible = value;
                secConsulta.Visible = value;

            }
        }

        public bool SectionResultadoBusquedaVisible
        {
            get { return secResultadoBusqueda.Visible; }
            set { secResultadoBusqueda.Visible = value; }
        }

        public bool SectionFormularioVisible
        {
            get { return secFormulario.Visible; }
            set
            {
                btnAgregar.Visible = !value;
                secFormulario.Visible = value;

            }
        }

        public bool ButtonAceptarVisible
        {
            get { return btnAceptar.Visible; }
            set { btnAceptar.Visible = value; }
        }

        public bool ButtonConsultarVisible
        {
            get { return btnConsultar.Visible; }
            set { btnConsultar.Visible = value; }
        }


        public string ButtonCancelarText
        {
            get { return btnCancelar.Text; }
            set { btnCancelar.Text = value; }
        }

        public int TotalRegistros
        {
            set
            {
                lblTotalRegistros.Text = value.ToString();
                pTotalRegistros.Visible = true;//value != 0;
            }
        }

        #endregion

        #region ABMC View Buttons

        public EventHandler ButtonConsultarHandler
        {
            set { btnConsultar.Click += value; }
        }

        public EventHandler ButtonAgregarHandler
        {
            set { btnAgregar.Click += value; }
        }

        public EventHandler ButtonAceptarHandler
        {
            set { btnAceptar.Click += value; }
        }

        public EventHandler ButtonCancelarHandler
        {
            set { btnCancelar.Click += value; }
        }

        #endregion

        public void LimpiarCamposConsulta()
        {
            LimpiarCampos(secConsulta.Controls);
        }

        public void LimpiarCamposFormulario()
        {
            LimpiarCampos(secFormulario.Controls);
        }

        public void LimpiarCampos(ControlCollection controles)
        {
            foreach (Control control in controles)
            {
                if (control is TextBox)
                    ((TextBox)control).Text = string.Empty;

                if (control is HiddenField)
                    ((HiddenField)control).Value = string.Empty;

                else if (control is DropDownList)
                    ((DropDownList)control).ClearSelection();

                else if (control is RadioButton)
                    ((RadioButton)control).Checked = false;

                else if (control is CheckBox)
                    ((CheckBox)control).Checked = false;

                LimpiarCampos(control.Controls);
            }
        }
    }
}