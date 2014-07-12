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
        GestorServicio gestor;
        public event EventHandler ErrorHandler;

        protected void Page_Load(object sender, EventArgs e)
        {
            gestor = new GestorServicio();
            if (!Page.IsPostBack)
            {
                CargarCombos();
            }
        }
        /// <summary>
        /// Carga los combos
        /// </summary>
        public void CargarCombos()
        {
            FormHelper.CargarCombo(ddlTipoVehiculo, gestor.BuscarTipoVehiculos(), "Nombre", "Id", "Seleccione");
        }
        /// <summary>
        /// Carga la grilla con una lista pasada por parametros
        /// </summary>
        /// <param name="value">Lista a cargar en la grilla</param>
        private void SetServiciosAGrilla(IList<Servicio> value)
        {
            gvServicios.DataSource = value;
            gvServicios.DataBind();
        }
        /// <summary>
        /// Obtiene los servicios desde la grilla
        /// </summary>
        /// <returns>Lista de servicios</returns>
        private IList<Servicio> ObtenerServiciosDesdeGrilla()
        {
            IList<Servicio> servicios = new List<Servicio>();

            foreach (GridViewRow row in gvServicios.Rows)
            {
                var servicio = new Servicio();

                servicio.Id = int.Parse(gvServicios.DataKeys[row.RowIndex].Values[0].ToString());
                servicio.TipoVehiculoId = int.Parse(gvServicios.DataKeys[row.RowIndex].Values[1].ToString());
                servicio.TipoVehiculo = gestor.BuscarTipoVehiculoPorId(servicio.TipoVehiculoId);
                servicio.TipoVehiculoStr = row.Cells[0].Text;
                servicio.Capacidad = int.Parse(row.Cells[1].Text);

                servicios.Add(servicio);
            }
            return servicios;
        }
        /// <summary>
        /// Valida y Agrega un servicio a la grilla de servicios
        /// </summary>
        /// <param name="servicio">servicio a agregar</param>
        private void AgregarServicio(Servicio servicio)
        {
            var servicios = Servicios;
            if (!ValidarServicio(servicio)) return;
            servicios.Add(servicio);
            Servicios = servicios;
        }
        /// <summary>
        /// Valida que el servicio no se haya cargado antes
        /// </summary>
        /// <param name="servicio">servicio a validar</param>
        /// <returns></returns>
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
        /// <summary>
        /// Valida que los datos requeridos hayan sido ingresados
        /// </summary>
        /// <returns></returns>
        private bool ValidarDatosIngresados()
        {
            if (IdVehiculoSeleccionado == 0 || Capacidad == null)
            {
                OnError("Debe ingresar todos los datos requeridos.");
                return false;
            }
            return true;
        }
        /// <summary>
        /// Carga un servicio desde el formulario
        /// </summary>
        /// <returns>Servicio cargado</returns>
        private Servicio CargarEntidad()
        {

            var servicio = new Servicio();
            servicio.TipoVehiculo = gestor.BuscarTipoVehiculoPorId(IdVehiculoSeleccionado);
            servicio.Capacidad = Capacidad.Value;
            return servicio;
        }
        /// <summary>
        /// Limpia los controles del formulario
        /// </summary>
        public void LimpiarCampos()
        {
            IdVehiculoSeleccionado = 0;
            Capacidad = null;
        }
        /// <summary>
        /// Establece las propiedades de los controles para cuando el usuario esta viendo.
        /// </summary>
        public void ConfigurarVer()
        {
            FormHelper.CambiarVisibilidadControl(divSeccionFormulario, false);
            FormHelper.CambiarVisibilidadControl(divSeccionServicios, true);
            FormHelper.CambiarVisibilidadControl(btnAgregarServicio, true);
            gvServicios.Columns[2].Visible = true;
            }
        /// <summary>
        /// Establece las propiedades de los controles para cuando el usuario esta editando.
        /// </summary>
        public void ConfigurarEditar()
        {
            FormHelper.CambiarVisibilidadControl(divSeccionFormulario, false);
            FormHelper.CambiarVisibilidadControl(divSeccionServicios, true);
            FormHelper.CambiarVisibilidadControl(btnAgregarServicio, true);
            gvServicios.Columns[2].Visible = true;
        }
        /// <summary>
        /// Establece las propiedades de los controles para cuando el usuario esta registrando.
        /// </summary>
        public void ConfigurarRegistrar()
        {
            FormHelper.CambiarVisibilidadControl(divSeccionFormulario, false);
            FormHelper.CambiarVisibilidadControl(divSeccionServicios, true);
            FormHelper.CambiarVisibilidadControl(btnAgregarServicio, true);
            gvServicios.Columns[2].Visible = true;
        }
        #region eventos
        #region grilla
        /// <summary>
        /// Se ejecuta cuando se presiona un boton de la grilla
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
        #endregion
        #region controles
        /// <summary>
        /// Valida y agrega un servicio a la grilla
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!ValidarDatosIngresados()) return;
            AgregarServicio(CargarEntidad());
        }
        /// <summary>
        /// Limpia los campos para registrar un nuevo servicio
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnAgregarServicio_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
        }
        #endregion
        #endregion
        #region properties
        /// <summary>
        /// Obtiene o establece los servicios de la playa
        /// </summary>
        public IList<Servicio> Servicios
        {
            get { return ObtenerServiciosDesdeGrilla(); }
            set { SetServiciosAGrilla(value); }
        }
        /// <summary>
        /// Obtiene o establece el id del tipo de vehiculo seleccionado
        /// </summary>
        public int IdVehiculoSeleccionado
        {
            get { return Convert.ToInt32(ddlTipoVehiculo.SelectedValue); }
            set { ddlTipoVehiculo.SelectedValue = value.ToString(); }
        }
        /// <summary>
        /// Obtiene o establece la capacidad
        /// </summary>
        public int? Capacidad
        {
            get { return FormHelper.ObtenerNullableEntero(txtCapacidad); }
            set { txtCapacidad.Text = value == null ? "" : value.ToString(); }
        }

        #endregion

        /// <summary>
        /// lanza el evento OnErrorHandler
        /// </summary>
        /// <param name="mensaje"></param>
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