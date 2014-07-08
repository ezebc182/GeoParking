using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidades;
using System.Text;
using ReglasDeNegocio;

namespace Web.Controles
{
    public partial class DomicilioControl : System.Web.UI.UserControl
    {
        GestorDireccion gestor;
        public event EventHandler ErrorHandler;

        protected void Page_Load(object sender, EventArgs e)
        {
            gestor = new GestorDireccion();
            if (!Page.IsPostBack)
            {
                CargarComboProvincias();
            }
        }
        public void CargarComboProvincias()
        {
            var lista = gestor.BuscarProvincias();
            ddlProvincia.DataSource = lista;
            ddlProvincia.DataTextField = "Nombre";
            ddlProvincia.DataValueField = "Id";
            ddlProvincia.DataBind();
            ddlProvincia.Items.Insert(0, new ListItem("Seleccione", "0"));
        }
        public void CargarComboDepartamentos()
        {
            var lista = gestor.BuscarDepartamentosPorProvinciaId(IdProvinciaSeleccionada);
            ddlDepartamento.DataSource = lista;
            ddlDepartamento.DataTextField = "Nombre";
            ddlDepartamento.DataValueField = "Id";
            ddlDepartamento.DataBind();
            ddlDepartamento.Items.Insert(0, new ListItem("Seleccione", "0"));
        }
        public void CargarComboCiudades()
        {
            var lista = gestor.BuscarCiudadesPorDepartamentoId(IdDepartamentoSeleccionado);
            ddlCiudad.DataSource = lista;
            ddlCiudad.DataTextField = "Nombre";
            ddlCiudad.DataValueField = "Id";
            ddlCiudad.DataBind();
            ddlCiudad.Items.Insert(0, new ListItem("Seleccione", "0"));
        }
        public IList<Direccion> Domicilios
        {
            get { return GetDomiciliosDesdeGrilla(); }
            set { SetDomicilioAGrilla(value); }
        }
        private void SetDomicilioAGrilla(IList<Direccion> value)
        {
            gvDomicilios.DataSource = value;
            gvDomicilios.DataBind();
        }
        private void AddDomicilio(Direccion domicilio)
        {
            var domicilios = Domicilios;
            domicilios.Add(domicilio);
            Domicilios = domicilios;
        }
        private IList<Direccion> GetDomiciliosDesdeGrilla()
        {
            IList<Direccion> domicilios = new List<Direccion>();

            foreach (GridViewRow row in gvDomicilios.Rows)
            {
                var direccion = new Direccion();

                direccion.Id = int.Parse(gvDomicilios.DataKeys[row.RowIndex].Values[0].ToString());
                direccion.Calle = row.Cells[0].Text;
                direccion.Numero = int.Parse(row.Cells[1].Text);
                direccion.CiudadId = int.Parse(gvDomicilios.DataKeys[row.RowIndex].Values[1].ToString());
                direccion.CiudadStr = row.Cells[2].Text;
                direccion.DepartamentoStr = row.Cells[3].Text;
                direccion.ProvinciaStr = row.Cells[4].Text;
                direccion.Latitud = row.Cells[5].Text;
                direccion.Longitud = row.Cells[6].Text;

                domicilios.Add(direccion);
            }
            return domicilios;
        }
        protected void OnRowCommandGvDomicilios(object sender, GridViewCommandEventArgs e)
        {
            int index = Convert.ToInt32(e.CommandArgument);
            var lista = Domicilios;

            switch (e.CommandName)
            {
                case "Quitar":
                    lista.RemoveAt(index);
                    Domicilios = lista;
                    if (lista.Count == 0) HabilitarCombos(true);
                    break;
            }
        }
        private void AgregarDomicilio(Direccion direccion)
        {
            var domicilios = Domicilios;
            foreach (var domicilio in domicilios)
            {
                if (domicilio.Calle.Equals(direccion.Calle) && domicilio.Numero == direccion.Numero)
                {
                    OnError("El domicilio ingresado ya se encuentra en la lista de domicilios");
                    return;
                }
            }
            domicilios.Add(direccion);
            Domicilios = domicilios;
        }

        private Direccion CargarEntidad()
        {
            var direccion = new Direccion();
            direccion.Ciudad = gestor.GetCiudadById(IdCiudadSeleccionada);
            direccion.Departamento = gestor.BuscarDepartamentoPorCiudadId(direccion.Ciudad.Id);
            direccion.Provincia = gestor.BuscarProvinciaPorDepartamentoId(direccion.Departamento.Id);
            direccion.Calle = Calle;
            direccion.Numero = Numero;
            return direccion;
        }

        private void SetVisibleFormulario(bool habilitar)
        {
            divSeccionFormulario.Visible = habilitar;
            divSeccionDomicilios.Visible = !habilitar;
            btnAgregarDomicilio.Visible = !habilitar;
        }

        private void HabilitarCombos(bool habilitar)
        {
            ddlCiudad.Enabled = habilitar;
            ddlDepartamento.Enabled = habilitar;
            ddlProvincia.Enabled = habilitar;
        }

        #region eventos

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            AgregarDomicilio(CargarEntidad());
            SetVisibleFormulario(false);
            HabilitarCombos(false);
        }
        #endregion
        #region properties

        public int IdProvinciaSeleccionada
        {
            get { return Convert.ToInt32(ddlProvincia.SelectedValue); }
            set { ddlProvincia.SelectedValue = value.ToString(); }
        }

        public int IdDepartamentoSeleccionado
        {
            get { return Convert.ToInt32(ddlDepartamento.SelectedValue); }
            set { ddlDepartamento.SelectedValue = value.ToString(); }
        }

        public int IdCiudadSeleccionada
        {
            get { return Convert.ToInt32(ddlCiudad.SelectedValue); }
            set { ddlCiudad.SelectedValue = value.ToString(); }
        }

        public string Calle
        {
            get { return txtCalle.Text.Trim(); }
            set { txtCalle.Text = value.Trim(); }
        }

        public int Numero
        {
            get { return Convert.ToInt32(txtNumero.Text.Trim()); }
            set { txtNumero.Text = value.ToString(); }
        }

        #endregion

        protected void ddlProvincia_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarComboDepartamentos();
        }

        protected void ddlDepartamento_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarComboCiudades();
        }

        protected void btnAgregarDomicilio_Click(object sender, EventArgs e)
        {
            SetVisibleFormulario(true);
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            SetVisibleFormulario(false);
        }

        public void OnError(String mensaje)
        {
            if (ErrorHandler != null)
                ErrorHandler.Invoke(this, new DomicilioArgs(mensaje));
        }


        public class DomicilioArgs : EventArgs
        {
            public DomicilioArgs(String error)
            {
                this.Mensaje = error;
            }

            public String Mensaje { get; set; }
        }

    }
}