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
                cargarComboUsuario();
                cargarComboRol();
            }
        }

        protected void ddlUsuario_SelectedIndexChanged(object sender, EventArgs e)
        {
            cargarComboRol();
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            gestor.AsigarRolAUsuario(int.Parse(ddlUsuario.SelectedValue), int.Parse(ddlRol.SelectedValue));
        }

        private void guardar(Usuario usuario, Rol rol)
        {
            
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
                ddlRol.SelectedIndex = gestor.BuscarRolPorUsuarioId(ddlUsuario.SelectedIndex).Id;
            }
        }

        public int IdUsuarioSeleccionado
        {
            get { return string.IsNullOrEmpty(ddlUsuario.SelectedValue) ? 0 : Convert.ToInt32(ddlUsuario.SelectedValue); }
            set { ddlUsuario.SelectedValue = value.ToString(); }
        }
    }
}