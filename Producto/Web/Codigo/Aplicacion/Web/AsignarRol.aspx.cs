using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidades;
using ReglasDeNegocio;
using Web.Util;

namespace Web
{
    public partial class AsignarRol : System.Web.UI.Page
    {
        GestorUsuario gestor;
        SiteMaster master;

        protected void Page_Load(object sender, EventArgs e)
        {
            gestor = new GestorUsuario();
            master = (SiteMaster)Master;

            if (!Page.IsPostBack)
            {
                btnGuardar.Enabled = false;
                ddlRol.Enabled = false;
                cargarComboUsuario();
                //cargarComboRol();
            }
        }

        protected void ddlUsuario_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlUsuario.SelectedIndex != 0)
            {
                cargarComboRol();
                ddlRol.Enabled = true;
            }
            else
            {
                limpiarComponentes();
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            guardar();
        }

        private void guardar()
        {
            try
            {
                gestor.AsigarRolAUsuario(int.Parse(ddlUsuario.SelectedValue), int.Parse(ddlRol.SelectedValue));
                master.MostrarMensajeInformacion("El rol '" + ddlRol.SelectedItem.Text + "' ha sido asignado al usuario '" + ddlUsuario.SelectedItem.Text + "'", "Rol guardado con éxito.");
                limpiarComponentes();
            }
            catch (Exception)
            {
                master.MostrarMensajeError("No se pudo asignar el rol '" + ddlRol.SelectedItem.Text + "' al usuario '" + ddlUsuario.SelectedItem.Text+"'", "Error al guardar el rol");
            }
            
            
        }
        public void limpiarComponentes()
        {
            ddlRol.SelectedIndex = 0;
            ddlUsuario.SelectedIndex = 0;
            ddlRol.Enabled = false;
            btnGuardar.Enabled = false;
        }


        private void cargarComboUsuario()
        {
            FormHelper.CargarCombo(ddlUsuario, gestor.BuscarUsuarios(), "NombreUsuario", "Id", "Seleccione");
        }

        private void cargarComboRol()
        {
            FormHelper.CargarCombo(ddlRol, gestor.BuscarRoles(), "Nombre", "Id", "Seleccione");
            if (ddlUsuario.SelectedIndex != 0)
            {
                Usuario usuarioSeleccionado = gestor.BuscarUsuarioPorId(int.Parse(ddlUsuario.SelectedValue));
                if (usuarioSeleccionado != null)
                {
                    ddlRol.SelectedValue = usuarioSeleccionado.Rol.Id.ToString();
                }
            }
        }

        public int IdUsuarioSeleccionado
        {
            get { return string.IsNullOrEmpty(ddlUsuario.SelectedValue) ? 0 : Convert.ToInt32(ddlUsuario.SelectedValue); }
            set { ddlUsuario.SelectedValue = value.ToString(); }
        }

        protected void ddlRol_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlRol.SelectedIndex != 0)
            {
                btnGuardar.Enabled = true;
            }
            else
            {
                btnGuardar.Enabled = false;
            }
        }
    }
}