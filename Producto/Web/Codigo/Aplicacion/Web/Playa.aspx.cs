using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidades;
using ReglasDeNegocio;
using Web2.Controles;
using Web2.Util;

namespace Web2
{
    public partial class Playa : System.Web.UI.Page
    {
        //gestor encargado de todas las funcionalidades del ABM
        GestorPlaya gestor;
        //Master de la pagina, para poder mostrar mensajes.
        public SiteMaster master;

        protected void Page_Load(object sender, EventArgs e)
        {
            gestor = new GestorPlaya();
            master = (SiteMaster)(Master);

            if (!Page.IsPostBack)
            {
                CargarComboTiposPlayas();
                Error = string.Empty;
            }
            Error = string.Empty;
        }
        /// <summary>
        /// Carga el combo Tipos de playas con todas las playas nod adas de baja en la BD
        /// </summary>
        public void CargarComboTiposPlayas()
        {
            FormHelper.CargarCombo(ddlTipoPlaya, gestor.BuscarTipoPlayas(), "Nombre", "Id", "Seleccione");
        }
        /// <summary>
        /// Configura todos los controles para cuando el usuario esta viendo una playa.
        /// Setea las visibilidades y la habilitacion de los distintos controles.
        /// </summary>
        public void ConfigurarVer()
        {
            Titulo.Text = "Ver";
            Exito = string.Empty;
            Error = string.Empty;
            txtNombre.Enabled = false;
            ddlTipoPlaya.Enabled = false;
            txtTelefono.Enabled = false;
            txtMail.Enabled = false;
            FormHelper.CambiarVisibilidadControl(btnGuardar, false);
            btnCancelar.Text = "Cerrar";
            ucDomicilios.ConfigurarVer();
            ucServicios.ConfigurarVer();
            ucPrecios.ConfigurarVer();
            ucHorarios.ConfigurarVer();

        }
        /// <summary>
        /// Configura todos los controles para cuando el usuario esta editando una playa.
        /// Setea las visibilidades y la habilitacion de los distintos controles.
        /// </summary>
        public void ConfigurarEditar()
        {
            Titulo.Text = "Editar";
            Exito = string.Empty;
            Error = string.Empty;
            txtNombre.Enabled = true;
            ddlTipoPlaya.Enabled = true;
            txtTelefono.Enabled = true;
            //txtMail.Enabled = true;
            FormHelper.CambiarVisibilidadControl(btnGuardar, true);
            btnCancelar.Text = "Cancelar";
            ucDomicilios.ConfigurarEditar();
            ucServicios.ConfigurarEditar();
            ucPrecios.ConfigurarEditar();
            ucHorarios.ConfigurarEditar();

        }
        /// <summary>
        /// Configura todos los controles para cuando el usuario esta registrando una playa
        /// Setea las visibilidades y la habilitacion de los distintos controles.
        /// </summary>
        public void ConfigurarRegistrar()
        {
            Titulo.Text = "Registrar";
            Error = string.Empty;
            Exito = string.Empty;
            txtNombre.Enabled = true;
            ddlTipoPlaya.Enabled = true;
            txtTelefono.Enabled = true;
            txtMail.Enabled = true;
            btnCancelar.Text = "Cancelar";
            ucDomicilios.ConfigurarRegistrar();
            ucServicios.ConfigurarRegistrar();
            ucPrecios.ConfigurarRegistrar();
            ucHorarios.ConfigurarRegistrar();
            FormHelper.CambiarVisibilidadControl(btnGuardar, true);

        }
        /// <summary>
        /// Carga los campos del formulario con los datos enviados por parametro
        /// </summary>
        /// <param name="playaEditar">Playa a editar, se usa para tomar los datos y cargar el formulario</param>
        public void CargarCamposFormulario(PlayaDeEstacionamiento playaEditar)
        {
            IdPlaya = playaEditar.Id;
            Nombre = playaEditar.Nombre;
            Telefono = playaEditar.Telefono;
            Mail = playaEditar.Mail;
            TipoPlayaSeleccionada = playaEditar.TipoPlayaId.Value;
            Servicios = playaEditar.Servicios;
            //Horarios = playaEditar.Horario;
            //Precios = playaEditar.Precios;
            Direcciones = playaEditar.Direcciones;

        }

