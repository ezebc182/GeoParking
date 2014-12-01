using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ReglasDeNegocio;
using Entidades;
using Web2.Util;

namespace Web2.Controles
{
    public partial class PrecioControl : System.Web.UI.UserControl
    {
        GestorPrecio gestor;
        public event EventHandler ErrorHandler;

        protected void Page_Load(object sender, EventArgs e)
        {
            gestor = new GestorPrecio();
            if (!Page.IsPostBack)
            {
                CargarCombos();
            }
        }
        /// <summary>
        /// Carga los combos.
        /// </summary>
        public void CargarCombos()
        {
            FormHelper.CargarCombo(ddlDias, gestor.BuscarDiasDeAtencion(), "Nombre", "Id", "Seleccione");
            FormHelper.CargarCombo(ddlTipoHorario, gestor.BuscarTiempos(), "Nombre", "Id", "Seleccione");
            FormHelper.CargarCombo(ddlTipoVehiculo, gestor.BuscarTipoVehiculos(), "Nombre", "Id", "Seleccione");

        }

        /// <summary>
        /// Cambia el contenido de la grilla
        /// </summary>
        /// <param name="value">Precios a agregar</param>
        private void SetPreciosAGrilla(IList<Entidades.Precio> value)
        {
            gvPrecios.DataSource = value;
            gvPrecios.DataBind();
        }
        
        
        /// <summary>
        /// Obtiene los precios cargados en la grilla
        /// </summary>
        /// <returns>Retorna una lista de precios</returns>
        private IList<Entidades.Precio> ObtenerPreciosDesdeGrilla()
        {
            IList<Entidades.Precio> precios = new List<Entidades.Precio>();

            foreach (GridViewRow row in gvPrecios.Rows)
            {
                var precio = new Entidades.Precio();

                precio.Id = int.Parse(gvPrecios.DataKeys[row.RowIndex].Values[0].ToString());
                precio.TipoVehiculoId = int.Parse(gvPrecios.DataKeys[row.RowIndex].Values[1].ToString());
                precio.TipoVehiculo = gestor.BuscarTipoVehiculoPorId(precio.TipoVehiculoId);
                precio.TiempoId = int.Parse(gvPrecios.DataKeys[row.RowIndex].Values[2].ToString());
                precio.Tiempo = gestor.BuscarTiempoPorId(precio.TiempoId);
                precio.DiaAtencionId = int.Parse(gvPrecios.DataKeys[row.RowIndex].Values[3].ToString());
                precio.DiaAtencion = gestor.BuscarDiaAtencionPorId(precio.DiaAtencionId);
                precio.Monto = Convert.ToDecimal(row.Cells[3].Text);

                precios.Add(precio);
            }
            return precios;
        }
        /// <summary>
        /// Agrega un unico precio a la grilla de precios
        /// </summary>
        /// <param name="precio">Precio que se agregara</param>
        private void AgregarPrecio(Entidades.Precio precio)
        {
            var precios = Precios;
            if (!ValidarPrecio(precio)) return;
            precios.Add(precio);

            Precios = precios;
        }
        /// <summary>
        /// Valida que el precio no este duplicado
        /// </summary>
        /// <param name="precio"></param>
        /// <returns></returns>
        private bool ValidarPrecio(Entidades.Precio precio)
        {

            foreach (var item in Precios)
            {

                if (item.TiempoId == precio.TiempoId && item.TipoVehiculoId == precio.TipoVehiculoId && item.DiaAtencionId == precio.DiaAtencionId)
                {
                    OnError("Ya se cargo un precio para los parametros seleccionados.");
                    return false;
                }
            }
            return true;
        }
        /// <summary>
        /// Valida que se hayan ingresado todos los datos necesarios
        /// </summary>
        /// <returns></returns>
        private bool ValidarDatosIngresados()
        {
            if (IdTipoVehiculoSeleccionado == 0 || IdTiempoSeleccionado == 0 || IdDiaAtencionSeleccionado == 0 || Monto == null)
            {
                OnError("Debe ingresar todos los datos requeridos.");
                return false;
            }
            return true;
        }
        /// <summary>
        /// Carga un precio desde los campos del formulario
        /// </summary>
        /// <returns>Retorna un precio</returns>
        private Entidades.Precio CargarEntidad()
        {
            var precio = new Entidades.Precio();
            precio.TipoVehiculoId = IdTipoVehiculoSeleccionado;
            precio.TipoVehiculo = gestor.BuscarTipoVehiculoPorId(IdTipoVehiculoSeleccionado);
            precio.TiempoId = IdTiempoSeleccionado;
            precio.Tiempo = gestor.BuscarTiempoPorId(IdTiempoSeleccionado);
            precio.DiaAtencionId = IdDiaAtencionSeleccionado;
            precio.DiaAtencion = gestor.BuscarDiaAtencionPorId(IdDiaAtencionSeleccionado);
            precio.Monto = Monto.Value;
            return precio;
        }
        /// <summary>
        /// Limpia los controles del formulario
        /// </summary>
        public void LimpiarCampos()
        {
            IdTipoVehiculoSeleccionado = 0;
            IdTiempoSeleccionado = 0;
            IdDiaAtencionSeleccionado = 0;
            Monto = null;
        }
        /// <summary>
        /// Configura todos los controles para cuando el usuario esta viendo un precio.
        /// Setea las visibilidades y la habilitacion de los distintos controles.
        /// </summary>
        public void ConfigurarVer()
        {
            FormHelper.CambiarVisibilidadControl(divSeccionFormulario, false);
            FormHelper.CambiarVisibilidadControl(divSeccionGrillaPrecios, true);
            FormHelper.CambiarVisibilidadControl(btnAgregarPrecio, false);
            gvPrecios.Columns[4].Visible = false;
            }
        /// <summary>
        /// Configura todos los controles para cuando el usuario esta editando un precio.
        /// Setea las visibilidades y la habilitacion de los distintos controles.
        /// </summary>
        public void ConfigurarEditar()
        {
            FormHelper.CambiarVisibilidadControl(divSeccionFormulario, false);
            FormHelper.CambiarVisibilidadControl(divSeccionGrillaPrecios, true);
            FormHelper.CambiarVisibilidadControl(btnAgregarPrecio, true);
            gvPrecios.Columns[4].Visible = true;
        }
        /// <summary>
        /// Configura todos los controles para cuando el usuario esta registrando un precio.
        /// Setea las visibilidades y la habilitacion de los distintos controles.
        /// </summary>
        public void ConfigurarRegistrar()
        {
            FormHelper.CambiarVisibilidadControl(divSeccionFormulario, false);
            FormHelper.CambiarVisibilidadControl(divSeccionGrillaPrecios, true);
            FormHelper.CambiarVisibilidadControl(btnAgregarPrecio, true);
            gvPrecios.Columns[4].Visible = true;
        }
        public void HabilitarFormulario(bool habilitar)
        {
            FormHelper.CambiarVisibilidadControl(divSeccionFormulario, habilitar);
            FormHelper.CambiarVisibilidadControl(divSeccionGrillaPrecios, !habilitar);
            FormHelper.CambiarVisibilidadControl(btnAgregarPrecio, !habilitar);
        }
        #region eventos
        #region grilla
        /// <summary>
        /// Se ejecuta cuando se presiona un boton de la grilla
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void OnRowCommandGvPrecios(object sender, GridViewCommandEventArgs e)
        {
            int index = Convert.ToInt32(e.CommandArgument);
            var lista = Precios;

            switch (e.CommandName)
            {
                case "Quitar":
                    lista.RemoveAt(index);
                    Precios = lista;
                    break;
            }
        }
        #endregion
        #region controles
        /// <summary>
        /// Valida y agrega un precio a la grilla de precios
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!ValidarDatosIngresados()) return;
            AgregarPrecio(CargarEntidad());
            HabilitarFormulario(false);
        }
        /// <summary>
        /// Limpia los campos del formulario para agregar un nuevo precio
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnAgregarPrecio_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
            HabilitarFormulario(true);
        }


        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            HabilitarFormulario(false);
        }

        #endregion
        #endregion
        #region properties
        /// <summary>
        /// Obtiene o establece Lista de precios agregadas
        /// </summary>
        public IList<Entidades.Precio> Precios
        {
            get { return ObtenerPreciosDesdeGrilla(); }
            set { SetPreciosAGrilla(value); }
        }
        /// <summary>
        /// Obtiene o establece el tipo de vehiculo seleccionado mediante su id
        /// </summary>
        public int IdTipoVehiculoSeleccionado
        {
            get { return Convert.ToInt32(ddlTipoVehiculo.SelectedValue); }
            set { ddlTipoVehiculo.SelectedValue = value.ToString(); }
        }
        /// <summary>
        /// Obtiene o establece el tiempo seleccionado, mediante su id
        /// </summary>
        public int IdTiempoSeleccionado
        {
            get { return Convert.ToInt32(ddlTipoHorario.SelectedValue); }
            set { ddlTipoHorario.SelectedValue = value.ToString(); }
        }
        /// <summary>
        /// Obtiene o establece el dia de atencion seleccionado, mediante su id
        /// </summary>
        public int IdDiaAtencionSeleccionado
        {
            get { return Convert.ToInt32(ddlDias.SelectedValue); }
            set { ddlDias.SelectedValue = value.ToString(); }
        }
        /// <summary>
        /// Obtiene o establece el monto.
        /// </summary>
        public Decimal? Monto
        {
            get { return FormHelper.ObtenerNullableDecimal(txtPrecio); }
            set { txtPrecio.Text = value == null ? "" : value.ToString(); }
        }

        #endregion

        /// <summary>
        /// Lanza el error OnError del cotnrol de usuario
        /// </summary>
        /// <param name="mensaje"></param>
        public void OnError(String mensaje)
        {
            if (ErrorHandler != null)
                ErrorHandler.Invoke(this, new PrecioArgs(mensaje));
        }

        /// <summary>
        /// Clase interna para lanzar el error OnErrorHandles del control
        /// </summary>
        public class PrecioArgs : EventArgs
        {
            public PrecioArgs(String error)
            {
                this.Mensaje = error;
            }

            public String Mensaje { get; set; }
        }
    }

}