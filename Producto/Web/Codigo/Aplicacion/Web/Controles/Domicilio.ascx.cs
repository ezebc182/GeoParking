using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidades;
using System.Text;
using ReglasDeNegocio;
using Web2.Util;

namespace Web2.Controles
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
        /// <summary>
        /// Carga el combo de provincias
        /// </summary>
        public void CargarComboProvincias()
        {
            FormHelper.CargarCombo(ddlProvincia, ((IList<Provincia>)gestor.BuscarProvincias()).OrderBy(p => p.Nombre), "Nombre", "Id", "Seleccione");
        }
        /// <summary>
        /// Carga el combo de departamentos, con los departamentos pertenecientes a la provincia seleccionada
        /// </summary>
        public void CargarComboDepartamentos()
        {
            FormHelper.CargarCombo(ddlDepartamento, ((IList<Departamento>)gestor.BuscarDepartamentosPorProvinciaId(IdProvinciaSeleccionada)).OrderBy(d => d.Nombre), "Nombre", "Id", "Seleccione");
        }
        /// <summary>
        /// Carga el combo de ciudades, con las ciudades pertenecientes al departamento seleccionado
        /// </summary>
        public void CargarComboCiudades()
        {
            FormHelper.CargarCombo(ddlCiudad, ((IList<Ciudad>)(gestor.BuscarCiudadesPorDepartamentoId(IdDepartamentoSeleccionado))).OrderBy(c => c.Nombre), "Nombre", "Id", "Seleccione");
        }


        /// <summary>
        /// Agrega una lista de domicilios a la grilla de domicilios
        /// </summary>
        /// <param name="value"></param>
        private void SetDomiciliosAGrilla(IList<Direccion> value)
        {
            gvDomicilios.DataSource = value;
            gvDomicilios.DataBind();
        }
        /// <summary>
        /// Obtiene los domicilios desde la grilla
        /// </summary>
        /// <returns>Lista de direcciones</returns>
        private IList<Direccion> ObtenerDomiciliosDesdeGrilla()
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
                direccion.Ciudad = gestor.BuscarCiudadPorId(direccion.CiudadId);
                direccion.Departamento = gestor.BuscarDepartamentoPorCiudadId(direccion.CiudadId);
                direccion.Provincia = gestor.BuscarProvinciaPorDepartamentoId(direccion.Departamento.Id);
                domicilios.Add(direccion);
            }
            return domicilios;
        }
        /// <summary>
        /// Agrega un domicilio a la grilla de domicilios
        /// </summary>
        /// <param name="direccion"></param>
        private void AgregarDomicilio(Direccion direccion)
        {
            var domicilios = Domicilios;
            if (!ValidarDomicilio(direccion)) return;
            domicilios.Add(direccion);
            Domicilios = domicilios;
            HabilitarFormularioDomicilio(false);
        }
        /// <summary>
        /// Valida que el domicilio ingresado no exista previamente.
        /// </summary>
        /// <param name="direccion">Domicilio a validar</param>
        /// <returns></returns>
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
        /// <summary>
        /// Valida que se hayan ingresado todos los datos necesarios.
        /// </summary>
        /// <returns></returns>
        private bool ValidarDatosIngresados()
        {
            if (IdProvinciaSeleccionada == 0 || IdDepartamentoSeleccionado == 0 || IdCiudadSeleccionada == 0 || string.IsNullOrEmpty(Calle) || Numero == null)
            {
                OnError("Debe ingresar todos los datos requeridos.");
                return false;
            }
            return true;
        }
        /// <summary>
        /// Carga una entidad Direccion a partir de los datos ingresados en el formulario.
        /// </summary>
        /// <returns>Direccion</returns>
        private Direccion CargarEntidad()
        {
            var direccion = new Direccion();
            direccion.Ciudad = gestor.BuscarCiudadPorId(IdCiudadSeleccionada);
            direccion.CiudadId = direccion.Ciudad.Id;
            direccion.Calle = Calle;
            direccion.Numero = Numero.Value;
            direccion.Departamento = gestor.BuscarDepartamentoPorCiudadId(direccion.CiudadId);
            direccion.Provincia = gestor.BuscarProvinciaPorDepartamentoId(direccion.Departamento.Id);
            direccion.Latitud = Latitud;
            direccion.Longitud = Longitud;
            return direccion;
        }
        /// <summary>
        /// Limpia los campos del formulario, para registrar un nuevo domicilio.
        /// </summary>
        public void LimpiarCampos()
        {
            if (Domicilios.Count == 0)
            {
                HabilitarCombos(true);
                LimpiarCombos();
                IdProvinciaSeleccionada = 0;
                Calle = "";
                Numero = null;
            }
            else
            {
                HabilitarCombos(false);
                IdProvinciaSeleccionada = Domicilios[0].Provincia.Id;
                CargarComboDepartamentos();
                IdDepartamentoSeleccionado = Domicilios[0].Departamento.Id;
                CargarComboCiudades();
                IdCiudadSeleccionada = Domicilios[0].Ciudad.Id;
            }
        }

        /// <summary>
        /// Limpia los combos.
        /// </summary>
        public void LimpiarCombos()
        {
            LimpiarCombo(ddlCiudad);
            LimpiarCombo(ddlDepartamento);
            HabilitarCombos(true);
        }

        public void LimpiarCombo(DropDownList combo)
        {
            if (combo.Items != null) combo.SelectedIndex = -1;
            FormHelper.LimpiarCombo(combo);
        }

        /// <summary>
        /// Establece las propiedades de los controles para cuando el usuario esta viendo.
        /// </summary>
        public void ConfigurarVer()
        {
            FormHelper.CambiarVisibilidadControl(divSeccionFormulario1, false);
            FormHelper.CambiarVisibilidadControl(divSeccionFormulario2, false);
            FormHelper.CambiarVisibilidadControl(divSeccionGrillaDomicilios, true);
            FormHelper.CambiarVisibilidadControl(btnAgregarDomicilio, false);
            gvDomicilios.Columns[7].Visible = false;
        }
        /// <summary>
        /// Establece las propiedades de los controles para cuando el usuario esta editando.
        /// </summary>
        public void ConfigurarEditar()
        {
            FormHelper.CambiarVisibilidadControl(divSeccionFormulario1, false);
            FormHelper.CambiarVisibilidadControl(divSeccionFormulario2, false);
            FormHelper.CambiarVisibilidadControl(divSeccionGrillaDomicilios, true);
            FormHelper.CambiarVisibilidadControl(btnAgregarDomicilio, true);
            gvDomicilios.Columns[7].Visible = true;
        }
        /// <summary>
        /// Establece las propiedades de los controles para cuando el usuario esta registrando.
        /// </summary>
        public void ConfigurarRegistrar()
        {
            FormHelper.CambiarVisibilidadControl(divSeccionFormulario1, false);
            FormHelper.CambiarVisibilidadControl(divSeccionFormulario2, false);
            FormHelper.CambiarVisibilidadControl(divSeccionGrillaDomicilios, true);
            FormHelper.CambiarVisibilidadControl(btnAgregarDomicilio, true);
            gvDomicilios.Columns[7].Visible = true;
        }

        /// <summary>
        /// Habilita o deshabilita los combos
        /// </summary>
        /// <param name="habilitar">true = habilitar; false = deshabilitar</param>
        private void HabilitarCombos(bool habilitar)
        {
            ddlCiudad.Enabled = habilitar;
            ddlDepartamento.Enabled = habilitar;
            ddlProvincia.Enabled = habilitar;
        }

        public void HabilitarFormularioDomicilio(bool habilitar)
        {
            FormHelper.CambiarVisibilidadControl(divSeccionFormulario1, habilitar);
            FormHelper.CambiarVisibilidadControl(divSeccionFormulario2, habilitar);
            FormHelper.CambiarVisibilidadControl(divSeccionGrillaDomicilios, !habilitar);
            FormHelper.CambiarVisibilidadControl(btnAgregarDomicilio, !habilitar);
        }
        #region eventos
        #region grilla
        /// <summary>
        /// Se ejecuta cuando se presiona un boton de la grilla
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
        #endregion
        #region controles
        /// <summary>
        /// Valida y agrega un domicilio a la grilla
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!ValidarDatosIngresados()) return;
            AgregarDomicilio(CargarEntidad());
            HabilitarCombos(false);
            HabilitarFormularioDomicilio(false);
        }
        /// <summary>
        /// Limpia los campos del formulario para registrar un nuevo domicilio
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnAgregarDomicilio_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
            HabilitarFormularioDomicilio(true);
        }

        /// <summary>
        /// Se ejecuta cuando se modifica el elemento seleccionado en el combo provincias
        /// Carga el combo de departamentos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ddlProvincia_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarComboDepartamentos();
            IdDepartamentoSeleccionado = 0;
            ddlDepartamento.Enabled = true;
            LimpiarCombo(ddlCiudad);
            ddlCiudad.Enabled = false;
        }


        /// <summary>
        /// Se ejecuta cuando se modifica el elemento seleccionado en el combo departamentos
        /// carga el combo de ciudades
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ddlDepartamento_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarComboCiudades();
            IdCiudadSeleccionada = 0;
            ddlCiudad.Enabled = true;
        }

        #endregion
        #endregion
        #region properties
        /// <summary>
        /// Obtiene o establece los domicilios agregados
        /// </summary>
        public IList<Direccion> Domicilios
        {
            get { return ObtenerDomiciliosDesdeGrilla(); }
            set { SetDomiciliosAGrilla(value); }
        }
        /// <summary>
        /// Obtiene o establece la latitud de la direccion
        /// </summary>
        public string Latitud
        {
            get { return latitud.Text; }
            set { latitud.Text = value; }
        }
        /// <summary>
        /// Obtiene o establece la longitud de la direccion
        /// </summary>
        public string Longitud
        {
            get { return longitud.Text; }
            set { longitud.Text = value; }
        }
        /// <summary>
        /// Obtiene o establece el Id de la provincia seleccionada en el combo provincias
        /// </summary>
        public int IdProvinciaSeleccionada
        {
            get { return string.IsNullOrEmpty(ddlProvincia.SelectedValue) ? 0 : Convert.ToInt32(ddlProvincia.SelectedValue); }
            set { ddlProvincia.SelectedValue = value.ToString(); }
        }
        /// <summary>
        /// Obtiene la provincia seleccionada en el combo provincias
        /// </summary>
        public Provincia ProvinciaSeleccionada
        {
            get { return IdProvinciaSeleccionada != 0 ? gestor.BuscarProvinciaPorId(IdProvinciaSeleccionada) : null; }
        }
        /// <summary>
        /// Obtiene o estableces el id del departamento seleccionado en el combo departamentos
        /// </summary>
        public int IdDepartamentoSeleccionado
        {
            get { return string.IsNullOrEmpty(ddlDepartamento.SelectedValue) ? 0 : Convert.ToInt32(ddlDepartamento.SelectedValue); }
            set { ddlDepartamento.SelectedValue = value.ToString(); }
        }
        /// <summary>
        /// Obtiene el departamento seleccionado en el combo departamentos
        /// </summary>
        public Departamento DepartamentoSeleccionado
        {
            get { return IdDepartamentoSeleccionado != 0 ? gestor.BuscarDepartamentoPorId(IdDepartamentoSeleccionado) : null; }
        }
        /// <summary>
        /// Obtiene o establece el id de la ciudad seleccionada
        /// </summary>
        public int IdCiudadSeleccionada
        {
            get { return string.IsNullOrEmpty(ddlCiudad.SelectedValue) ? 0 : Convert.ToInt32(ddlCiudad.SelectedValue); }
            set { ddlCiudad.SelectedValue = value.ToString(); }
        }
        /// <summary>
        /// Obtiene la ciudad seleccionada en el combo ciudades
        /// </summary>
        public Ciudad CiudadSeleccionada
        {
            get { return IdCiudadSeleccionada != 0 ? gestor.BuscarCiudadPorId(IdCiudadSeleccionada) : null; }
        }
        /// <summary>
        /// Obtiene o establece la calle de la direccion
        /// </summary>
        public string Calle
        {
            get { return txtCalle.Text.Trim(); }
            set { txtCalle.Text = value.Trim(); }
        }
        /// <summary>
        /// Obtiene o establece el numero de la direccion
        /// </summary>
        public int? Numero
        {
            get { return FormHelper.ObtenerNullableEntero(txtNumero); }
            set { txtNumero.Text = value == null ? "" : value.ToString(); }
        }

        #endregion


        /// <summary>
        /// lanza el evento OnErrorHandler
        /// </summary>
        /// <param name="mensaje"></param>
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

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            HabilitarFormularioDomicilio(false);
        }

    }
}