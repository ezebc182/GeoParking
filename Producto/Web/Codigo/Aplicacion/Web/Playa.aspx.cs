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
        MasterPage master;

        protected void Page_Load(object sender, EventArgs e)
        {
            gestor = new GestorABMPlaya();
            master = (SiteMaster)Master;

            if (!Page.IsPostBack)
            {
                CargarComboTiposPlayas();
            }
        }

        public void CargarComboTiposPlayas()
        {
            gestor = new GestorABMPlaya();
            ddlTipoPlaya.DataSource = gestor.BuscarTipoPlayas();
            ddlTipoPlaya.DataTextField = "nombre";
            ddlTipoPlaya.DataValueField = "id";
            ddlTipoPlaya.DataBind();
        }

        //Carga los campos del formulario con los datos enviados por parametro
        public void CargarCamposFormulario(PlayaDeEstacionamiento playaEditar)
        {
            txtNombre.Text = playaEditar.Nombre;
            txtDireccion.Text = playaEditar.Direccion;
            ddlTipoPlaya.SelectedValue = playaEditar.TipoPlaya.ToString();
            txtCapacidad.Text = playaEditar.Capacidad.ToString();
            txtLatitud.Text = playaEditar.Latitud.ToString();
            txtLongitud.Text = playaEditar.Longitud.ToString();
            //esto hay que revisarlo por ahora deja que guarde la fecha
            txtDesde.Text = playaEditar.HoraDesde.ToString();
            txtHasta.Text = playaEditar.HoraHasta.ToString();
            //el seteo del mapa lo hace java script, ya esta hecho
            chkMotos.Checked = playaEditar.Motos;
            chkBicis.Checked = playaEditar.Bicicletas;
            chkUtilitarios.Checked = playaEditar.Utilitarios;
        }

        //Carga la entidad PlayaDeEstacionamiento con los valores del formulario.
        public PlayaDeEstacionamiento CargarEntidad()
        {
            PlayaDeEstacionamiento playa = new PlayaDeEstacionamiento
            {
                Nombre = Nombre,
                Direccion = Direccion,
                TipoPlaya = TipoPlayaSeleccionada,
                Capacidad = Capacidad,
                Latitud = Latitud,
                Longitud = Longitud,
                HoraDesde = HoraDesde,
                HoraHasta = HoraHasta,
                Motos = Motos,
                Bicicletas = Bicicletas,
                Utilitarios = Utilitarios
            };
            return playa;
        }
        private void limpiarCampos()
        {
            Titulo.Text = "Registrar";
            txtNombre.Text = "";
            txtDireccion.Text = "";
            ddlTipoPlaya.SelectedIndex = 0;
            txtCapacidad.Text = "";
            txtDesde.Text = "";
            txtHasta.Text = "";
            chkBicis.Checked = false;
            chkMotos.Checked = false;
            chkUtilitarios.Checked = false;
        }

        private void EliminarPlaya()
        {
            var resultado = gestor.EliminarPlaya(IdPlayaSeleccionada);
            if (resultado.Ok)
            {
                master.SuccessAlert("La playa fue eliminada correctamente.");
            }
            else
            {
                master.ErrorAlert(resultado.MessagesAsString());
            }
        }

        #region properties
        //Id de la playa seleccionada en la grilla
        public int IdPlayaSeleccionada { get; set; }
        //Id de la playa a editar, si se esta registrando es 0
        public int IdPlaya
        {
            get { return hfIdPlaya.HasValue ? hfIdPlaya.Value : 0; }
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
        public string TipoPlayaSeleccionada
        {
            get { return ddlTipoPlaya.SelectedValue; }
        }
        //Capacidad de la playa que se esta registrando/editando
        public int Capacidad
        {
            get { return string.IsNullOrEmpty(txtCapacidad.Text) ? 0 : int.Parse(txtCapacidad.Text); }
            set { txtCapacidad.Text = value.ToString(); }
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
            get { return txtHoraDesde.Text + ":" + txtMinutosDesde.Text; }
            set
            {
                var horaArray = value.Split(':');
                txtHoraDesde.Text = horaArray[0].ToString();
                txtMinutosDesde.Text = horaArray[2].ToString();
            }
        }
        //Hora hasta de la playa que se esta registrando/editando
        public string HoraHasta
        {
            get { return txtHoraHasta.Text + ":" + txtMinutosHasta.Text; }
            set
            {
                var horaArray = value.Split(':');
                txtHoraHasta.Text = horaArray[0].ToString();
                txtMinutosHasta.Text = horaArray[2].ToString();
            }
        }
        //Indica si la playa que se esta registrando/editando acepta motos
        public bool Motos
        {
            get { return chkMotos.Checked; }
            set { chkMotos.Checked = value; }
        }
        //Indica si la playa que se esta registrando/editando acepta bicicletas
        public bool Bicicletas
        {
            get { return chkBicis.Checked; }
            set { chkBicis.Checked = value; }
        }
        //Indica si la playa que se esta registrando/editando acepta utilitarios
        public bool Utilitarios
        {
            get { return chkUtilitarios.Checked; }
            set { chkUtilitarios.Checked = value; }
        }
        //Precio de la playa que se esta registrando/editando
        public decimal? PrecioAutos
        {
            get { return txtPrecioAutos.Text != "" ? Convert.ToDecimal(txtPrecioAutos.Text) : null; }
            set { txtPrecioAutos = value.ToString(); }
        }
        //Precio de motos de la playa que se esta registrando/editando
        public decimal? PrecioMotos
        {
            get { return txtPrecioMotos.Text != "" ? Convert.ToDecimal(txtPrecioMotos.Text) : null; }
            set { txtPrecioMotos = value.ToString(); }
        }
        //Precio de bicicletas de la playa que se esta registrando/editando
        public decimal? PrecioBicicletas
        {
            get { return txtPrecioBicicletas.Text != "" ? Convert.ToDecimal(txtPrecioBicicletas.Text) : null; }
            set { txtPrecioBicicletas = value.ToString(); }
        }
        //Precio de utilitarios de la playa que se esta registrando/editando
        public decimal? PrecioUtilitarios
        {
            get { return txtPrecioUtilitarios.Text != "" ? Convert.ToDecimal(txtPrecioUtilitarios.Text) : null; }
            set { txtPrecioUtilitarios = value.ToString(); }
        }

        #endregion
        #region eventos
        #region eventos grilla

        //no se que hace ni cuando se ejecuta (nunca entro en el codigo)
        void gvResultados_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            var acciones = new List<string> { "Editar", "Eliminar", "Ver" };

            if (!acciones.Contains(e.CommandName))
                return;

            gvResultados.SelectedIndex = Convert.ToInt32(e.CommandArgument);
            IdPlayaSeleccionada = 0;

            if (gvResultados.SelectedValue != null)
                IdPlayaSeleccionada = (int)gvResultados.SelectedValue;

            switch (e.CommandName)
            {
                case "Eliminar":

                    //elimina la playa y muestra el resultado.
                    EliminarPlaya()                    
                    break;
                case "Editar":
                    Titulo.Text = "Editar";
                    var playa = gestor.BuscarPlayaPorId(IdPlayaSeleccionada);
                    //Carga los campos del formulario con la playa a editar
                    CargarCamposFormulario(playa);
                    break;
                default:
                    break;
            }
        }

        //no se que hace ni cuando se ejecuta (nunca entro en el codigo)
        void gvResultados_RowDataBound(object sender, GridViewRowEventArgs e)
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

        #endregion
        #region eventos botones
        /// <summary>
        /// Guarda o Actualiza un Playa de Estacionemiento
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            //instancio el gestor

            if (IdPlaya == 0)//creo una nueva playa
            {
                //Creo el objeto de la nueva PlayaDeEstacionamiento
                PlayaDeEstacionamiento playa = CargarEntidad();

                //registro la playa a travez del gestor
                var resultado = gestor.RegistrarPlaya(playa);

                if (resultado.Ok)
                {
                    //Mensaje de registracion correcta
                    master.SuccessAlert("La playa fue registrada correctamente.");
                }
                else
                {
                    //Mensajes de error
                    master.ErrorAlert(resultado.MessagesAsString());
                }

                //limpio el formulario
                limpiarCampos();

            }
            else //edito el objeto playa editar
            {
                var playa = CargarEntidad();

                //actualizo la playa a travez del gestor
                var resultado = gestor.ActualizarPlaya(playa);

                if (resultado.Ok)
                {
                    //Mensaje de actualizacion correcta
                    master.SuccessAlert("La playa fue editada correctamente.");
                }
                else
                {
                    //Mensajes de error
                    master.ErrorAlert(resultado.MessagesAsString());
                }

                //limpio el formulario
                limpiarCampos();

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
        protected void btnConsultar_Click(object sender, EventArgs e)
        {
            //lleno la grilla
            gvResultados.DataSource = gestor.BuscarPlayaPorNombre(txtFiltroNombre.Text);
            gvResultados.DataBind();

            //la hago visible (no se como lo vas a hacer yo lo hice asi porque necesitaba verla)
            gvResultados.Visible = true;
        }

        #endregion
        #endregion
    }
}