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
    public partial class AsignarPermisoARol : System.Web.UI.Page
    {
        GestorRol gestor = new GestorRol();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                cargarComboRol();
                cargarListadoCheckBoxPermisos();
            }
        }
        public void cargarComboRol()
        {
            FormHelper.CargarCombo(ddlRol, gestor.BuscarRoles(), "Nombre", "Id", "Seleccione");
        }
        public void cargarListadoCheckBoxPermisos()
        {
            //Rol rol = gestor.BuscarRol(int.Parse(ddlRol.SelectedValue));
            cblPermiso.DataSource = gestor.BuscarPermisos();
            cblPermiso.DataTextField = "Nombre";
            cblPermiso.DataBind();
            if (ddlRol.SelectedIndex != 0)
            {
                seleccionarPermisosDeRol();
            }
        }
        public void seleccionarPermisosDeRol()
        {
            Rol rol = gestor.BuscarRol(int.Parse(ddlRol.SelectedValue));
            IList<Permiso> permisos = gestor.BuscarPermisosPorRol(rol);
            foreach (Permiso permiso in permisos)
            {
                cblPermiso.Items.FindByValue(permiso.Id.ToString()).Selected = true;
            }
        }

        protected void ddlRol_SelectedIndexChanged(object sender, EventArgs e)
        {
            seleccionarPermisosDeRol();
        }

    }
}