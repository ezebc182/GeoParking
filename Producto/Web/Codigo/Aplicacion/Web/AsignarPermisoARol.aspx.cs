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
        SiteMaster master;
        GestorRol gestor = new GestorRol();
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!Page.IsPostBack)
            {
                master = (SiteMaster)Master;
                cargarComboRol();
                cargarListadoCheckBoxPermisos();
                cblPermiso.Enabled = false;
            }
        }
        private void cargarComboRol()
        {
            FormHelper.CargarCombo(ddlRol, gestor.BuscarRoles(), "Nombre", "Id", "Seleccione");
        }
        private void cargarListadoCheckBoxPermisos()
        {
            cblPermiso.DataSource = gestor.BuscarPermisos();
            cblPermiso.DataTextField = "Nombre";
            cblPermiso.DataValueField = "Id";
            cblPermiso.DataBind();
            if (ddlRol.SelectedIndex != 0)
            {
                seleccionarPermisosDeRol();
            }
        }
        private void seleccionarPermisosDeRol()
        {
            Rol rol = gestor.BuscarRol(int.Parse(ddlRol.SelectedValue));
            rol.Permisos = gestor.BuscarPermisosPorRol(rol);
            foreach (Permiso permiso in rol.Permisos)
            {
                cblPermiso.Items.FindByValue(permiso.Id.ToString()).Selected = true;
            }
        }

        private void LimpiarCheckboxListPermisos()
        {
            for (int i = 0; i < cblPermiso.Items.Count; i++)
            {
                cblPermiso.Items[i].Selected = false;
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            if (ddlRol.SelectedIndex != 0)
            {
                AsignarPermisosARol();
            }
            ddlRol.SelectedIndex = 0;
            LimpiarCheckboxListPermisos();
            cblPermiso.Enabled = false;
            //master.Alert = "cambios guardados con exito!";
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            LimpiarCheckboxListPermisos();
            ddlRol.SelectedIndex = -1;
        }

        private void AsignarPermisosARol()
        {
            Rol rolSeleccionado = gestor.BuscarRol(int.Parse(ddlRol.SelectedValue));
            
            IList<Permiso> permisos = new List<Permiso>();
            foreach (ListItem item in cblPermiso.Items)
            {
                if (item.Selected)
                {
                    permisos.Add(gestor.BuscarPermiso(int.Parse(item.Value)));
                }
            }
            rolSeleccionado.Permisos = permisos;
            gestor.GuardarRol(rolSeleccionado);
        }

        protected void ddlRol_SelectedIndexChanged1(object sender, EventArgs e)
        {
            LimpiarCheckboxListPermisos();
            if (ddlRol.SelectedIndex != 0)
            {
                cblPermiso.Enabled = true;
                seleccionarPermisosDeRol();
            }
        }


    }
}