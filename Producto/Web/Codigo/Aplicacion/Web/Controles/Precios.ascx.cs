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
    public partial class PrecioControl : System.Web.UI.UserControl
    {
        GestorPrecio gestor;
        protected void Page_Load(object sender, EventArgs e)
        {
            gestor = new GestorPrecio();
            if (!Page.IsPostBack)
            {
                CargarCombos();
            }
        }
        public void CargarCombos()
        {
            FormHelper.CargarCombo(ddlDias, gestor.BuscarDiasDeAtencion(), "Nombre", "Id");
            FormHelper.CargarCombo(ddlTipoHorario, gestor.BuscarTiempos(), "Nombre", "Id"); 
            FormHelper.CargarCombo(ddlTipoVehiculo, gestor.BuscarTipoVehiculos(), "Nombre", "Id");
            
        }
        public IList<Entidades.Precio> Precios
        {
            get { return GetPreciosDesdeGrilla(); }
            set { SetPrecioAGrilla(value); }
        }

        private void SetPrecioAGrilla(IList<Entidades.Precio> value)
        {
            gvPrecios.DataSource = value;
            gvPrecios.DataBind();
        }
        private void AddPrecio(Entidades.Precio precio)
        {
            var precios = Precios;
            precios.Add(precio);
            Precios = precios;
        }
        private IList<Entidades.Precio> GetPreciosDesdeGrilla()
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
                precio.DiaAtencion = gestor.GetDiaAtencionById(precio.DiaAtencionId);
                precio.Monto = Convert.ToDecimal(row.Cells[3].Text);
                
                precios.Add(precio);
            }
            return precios;
        }
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
        private void AgregarPrecio(Entidades.Precio precio)
        {
            var precios = Precios;
            precios.Add(precio);
            Precios = precios;
        }

        private Entidades.Precio CargarEntidad()
        {
            var precio = new Entidades.Precio();
            precio.TipoVehiculoId = IdTipoVehiculoSeleccionado;
            precio.TipoVehiculo = gestor.BuscarTipoVehiculoPorId(IdTipoVehiculoSeleccionado);
            precio.TiempoId = IdTiempoSeleccionado;
            precio.Tiempo = gestor.BuscarTiempoPorId(IdTiempoSeleccionado);
            precio.DiaAtencionId = IdDiaAtencionSeleccionado;
            precio.DiaAtencion = gestor.GetDiaAtencionById(IdDiaAtencionSeleccionado);
            precio.Monto = Monto;
            return precio;
        }

        #region eventos

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            AgregarPrecio(CargarEntidad());
        }
        #endregion
        #region properties

        public int IdTipoVehiculoSeleccionado
        {
            get { return Convert.ToInt32(ddlTipoVehiculo.SelectedValue); }
            set { ddlTipoVehiculo.SelectedValue = value.ToString(); }
        }
        public int IdTiempoSeleccionado
        {
            get { return Convert.ToInt32(ddlTipoHorario.SelectedValue); }
            set { ddlTipoHorario.SelectedValue = value.ToString(); }
        }
        public int IdDiaAtencionSeleccionado
        {
            get { return Convert.ToInt32(ddlDias.SelectedValue); }
            set { ddlDias.SelectedValue = value.ToString(); }
        }

        public Decimal Monto
        {
            get { return Convert.ToDecimal(txtPrecio.Text); }
            set { txtPrecio.Text = value.ToString(); }
        }

        #endregion

    }

}