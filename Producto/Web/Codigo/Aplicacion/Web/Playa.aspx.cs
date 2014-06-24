using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidades;
using ReglasDeNegocio;

namespace Web
{
    public partial class Playa : System.Web.UI.Page
    {
        //gestor encargado de todas las funcionalidades del ABM
        GestorABMPlaya gestor;
        //Master de la pagina, para poder mostrar mensajes.
        SiteMaster master;

        protected void Page_Load(object sender, EventArgs e)
        {
            gestor = new GestorABMPlaya();
            master = (SiteMaster)Master;

            if (!Page.IsPostBack)
            {
                CargarComboTiposPlayas();
                Error = string.Empty;

            }
        }

        public void CargarComboTiposPlayas()
        {
            gestor = new GestorABMPlaya();
            var lista = gestor.BuscarTipoPlayas();
            ddlTipoPlaya.DataSource = lista;
            ddlTipoPlaya.DataTextField = "nombre";
            ddlTipoPlaya.DataValueField = "id";
            ddlTipoPlaya.DataBind();
            ddlTipoPlaya.Items.Insert(0, new ListItem("Seleccione...", "0"));
        }

        public void HabilitarCamposFormlario(bool habilitar)
        {
            txtNombre.Enabled = habilitar;
            txtDireccion.Enabled = habilitar;
            txtLatitud.Enabled = habilitar;
            txtLongitud.Enabled = habilitar;
            txtHoraDesde.Enabled = habilitar;
            txtHoraHasta.Enabled = habilitar;
            ddlTipoPlaya.Enabled = habilitar;
            gvTiposVehiculo.Enabled = habilitar;
            btnGuardar.Visible = habilitar;
            btnCancelar.Text = habilitar ? "Cancelar" : "Cerrar";
        }

        //Carga los campos del formulario con los datos enviados por parametro
        public void CargarCamposFormulario(PlayaDeEstacionamiento playaEditar)
        {
            IdPlaya = playaEditar.Id;
            Nombre = playaEditar.Nombre;
            Direccion = playaEditar.Direccion;
            TipoPlayaSeleccionada = playaEditar.TipoPlayaId;
            Latitud = playaEditar.Latitud;
            Longitud = playaEditar.Longitud;
            //esto hay que revisarlo por ahora deja que guarde la fecha
            HoraDesde = playaEditar.HoraDesde.ToString();
            HoraHasta = playaEditar.HoraHasta.ToString();
            

            //Creamos un Data Table Object para cargar la grilla de Tipos de vehiculo, precio y capacidad
            List<dtoDetalleTipoVehiculo> dtos = new List<dtoDetalleTipoVehiculo>();
            dtos.Add(new dtoDetalleTipoVehiculo { AceptaTipoVehiculo = playaEditar.Autos, Capacidad = playaEditar.CapacidadAutos, Precio = playaEditar.PrecioAutos });
            dtos.Add(new dtoDetalleTipoVehiculo { AceptaTipoVehiculo = playaEditar.Utilitarios, Capacidad = playaEditar.CapacidadUtilitarios, Precio = playaEditar.PrecioUtilitarios });
            dtos.Add(new dtoDetalleTipoVehiculo { AceptaTipoVehiculo = playaEditar.Motos, Capacidad = playaEditar.CapacidadMotos, Precio = playaEditar.PrecioMotos });
            dtos.Add(new dtoDetalleTipoVehiculo { AceptaTipoVehiculo = playaEditar.Bicicletas, Capacidad = playaEditar.CapacidadBicicletas, Precio = playaEditar.PrecioBicicletas });

            GrillaDetalles = dtos;
        }

        private void VaciarDetallesPlaya()
        {
            GrillaDetalles = new List<dtoDetalleTipoVehiculo> { new dtoDetalleTipoVehiculo(), new dtoDetalleTipoVehiculo(), new dtoDetalleTipoVehiculo(), new dtoDetalleTipoVehiculo() };
        }

