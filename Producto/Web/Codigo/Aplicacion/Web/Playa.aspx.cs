using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidades;
using ReglasDeNegocio;

namespace appWeb1.app
{
    public partial class Formulario_web1 : System.Web.UI.Page
    {
        //gestor encargado de todas las funcionalidades del ABM
        GestorAMBPlaya gestor;

        //objeto PlayaDeEsyacionamiento para guardar de manera global la playa que se esta actualizando
        PlayaDeEstacionamiento playaEditar;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                cargarComboTiposPlayas();                
            }
        }

        public void cargarComboTiposPlayas()
        {
            gestor = new GestorAMBPlaya();
            ddlTipoPlaya.DataSource = gestor.buscarTipoPlayas();
            ddlTipoPlaya.DataTextField = "nombre";
            ddlTipoPlaya.DataValueField = "id";
            ddlTipoPlaya.DataBind();
        }

        /// <summary>
        /// Guarda o Actualiza un Playa de Estacionemiento
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            //instancio el gestor
            gestor = new GestorAMBPlaya();

            if (playaEditar == null)//creo una nueva playa
            {
                //Creo el objeto de la nueva PlayaDeEstacionamiento
                PlayaDeEstacionamiento p = new PlayaDeEstacionamiento();

                //seteo lo valores
                p.Nombre = txtNombre.Text;
                p.Direccion = txtDireccion.Text;
                p.TipoPlaya = int.Parse(ddlTipoPlaya.SelectedValue);
                p.Capacidad = int.Parse(txtCapacidad.Text);
                p.Latitud = Double.Parse(txtLatitud.Text);
                p.Longitud = Double.Parse(txtLongitud.Text);
                p.HoraDesde = DateTime.Parse(txtDesde.Text);
                p.HoraHasta = DateTime.Parse(txtHasta.Text);
                if (chkMotos.Checked)
                    p.Motos = true;
                else
                    p.Motos = false;
                if (chkBicis.Checked)
                    p.Bicicletas = true;
                else
                    p.Bicicletas = false;
                if (chkUtilitarios.Checked)
                    p.Utilitarios = true;
                else
                    p.Utilitarios = false;

                //registro la playa a travez del gestor
                gestor.registrarPlaya(p);

                //limpio el formulario
                limpiarCampos();

                //mensaje de registracion correcta
                Response.Write("<script>alert('La playa fue registrada correctamente');</script>");
            }
            else //edito el objeto playa editar
            {
                //seteo los nuevos valores
                playaEditar.Nombre = txtNombre.Text;
                playaEditar.Direccion = txtDireccion.Text;
                playaEditar.TipoPlaya = int.Parse(ddlTipoPlaya.SelectedValue);
                playaEditar.Capacidad = int.Parse(txtCapacidad.Text);
                playaEditar.Latitud = Double.Parse(txtLatitud.Text);
                playaEditar.Longitud = Double.Parse(txtLongitud.Text);
                playaEditar.HoraDesde = DateTime.Parse(txtDesde.Text);
                playaEditar.HoraHasta = DateTime.Parse(txtHasta.Text);
                if (chkMotos.Checked)
                    playaEditar.Motos = true;
                else
                    playaEditar.Motos = false;
                if (chkBicis.Checked)
                    playaEditar.Bicicletas = true;
                else
                    playaEditar.Bicicletas = false;
                if (chkUtilitarios.Checked)
                    playaEditar.Utilitarios = true;
                else
                    playaEditar.Utilitarios = false;

                //actualizo la playa a travez del gestor
                gestor.actulaizarPlaya(playaEditar);

                //limpio el formulario
                limpiarCampos();

                //borro de memoria la playa que ya fue editada
                playaEditar = null;

                //mensaje de actualizacion correcta
                Response.Write("<script>alert('La playa fue actualizada correctamente');</script>");
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
            //instancio el gestor
            gestor = new GestorAMBPlaya();

            //lleno la grilla
            gvResultados.DataSource = gestor.buscarPlayaPorNombre(txtFiltroNombre.Text);
            gvResultados.DataBind();

            //la hago visible (no se como lo vas a hacer yo lo hice asi porque necesitaba verla)
            gvResultados.Visible = true;
        }

        /// <summary>
        /// Carga los campos del formulario con datos de la playa a editar
        /// </summary>
        /// <param name="idPlaya">ID de la playa a editar</param>
        private void editarPlaya(int idPlaya)
        {
            Titulo.Text = "Editar";

            //cargo la variable globla de la playa a editar
            playaEditar = gestor.buscarPlayaPorId(idPlaya);

            //cargo todos los campos del formulario
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

        //no se que hace ni cuando se ejecuta (nunca entro en el codigo)
        void gvResultados_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            gestor = new GestorAMBPlaya();

            var acciones = new List<string> { "Editar", "Eliminar" };

            if (!acciones.Contains(e.CommandName))
                return;

            switch (e.CommandName)
            {
                case "Eliminar":
                    var idEliminar = gvResultados.Rows[Convert.ToInt32(e.CommandArgument)].Cells[0].Text;

                    //elimina la playa
                    gestor.eliminarPlaya(int.Parse(idEliminar));
                    
                    Response.Write("<script>alert('La playa fue eliminada correctamente');</script>");
                    break;
                case "Editar":
                    var idEditar = gvResultados.Rows[Convert.ToInt32(e.CommandArgument)].Cells[0].Text;
                    
                    //Carga los campos de la playa a editar
                    editarPlaya(int.Parse(idEditar));                    
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
    }
}