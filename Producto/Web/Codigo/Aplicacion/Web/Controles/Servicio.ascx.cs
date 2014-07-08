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
    public partial class ServicioControl : System.Web.UI.UserControl
    {
        GestorPlaya gestor;
        protected void Page_Load(object sender, EventArgs e)
        {
            gestor = new GestorPlaya();
            if (!Page.IsPostBack)
            {

            }
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
            servicios.Add(servicio);
            Servicios = servicios;
        }

        private Servicio CargarEntidad()
        {
            var servicio = new Servicio();
            servicio.TipoVehiculo = gestor.BuscarTipoVehiculo(IdVehiculoSeleccionado);
            servicio.Capacidad = Capacidad;
            return servicio;
        }

        #region eventos

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            AgregarServicio(CargarEntidad());
        }
        #endregion
        #region properties


        public int IdVehiculoSeleccionado
        {
            get { return Convert.ToInt32(ddlTipoVehiculo.SelectedValue); }
            set { ddlTipoVehiculo.SelectedValue = value.ToString(); }
        }

        public int Capacidad
        {
            get { return Convert.ToInt32(txtCapacidad.Text); }
            set { txtCapacidad.Text = value.ToString(); }
        }

        #endregion

    }

}