        //Carga la entidad PlayaDeEstacionamiento con los valores del formulario.
        public PlayaDeEstacionamiento CargarEntidad()
        {
            PlayaDeEstacionamiento playa = new PlayaDeEstacionamiento
            {
                Id = IdPlaya,
                Nombre = Nombre,
                Direccion = Direccion,
                TipoPlayaId = TipoPlayaSeleccionada,
                CapacidadAutos = CapacidadAutos,
                CapacidadBicicletas = CapacidadBicicletas,
                CapacidadMotos = CapacidadMotos,
                CapacidadUtilitarios = CapacidadUtilitarios,
                Latitud = Latitud,
                Longitud = Longitud,
                HoraDesde = HoraDesde,
                HoraHasta = HoraHasta,
                Autos = Autos,
                Motos = Motos,
                Bicicletas = Bicicletas,
                Utilitarios = Utilitarios,
                PrecioAutos = PrecioAutos,
                PrecioUtilitarios = PrecioUtilitarios,
                PrecioMotos = PrecioMotos,
                PrecioBicicletas = PrecioBicicletas
            };
            return playa;
        }
        private void limpiarCampos()
        {
            divAlertError.Visible = false;

            Nombre = "";
            Direccion = "";
            TipoPlayaSeleccionada = 0;
            HoraDesde = "";
            HoraHasta = "";
            VaciarDetallesPlaya();
        }

        private void EliminarPlaya()
        {
            var resultado = gestor.EliminarPlaya(IdPlayaSeleccionada);
            if (resultado.Ok)
            {
                master.Alert = "La playa fue eliminada correctamente.";
            }
            else
            {
                Error = resultado.MessagesAsString();
            }
        }

        private void ActualizarGrilla()
        {
            //lleno la grilla
            gvResultados.DataSource = gestor.BuscarPlayaPorNombre(txtFiltroNombre.Text);
            gvResultados.DataBind();

            //la hago visible (no se como lo vas a hacer yo lo hice asi porque necesitaba verla)
            gvResultados.Visible = true;

            hfFilasGrilla.Value = string.IsNullOrEmpty(hfFilasGrilla.Value) ? "0" : gvResultados.Rows.Count.ToString();
        }

        public bool ValidarCamposFormulario()
        {
            var result = true;

            if(string.IsNullOrEmpty(Nombre) || string.IsNullOrEmpty(Direccion) || TipoPlayaSeleccionada == 0 || 
                ((Autos && CapacidadAutos > 0 && PrecioAutos.HasValue) ||( Motos && CapacidadMotos > 0 && PrecioMotos.HasValue )||
                ( Utilitarios && CapacidadUtilitarios >0 && PrecioUtilitarios.HasValue )||( Bicicletas && CapacidadBicicletas>0&&PrecioBicicletas.HasValue )))
            {
                result = false;
            }

            return result;
        }

