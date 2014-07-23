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
            }
        }

        protected void ddlUsuario_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            Usuario usuario = new Usuario();
            Rol rol = new Rol();
            guardar(usuario, rol);
        }

        private void guardar(Usuario usuario, Rol rol)
        {
            
        }

        private void cargarComboUsuario()
        {
            FormHelper.CargarCombo(ddlUsuario, gestor.BuscarUsuarios(), "Nombre", "Id", "Seleccione");
            ddlUsuario.DataSource = gestor.BuscarUsuarios();
            ddlUsuario.DataBind();
        }

        public int IdUsuarioSeleccionado
        {
            get { return string.IsNullOrEmpty(ddlUsuario.SelectedValue) ? 0 : Convert.ToInt32(ddlUsuario.SelectedValue); }
            set { ddlUsuario.SelectedValue = value.ToString(); }
        }
    }
}