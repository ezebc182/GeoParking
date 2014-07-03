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
            ddlTipoPlaya.Items.Insert(0, new ListItem("Seleccione", "0"));
        }

        public void HabilitarCamposFormlario(bool habilitar)
        {
            txtNombre.Enabled = habilitar;            
            ddlTipoPlaya.Enabled = habilitar;            
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
           

        }


        //Carga la entidad PlayaDeEstacionamiento con los valores del formulario.
        public PlayaDeEstacionamiento CargarEntidad()
        {
            PlayaDeEstacionamiento playa = new PlayaDeEstacionamiento
            {
                Id = IdPlaya,
                Nombre = Nombre,
                Direccion = Direccion,
                TipoPlayaId = TipoPlayaSeleccionada                
            };
            return playa;
        }
        private void limpiarCampos()
        {
            divAlertError.Visible = false;

            Nombre = "";
            Direccion = "";
            TipoPlayaSeleccionada = 0;           
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
            
            hfFilasGrilla.Value =  gvResultados.Rows.Count.ToString();
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
        
        public string Error
        {
            get { return lblMensajeError.Text; }
            set
            {
                lblMensajeError.Text = value;
                divAlertError.Visible = !string.IsNullOrEmpty(value);
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

        
        #endregion
        #region eventos botones
        /// <summary>
        /// Guarda o Actualiza un Playa de Estacionemiento
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnGuardar_Click(object sender, EventArgs e)
        {            
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
            Titulo.Text = "Registrar";
            HabilitarCamposFormlario(true);
            limpiarCampos();
        }

        #endregion
        #endregion
    }

   
}