        #region properties
        //Id de la playa seleccionada en la grilla
        public int IdPlayaSeleccionada { get; set; }
        //Id de la playa a editar, si se esta registrando es 0
        public int IdPlaya
        {
            get { return !hfIdPlaya.Value.Equals("") ? Convert.ToInt32(hfIdPlaya.Value) : 0; }
            set { hfIdPlaya.Value = value.ToString(); }
        }
        //Nombre de la playa para filtrar la grilla
        public string FiltroNombre
        {
            get { return txtFiltroNombre.Text; }
            set { txtFiltroNombre.Text = value; }
        }
        //Nombre de la playa que se esta registrando/editando
        public string Nombre
        {
            get { return txtNombre.Text; }
            set { txtNombre.Text = value; }
        }
        //Direccion de la playa que se esta registrando/editando
        public string Direccion
        {
            get { return txtDireccion.Text; }
            set { txtDireccion.Text = value; }
        }
        //Tipo de la playa que se esta registrando/editando
        public int TipoPlayaSeleccionada
        {
            get { return ddlTipoPlaya.SelectedIndex; }
            set { ddlTipoPlaya.SelectedIndex = value; }
        }
        //Capacidad de la playa que se esta registrando/editando para el tipo de vehiculo correspondiente a la fila de la grilla
        public int CapacidadAutos
        {
            get { return !string.IsNullOrEmpty(((TextBox)gvTiposVehiculo.Rows[0].FindControl("txtCapacidad")).Text) ? Convert.ToInt32(((TextBox)gvTiposVehiculo.Rows[0].FindControl("txtCapacidad")).Text) : 0; }
            set { ((TextBox)gvTiposVehiculo.Rows[0].FindControl("txtCapacidad")).Text = value.ToString(); }
        }
        public int CapacidadUtilitarios
        {
            get { return !string.IsNullOrEmpty(((TextBox)gvTiposVehiculo.Rows[1].FindControl("txtCapacidad")).Text) ? Convert.ToInt32(((TextBox)gvTiposVehiculo.Rows[1].FindControl("txtCapacidad")).Text) : 0; }
            set { ((TextBox)gvTiposVehiculo.Rows[1].FindControl("txtCapacidad")).Text = value.ToString(); }
        }
        public int CapacidadMotos
        {
            get { return !string.IsNullOrEmpty(((TextBox)gvTiposVehiculo.Rows[2].FindControl("txtCapacidad")).Text) ? Convert.ToInt32(((TextBox)gvTiposVehiculo.Rows[2].FindControl("txtCapacidad")).Text) : 0; }
            set { ((TextBox)gvTiposVehiculo.Rows[2].FindControl("txtCapacidad")).Text = value.ToString(); }
        }
        public int CapacidadBicicletas
        {
            get { return !string.IsNullOrEmpty(((TextBox)gvTiposVehiculo.Rows[3].FindControl("txtCapacidad")).Text) ? Convert.ToInt32(((TextBox)gvTiposVehiculo.Rows[3].FindControl("txtCapacidad")).Text) : 0; }
            set { ((TextBox)gvTiposVehiculo.Rows[3].FindControl("txtCapacidad")).Text = value.ToString(); }
        }
        //Latitud de la playa que se esta registrando/editando        
        public double Latitud
        {
            get { return Double.Parse(txtLatitud.Text); }
            set { txtLatitud.Text = value.ToString(); }
        }
        //Longitud de la playa que se esta registrando/editando
        public double Longitud
        {
            get { return Double.Parse(txtLongitud.Text); }
            set { txtLongitud.Text = value.ToString(); }
        }
        //Hora desde de la playa que se esta registrando/editando
        public string HoraDesde
        {
            get { return cbAllDay.Checked ? "00:00" : txtHoraDesde.Text; }
            set
            {
                txtHoraDesde.Text = value;
            }
        }
        //Hora hasta de la playa que se esta registrando/editando
        public string HoraHasta
        {
            get { return cbAllDay.Checked ? "23:59" : txtHoraHasta.Text; }
            set
            {
                txtHoraHasta.Text = value;
            }
        }
        //Indica si la playa que se esta registrando/editando acepta autos
        public bool Autos
        {
            get { return ((CheckBox)gvTiposVehiculo.Rows[0].FindControl("checkBox")).Checked; }
            set { ((CheckBox)gvTiposVehiculo.Rows[0].FindControl("checkBox")).Checked = value; }
        }
        //Indica si la playa que se esta registrando/editando acepta utilitarios
        public bool Utilitarios
        {
            get { return ((CheckBox)gvTiposVehiculo.Rows[1].FindControl("checkBox")).Checked; }
            set { ((CheckBox)gvTiposVehiculo.Rows[1].FindControl("checkBox")).Checked = value; }
        }
        //Indica si la playa que se esta registrando/editando acepta motos
        public bool Motos
        {
            get { return ((CheckBox)gvTiposVehiculo.Rows[2].FindControl("checkBox")).Checked; }
            set { ((CheckBox)gvTiposVehiculo.Rows[2].FindControl("checkBox")).Checked = value; }
        }
        //Indica si la playa que se esta registrando/editando acepta bicicletas
        public bool Bicicletas
        {
            get { return ((CheckBox)gvTiposVehiculo.Rows[3].FindControl("checkBox")).Checked; }
            set { ((CheckBox)gvTiposVehiculo.Rows[3].FindControl("checkBox")).Checked = value; }
        }
        //Precio de autos de la playa que se esta registrando/editando
        public double? PrecioAutos
        {
            get { return !string.IsNullOrEmpty(((TextBox)gvTiposVehiculo.Rows[0].FindControl("txtPrecio")).Text) ? (Nullable<Double>)Convert.ToDouble(((TextBox)gvTiposVehiculo.Rows[0].FindControl("txtPrecio")).Text) : null; }
            set { ((TextBox)gvTiposVehiculo.Rows[0].FindControl("txtPrecio")).Text = value.ToString(); }
        }
        //Precio de utilitarios de la playa que se esta registrando/editando
        public double? PrecioUtilitarios
        {
            get { return !string.IsNullOrEmpty(((TextBox)gvTiposVehiculo.Rows[1].FindControl("txtPrecio")).Text) ? (Nullable<Double>)Convert.ToDouble(((TextBox)gvTiposVehiculo.Rows[1].FindControl("txtPrecio")).Text) : null; }
            set { ((TextBox)gvTiposVehiculo.Rows[1].FindControl("txtPrecio")).Text = value.ToString(); }
        }
        //Precio de motos de la playa que se esta registrando/editando
        public double? PrecioMotos
        {
            get { return !string.IsNullOrEmpty(((TextBox)gvTiposVehiculo.Rows[2].FindControl("txtPrecio")).Text) ? (Nullable<double>)Convert.ToDouble(((TextBox)gvTiposVehiculo.Rows[2].FindControl("txtPrecio")).Text) : null; }
            set { ((TextBox)gvTiposVehiculo.Rows[2].FindControl("txtPrecio")).Text = value.ToString(); }
        }
        //Precio de bicicletas de la playa que se esta registrando/editando
        public double? PrecioBicicletas
        {
            get { return !string.IsNullOrEmpty(((TextBox)gvTiposVehiculo.Rows[3].FindControl("txtPrecio")).Text) ? (Nullable<double>)Convert.ToDouble(((TextBox)gvTiposVehiculo.Rows[3].FindControl("txtPrecio")).Text) : null; }
            set { ((TextBox)gvTiposVehiculo.Rows[3].FindControl("txtPrecio")).Text = value.ToString(); }
        }

