using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidades;
using System.Text;
using ReglasDeNegocio;
using Web.Util;

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
            FormHelper.CargarCombo(ddlProvincia, gestor.BuscarProvincias(), "Nombre", "Id", "Seleccione");
        }
        public void CargarComboDepartamentos()
        {
            FormHelper.CargarCombo(ddlDepartamento, gestor.BuscarDepartamentosPorProvinciaId(IdProvinciaSeleccionada), "Nombre", "Id", "Seleccione");
        }
        public void CargarComboCiudades()
        {
            FormHelper.CargarCombo(ddlCiudad, gestor.BuscarCiudadesPorDepartamentoId(IdDepartamentoSeleccionado), "Nombre", "Id", "Seleccione");
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
                direccion.Latitud = row.Cells[5].Text;
                direccion.Longitud = row.Cells[6].Text;
                direccion.Ciudad = gestor.GetCiudadById(direccion.CiudadId);
                direccion.Departamento = gestor.BuscarDepartamentoPorCiudadId(direccion.CiudadId);
                direccion.Provincia = gestor.BuscarProvinciaPorDepartamentoId(direccion.Departamento.Id);
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
            if (!ValidarDomicilio(direccion)) return;
            domicilios.Add(direccion);
            Domicilios = domicilios;
        }
        private bool ValidarDomicilio(Direccion direccion)
        {

            foreach (var domicilio in Domicilios)
            {
                if (domicilio.Calle.Equals(direccion.Calle) && domicilio.Numero == direccion.Numero)
                {
                    OnError("El domicilio ingresado ya se encuentra en la lista de domicilios");
                    return false;
                }
            }
            return true;
        }

        private bool ValidarDatosIngresados()
        {
            if (IdProvinciaSeleccionada == 0 || IdDepartamentoSeleccionado == 0 || IdCiudadSeleccionada == 0 || string.IsNullOrEmpty(Calle) || Numero == -1)
            {
                OnError("Debe ingresar todos los datos requeridos.");
                return false;
            }
            return true;
        }
        private Direccion CargarEntidad()
        {
            var direccion = new Direccion();
            direccion.Ciudad = gestor.GetCiudadById(IdCiudadSeleccionada);
            direccion.CiudadId = direccion.Ciudad.Id;
            direccion.Calle = Calle;
            direccion.Numero = Numero;
            direccion.Departamento = gestor.BuscarDepartamentoPorCiudadId(direccion.CiudadId);
            direccion.Provincia = gestor.BuscarProvinciaPorDepartamentoId(direccion.Departamento.Id);
            direccion.Latitud = Latitud;
            direccion.Longitud = Longitud;
            return direccion;
        }

        public void LimpiarCampos()
        {
            IdProvinciaSeleccionada = 0;
            Calle = "";
            Numero = -1;//Con -1 se limpia el textbox
        }

        public void ConfigurarVer()
        {
            divSeccionFormulario.Visible = false;
            divSeccionDomicilios.Visible = true;
            gvDomicilios.Columns[7].Visible = false;
            btnAgregarDomicilio.Visible = false;
        }

        public void ConfigurarEditar()
        {
            divSeccionFormulario.Visible = false;
            divSeccionDomicilios.Visible = true;
            gvDomicilios.Columns[5].Visible = true;
            btnAgregarDomicilio.Visible = true;
        }

        public void ConfigurarRegistrar()
        {
            divSeccionFormulario.Visible = false;
            divSeccionDomicilios.Visible = true;
            gvDomicilios.Columns[5].Visible = true;
            btnAgregarDomicilio.Visible = true;
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
            if (!ValidarDatosIngresados()) return;
            AgregarDomicilio(CargarEntidad());
            SetVisibleFormulario(false);
            HabilitarCombos(false);
        }

        protected void btnAgregarDomicilio_Click(object sender, EventArgs e)
        {
            SetVisibleFormulario(true);
        }

        protected void btnBuscarEnMapa_Click(object sender, EventArgs e)
        {
            txtDireccion.Text = (string.IsNullOrEmpty(Calle) ? "" : Calle + " " + ( Numero != (-1) ?   Numero.ToString() : "") + ", ") + (CiudadSeleccionada != null ? CiudadSeleccionada.Nombre : "" + ", ") + (ProvinciaSeleccionada != null ? ProvinciaSeleccionada.Nombre : "");
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            SetVisibleFormulario(false);
        }


        #endregion
        #region properties

        public string Latitud
        {
            get { return txtLatitud.Text; }
            set { txtLatitud.Text = value; }
        }

        public string Longitud
        {
            get { return txtLongitud.Text; }
            set { txtLongitud.Text = value; }
        }

        public int IdProvinciaSeleccionada
        {
            get { return string.IsNullOrEmpty(ddlProvincia.SelectedValue) ? 0 : Convert.ToInt32(ddlProvincia.SelectedValue); }
            set { ddlProvincia.SelectedValue = value.ToString(); }
        }
        public Provincia ProvinciaSeleccionada
        {
            get { return IdProvinciaSeleccionada !=0? gestor.BuscarProvinciaPorId(IdProvinciaSeleccionada) : null; }
        }

        public int IdDepartamentoSeleccionado
        {
            get { return string.IsNullOrEmpty(ddlDepartamento.SelectedValue) ? 0 : Convert.ToInt32(ddlDepartamento.SelectedValue); }
            set { ddlDepartamento.SelectedValue = value.ToString(); }
        }

        public Departamento DepartamentoSeleccionado
        {
            get { return IdDepartamentoSeleccionado != 0 ? gestor.BuscarDepartamentoPorId(IdDepartamentoSeleccionado) : null; }
        }
        public int IdCiudadSeleccionada
        {
            get { return string.IsNullOrEmpty(ddlCiudad.SelectedValue)? 0 : Convert.ToInt32(ddlCiudad.SelectedValue); }
            set { ddlCiudad.SelectedValue = value.ToString(); }
        }

        public Ciudad CiudadSeleccionada
        {
            get { return IdCiudadSeleccionada != 0 ? gestor.GetCiudadById(IdCiudadSeleccionada) : null; }
        }
        public string Calle
        {
            get { return txtCalle.Text.Trim(); }
            set { txtCalle.Text = value.Trim(); }
        }

        public int Numero
        {
            get { return string.IsNullOrEmpty(txtNumero.Text)? -1 : Convert.ToInt32(txtNumero.Text.Trim()); }
            set { txtNumero.Text = value == -1 ? "" : value.ToString(); }
        }

        #endregion

        protected void ddlProvincia_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarComboDepartamentos();
            IdDepartamentoSeleccionado = 0;
        }

        protected void ddlDepartamento_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarComboCiudades();
            IdCiudadSeleccionada = 0;
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