        /// <summary>
        /// Carga la entidad PlayaDeEstacionamiento con los valores del formulario
        /// </summary>
        /// <returns>Retorna una playa de estacionamiento</returns>
        public PlayaDeEstacionamiento CargarEntidad()
        {
            PlayaDeEstacionamiento playa = new PlayaDeEstacionamiento
            {
                Id = IdPlaya,
                Nombre = Nombre,
                Mail = Mail,
                Telefono = Telefono,
                TipoPlayaId = TipoPlayaSeleccionada,
                Servicios = Servicios,
                Direcciones = Direcciones
                //Precios = Precios,
                //Horarios = Horarios
            };
            return playa;
        }
        /// <summary>
        /// Limpia todos los controles del formulario
        /// </summary>
        private void limpiarCampos()
        {
            Error = string.Empty;
            IdPlaya = 0;
            Nombre = "";
            Mail = "";
            Telefono = "";
            TipoPlayaSeleccionada = 0;
            ucDomicilios.LimpiarCampos();
            ucDomicilios.Domicilios = null;
            ucPrecios.LimpiarCampos();
            ucPrecios.Precios = null;
            ucServicios.LimpiarCampos();
            ucServicios.Servicios = null;
            ucHorarios.LimpiarCampos();
            ucHorarios.Horarios = null;
        }


        /// <summary>
        /// Actualiza el contenido de la grilla de playas de estacionamientos
        /// </summary>
        private void ActualizarGrilla()
        {
            //lleno la grilla
            gvResultados.DataSource = gestor.BuscarPlayaPorNombre(txtBuscar.Text, txtFiltroNombre.Text);
            gvResultados.DataBind();

            //la hago visible (no se como lo vas a hacer yo lo hice asi porque necesitaba verla)
            gvResultados.Visible = true;

            hfFilasGrilla.Value = gvResultados.Rows.Count.ToString();
        }

        public Usuario SessionUsuario
        {
            get { return (Usuario)Session["Usuario"]; }
            set { Session["Usuario"] = value; }
        }

        #region properties

        /// <summary>
        /// Id de la playa seleccionada en la grilla
        /// </summary>
        public int IdPlayaSeleccionada { get; set; }
        /// <summary>
        /// Id de la playa a editar, si se esta registrando es 0
        /// </summary>
        public int IdPlaya
        {
            get { return !hfIdPlaya.Value.Equals("") ? Convert.ToInt32(hfIdPlaya.Value) : 0; }
            set { hfIdPlaya.Value = value.ToString(); }
        }
        /// <summary>
        ///Nombre de la playa para filtrar la grilla
        /// </summary>
        public string FiltroNombre
        {
            get { return txtFiltroNombre.Text; }
            set { txtFiltroNombre.Text = value; }
        }
        /// <summary>
        ///Nombre de la playa que se esta registrando/editando
        /// </summary>
        public string Nombre
        {
            get { return txtNombre.Text; }
            set { txtNombre.Text = value; }
        }

