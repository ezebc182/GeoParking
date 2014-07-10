using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ReglasDeNegocio;
using Entidades;
using Web.Util;

namespace Web.Controles
{
    public partial class ServicioControl : System.Web.UI.UserControl
    {
        GestorPlaya gestor;
        public event EventHandler ErrorHandler;

        protected void Page_Load(object sender, EventArgs e)
        {
            gestor = new GestorPlaya();
            if (!Page.IsPostBack)
            {
                CargarCombos();
            }
        }

        public void CargarCombos()
        {
            FormHelper.CargarCombo(ddlTipoVehiculo, gestor.BuscarTipoVehiculos(), "Nombre", "Id", "Seleccione");
        }
        public IList<Servicio> Servicios
        {
            get { return GetServiciosDesdeGrilla(); }
            set { SetServicioAGrilla(value); }
        }

        private void SetServicioAGrilla(IList<Servicio> value)
        {
            gvServicios.DataSource = value;
            gvServicios.DataBind();
        }
        private void AddServicio(Servicio servicio)
        {
            var servicios = Servicios;
            servicios.Add(servicio);
            Servicios = servicios;
        }
        private IList<Servicio> GetServiciosDesdeGrilla()
        {
            IList<Servicio> servicios = new List<Servicio>();

            foreach (GridViewRow row in gvServicios.Rows)
            {
                var servicio = new Servicio();

                servicio.Id = int.Parse(gvServicios.DataKeys[row.RowIndex].Values[0].ToString());
                servicio.TipoVehiculoId = int.Parse(gvServicios.DataKeys[row.RowIndex].Values[1].ToString());
                servicio.TipoVehiculo = gestor.BuscarTipoVehiculo(servicio.TipoVehiculoId);
                servicio.TipoVehiculoStr = row.Cells[0].Text;
                servicio.Capacidad = int.Parse(row.Cells[1].Text);

                servicios.Add(servicio);
            }
            return servicios;
        }
        protected void OnRowCommandGvServicios(object sender, GridViewCommandEventArgs e)
        {
            int index = Convert.ToInt32(e.CommandArgument);
            var lista = Servicios;

            switch (e.CommandName)
            {
                case "Quitar":
                    lista.RemoveAt(index);
                    Servicios = lista;
                    break;
            }
        }
        private void AgregarServicio(Servicio servicio)
        {
            var servicios = Servicios;
            if (!ValidarServicio(servicio)) return;
            servicios.Add(servicio);
            Servicios = servicios;
        }
        private bool ValidarServicio(Servicio servicio)
        {

            foreach (var item in Servicios)
            {
                if (item.TipoVehiculoId == servicio.TipoVehiculoId)
                {
                    OnError("Ya se ha cargado la capacidad para el tipo de vehiculo seleccionado.");
                    return false;
                }
            }
            return true;
        }
        private bool ValidarDatosIngresados()
        {
            if (IdVehiculoSeleccionado == 0 || Capacidad == null)
            {
                OnError("Debe ingresar todos los datos requeridos.");
                return false;
            }
            return true;
        }
        private Servicio CargarEntidad()
        {

            var servicio = new Servicio();
            servicio.TipoVehiculo = gestor.BuscarTipoVehiculo(IdVehiculoSeleccionado);
            servicio.Capacidad = Capacidad.Value;
            return servicio;
        }

        public void LimpiarCampos()
        {
            IdVehiculoSeleccionado = 0;
            Capacidad = null;
        }

        private void SetVisibleFormulario(bool habilitar)
        {
            divSeccionFormulario.Visible = habilitar;
            divSeccionServicios.Visible = !habilitar;
            btnAgregarServicio.Visible = !habilitar;
        }

        public void ConfigurarVer()
        {
            divSeccionFormulario.Visible = false;
            divSeccionServicios.Visible = true;
            gvServicios.Columns[2].Visible = false;
            btnAgregarServicio.Visible = false;
        }

        public void ConfigurarEditar()
        {
            divSeccionFormulario.Visible = false;
            divSeccionServicios.Visible = true;
            gvServicios.Columns[2].Visible = true;
            btnAgregarServicio.Visible = true;
        }

        public void ConfigurarRegistrar()
        {
            divSeccionFormulario.Visible = false;
            divSeccionServicios.Visible = true;
            gvServicios.Columns[2].Visible = true;
            btnAgregarServicio.Visible = true;
        }
        #region eventos

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!ValidarDatosIngresados()) return;
            AgregarServicio(CargarEntidad());
            SetVisibleFormulario(false);
        }

        protected void btnAgregarServicio_Click(object sender, EventArgs e)
        {
            SetVisibleFormulario(true);
            LimpiarCampos();
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            SetVisibleFormulario(false);
        }

        #endregion
        #region properties

        public int IdVehiculoSeleccionado
        {
            get { return Convert.ToInt32(ddlTipoVehiculo.SelectedValue); }
            set { ddlTipoVehiculo.SelectedValue = value.ToString(); }
        }

        public int? Capacidad
        {
            get { return FormHelper.ObtenerNullableEntero(txtCapacidad); }
            set { txtCapacidad.Text = value == null ? "" : value.ToString(); }
        }

        #endregion


        public void OnError(String mensaje)
        {
            if (ErrorHandler != null)
                ErrorHandler.Invoke(this, new ServicioArgs(mensaje));
        }


        public class ServicioArgs : EventArgs
        {
            public ServicioArgs(String error)
            {
                this.Mensaje = error;
            }

            public String Mensaje { get; set; }
        }

    }

}