        public string Error
        {
            get { return lblMensajeError.Text; }
            set
            {
                lblMensajeError.Text = value;
                divAlertError.Visible = !string.IsNullOrEmpty(value);
            }
        }

        private IList<dtoDetalleTipoVehiculo> GrillaDetalles
        {
            set
            {
                gvTiposVehiculo.DataSource = value;
                gvTiposVehiculo.DataBind();
            }
        }
        #endregion
        #region eventos
        #region eventos grilla

        //no se que hace ni cuando se ejecuta (nunca entro en el codigo)
        protected void gvResultados_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            var acciones = new List<string> { "Editar", "Eliminar", "Ver" };

            if (!acciones.Contains(e.CommandName))
                return;

            gvResultados.SelectedIndex = Convert.ToInt32(e.CommandArgument);
            IdPlayaSeleccionada = 0;

            if (gvResultados.SelectedValue != null)
                IdPlayaSeleccionada = (int)gvResultados.SelectedValue;
            var playa = gestor.BuscarPlayaPorId(IdPlayaSeleccionada);
            switch (e.CommandName)
            {
                case "Eliminar":

                    //elimina la playa y muestra el resultado.
                    EliminarPlaya();
                    ActualizarGrilla();
                    break;
                case "Editar":
                    Titulo.Text = "Editar";
                    //Carga los campos del formulario con la playa a editar
                    CargarCamposFormulario(playa);
                    HabilitarCamposFormlario(true);
                    break;
                case "Ver":
                    Titulo.Text = "Ver";
                    //Carga los campos del formulario con la playa a editar
                    CargarCamposFormulario(playa);
                    HabilitarCamposFormlario(false);

                    break;
                default:
                    break;
            }
        }