        /// <summary>
        ///Mail
        /// </summary>
        public string Mail
        {
            get { return txtMail.Text; }
            set { txtMail.Text = value; }
        }
        /// <summary>
        ///Telefono
        /// </summary>
        public string Telefono
        {
            get { return txtTelefono.Text; }
            set { txtTelefono.Text = value; }
        }
        /// <summary>
        ///Servicios de la playa que se esta registrando/editando
        /// </summary>
        public IList<Servicio> Servicios
        {
            get { return ucServicios.Servicios; }
            set { ucServicios.Servicios = value; }
        }
        /// <summary>
        ///Direcciones de la playa que se esta registrando/editando
        /// </summary>
        public IList<Direccion> Direcciones
        {
            get { return ucDomicilios.Domicilios; }
            set { ucDomicilios.Domicilios = value; }
        }
        /// <summary>
        ///Tipo de la playa que se esta registrando/editando
        /// </summary>
        public int TipoPlayaSeleccionada
        {
            get { return Int32.Parse(ddlTipoPlaya.SelectedValue); }
            set { ddlTipoPlaya.SelectedValue = value.ToString(); }
        }
        /// <summary>
        /// Mensaje de exito
        /// </summary>
        public string Exito
        {
            set
            {
                lblMensajeExito.Text = value;
                FormHelper.CambiarVisibilidadControl(divAlertExito, !string.IsNullOrEmpty(value));
                FormHelper.CambiarVisibilidadControl(divModal, string.IsNullOrEmpty(value));
                FormHelper.CambiarVisibilidadControl(btnAceptar, !string.IsNullOrEmpty(value));
                if (!string.IsNullOrEmpty(value))
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "modificarPlaya", "$(function() { $('#modificarPlaya').modal('hide') });", true);
                    master.MostrarMensajeInformacion(value, "Exito");
                }
            }
        }
        /// <summary>
        /// Mensaje de error
        /// </summary>
        public string Error
        {
            get { return lblMensajeError.Text; }
            set
            {
                lblMensajeError.Text = value;
                FormHelper.CambiarVisibilidadControl(divAlertError, !string.IsNullOrEmpty(value));
            }
        }
        /// <summary>
        /// Lista de horarios de la playa.
        /// </summary>
        public IList<Horario> Horarios
        {
            get { return ucHorarios.Horarios; }
            set { ucHorarios.Horarios = value; }
        }
        /// <summary>
        /// Lista de precios de la playa
        /// </summary>
        public IList<Precio> Precios
        {
            get { return ucPrecios.Precios; }
            set { ucPrecios.Precios = value; }
        }

        #endregion
        #region eventos
        #region eventos grilla

        /// <summary>
        /// Evento que se ejecuta cuando se preciona un boton de la grilla
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
                    master.MostrarMensajeConfirmacion("¿Quiere eliminar la playa " + playa.Nombre + "?", "Confirmar Eliminacion", EliminarPlaya);
                    AbrirModal();
                    break;
                case "Editar":
                    Titulo.Text = "Editar";
                    //Carga los campos del formulario con la playa a editar
                    CargarCamposFormulario(playa);
                    ConfigurarEditar();
                    AbrirModal();
                    break;
                case "Ver":
                    Titulo.Text = "Ver";
                    //Carga los campos del formulario con la playa a editar
                    CargarCamposFormulario(playa);
                    ConfigurarVer();
                    AbrirModal();
                    break;
                default:
                    break;
            }
        }

        private void AbrirModal()
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "abrirModal", "$(function() { abrirModalPlaya(); });", true);
        }
        /// <summary>
        /// Evento que se ejecuta cuando se llena la grilla con datos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gvResultados_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            //if (e.Row.RowType == DataControlRowType.DataRow)
            //{
            //    //Boton Editar
            //    var btn = (Button)e.Row.FindControl("btnEditar");
            //    btn.CommandArgument = e.Row.RowIndex.ToString();

            //    //Boton Eliminar
            //    btn = (Button)e.Row.FindControl("btnEliminar");
            //    btn.CommandArgument = e.Row.RowIndex.ToString();
            //}
        }


        #endregion
        #region eventos controles
        /// <summary>
        /// Se lanza cuando se produce un error en el control de domicilios,
        /// muestra el mensaje de error.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void MostrarErrorDomicilio(object sender, EventArgs e)
        {
            var error = (DomicilioControl.DomicilioArgs)e;
            Error = error.Mensaje;
        }
        /// <summary>
        /// Se lanza cuando se produce un error en el control de precios,
        /// muestra el mensaje de error.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void MostrarErrorPrecio(object sender, EventArgs e)
        {
            var error = (PrecioControl.PrecioArgs)e;
            Error = error.Mensaje;
        }
        /// <summary>
        /// Se lanza cuando se produce un error en el control de servicios,
        /// muestra el mensaje de error.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void MostrarErrorServicio(object sender, EventArgs e)
        {
            var error = (ServicioControl.ServicioArgs)e;
            Error = error.Mensaje;
        }
        /// <summary>
        /// Se lanza cuando se produce un error en el control de horarios,
        /// muestra el mensaje de error.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void MostrarErrorHorario(object sender, EventArgs e)
        {
            var error = (HorarioControl.HorarioArgs)e;
            Error = error.Mensaje;
        }
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
                    ActualizarGrilla();
                    limpiarCampos();
                    Exito = "La playa fue registrada correctamente.";
                }
                else
                {
                    //Mensajes de error
                    Error = resultado.MensajesString();
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
                    ActualizarGrilla();
                    limpiarCampos();//limpio el formulario
                    Exito = "La playa fue modificada correctamente.";
                }
                else
                {
                    //Mensajes de Error
                    Error = resultado.MensajesString();
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
        /// Consulta playa de estacionamiento por filtro de nombre 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            pnlResultados.Visible = true;
            ActualizarGrilla();
        }
        /// <summary>
        /// Muestra el formulario para registrar playas.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            Titulo.Text = "Registrar";
            limpiarCampos();
            ConfigurarRegistrar();
        }

        /// <summary>
        /// Elimina una playa de estacionamiento.
        /// </summary>
        protected void EliminarPlaya(object sender, EventArgs e)
        {
            var resultado = gestor.EliminarPlaya(IdPlayaSeleccionada);
            if (resultado.Ok)
            {
                ActualizarGrilla();
                Exito = "La playa fue eliminada correctamente.";                
            }
            else
            {
                Error = resultado.MensajesString();
            }
        }
        #endregion
        #endregion
    }
}