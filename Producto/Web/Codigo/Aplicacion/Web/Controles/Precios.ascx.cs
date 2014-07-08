using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ReglasDeNegocio;
using Entidades;

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
            }
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

                precio.Id = int.Parse(gvPrecios.DataKeys[row.RowIndex].Value.ToString());
                precio.TipoVehiculoId = Convert.ToInt32(row.Cells[0].Text);
                precio.TiempoId = Convert.ToInt32(row.Cells[2].Text);
                precio.DiaAtencionId = Convert.ToInt32(row.Cells[4].Text);
                precio.Monto = Convert.ToDecimal(row.Cells[6]);
                
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
            precio.TiempoId = IdTiempoSeleccionado;
            precio.DiaAtencionId = IdDiaAtencionSeleccionado;
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