        //no se que hace ni cuando se ejecuta (nunca entro en el codigo)
        protected void gvResultados_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //Boton Editar
                var btn = (Button)e.Row.FindControl("btnEditar");
                btn.CommandArgument = e.Row.RowIndex.ToString();

                //Boton Eliminar
                btn = (Button)e.Row.FindControl("btnEliminar");
                btn.CommandArgument = e.Row.RowIndex.ToString();
            }
        }

        protected void gvTiposVehiculo_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                var entity = (dtoDetalleTipoVehiculo)e.Row.DataItem;
                //Capacidad
                var gvTxtCapacidad = (TextBox)e.Row.FindControl("txtCapacidad");
                //Precio
                var gvTxtPrecio = (TextBox)e.Row.FindControl("txtPrecio");
                //Checkboxes
                var gvCheckBox = (CheckBox)e.Row.FindControl("checkBox");

                gvTxtCapacidad.Text = entity.Capacidad.ToString();
                gvTxtPrecio.Text = entity.Precio.ToString();
                gvCheckBox.Checked = entity.AceptaTipoVehiculo;

                switch (e.Row.RowIndex)
                {
                    case 0:
                        gvCheckBox.Text = "Autos";
                        break;
                    case 1:
                        gvCheckBox.Text = "Utilitarios";
                        break;
                    case 2:
                        gvCheckBox.Text = "Motos";
                        break;
                    case 3:
                        gvCheckBox.Text = "Bicicletas";
                        break;
                }
            }
        }
        #endregion
        #region eventos botones
        /// <summary>
        /// Guarda o Actualiza un Playa de Estacionemiento
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!ValidarCamposFormulario())
            {
                Error = "Debe completar todos los datos requeridos";
                return;
            }
            if (IdPlaya == 0)//creo una nueva playa
            {
                //Creo el objeto de la nueva PlayaDeEstacionamiento
                PlayaDeEstacionamiento playa = CargarEntidad();

                //registro la playa a travez del gestor
                var resultado = gestor.RegistrarPlaya(playa);

                if (resultado.Ok)
                {
                    //Mensaje de registracion correcta
                    master.Alert = "La playa fue registrada correctamente.";
                    //limpio el formulario
                    limpiarCampos();
                }
                else
                {
                    //Mensajes de error
                    Error = resultado.MessagesAsString();
                }

            }
            else //edito el objeto playa editar
            {
                var playa = CargarEntidad();

                //actualizo la playa a travez del gestor
                var resultado = gestor.ActualizarPlaya(playa);

                if (resultado.Ok)
                {
                    //Mensaje de actualizacion correcta
                    master.Alert = "La playa fue editada correctamente.";
                    //limpio el formulario
                    limpiarCampos();
                }
                else
                {
                    //Mensajes de Error
                    Error = resultado.MessagesAsString();
                }
            }
        }

        /// <summary>
        /// Cancela cualquier accion y limpia el formulario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            limpiarCampos();
        }

        /// <summary>
        /// Consulta playa de estacionamiento por filtro de nombre (por ahora exacto, hay que modificarlo)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnBuscar_Click(object sender, EventArgs e)
        {

            ActualizarGrilla();

        }
        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            VaciarDetallesPlaya();
            Titulo.Text = "Registrar";
            HabilitarCamposFormlario(true);
        }

        #endregion
        #endregion
    }

    internal class dtoDetalleTipoVehiculo
    {
        public bool AceptaTipoVehiculo { get; set; }
        public int Capacidad { get; set; }
        public double? Precio { get; set; }
    }
}