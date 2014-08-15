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
            master = (SiteMaster)Master;
            if (!Page.IsPostBack)
            {
                cargarComboRol();
                cargarListadoCheckBoxPermisos();
                cblPermiso.Enabled = false;
                btnGuardar.Enabled = false;
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
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            LimpiarCheckboxListPermisos();
            ddlRol.SelectedIndex = -1;
        }

        private void AsignarPermisosARol()
        {
            Rol rolSeleccionado = tomarRolSeleccionado();
            IList<Permiso> permisos = tomarPermisosSeleccionados();
            if (hayCambiosPorGuardar(rolSeleccionado,permisos))
            {
                rolSeleccionado.Permisos = permisos;
                gestor.GuardarRol(rolSeleccionado);
                master.MostrarMensajeInformacion(
                "Los permisos han sido guardados para el rol '"
                + rolSeleccionado.Nombre
                + "'"
                , "Rol guardado con éxito.");
            }
            else
            {
                master.MostrarMensajeError(
                    "No se encontraron cambios para el rol'"
                    + ddlRol.SelectedItem.Text+"'",
                    "Error al guardar el rol");
            }
            
        }
        private Rol tomarRolSeleccionado()
        {
            return gestor.BuscarRol(int.Parse(ddlRol.SelectedValue));
        }
        private IList<Permiso> tomarPermisosSeleccionados()
        {
            IList<Permiso> permisos = new List<Permiso>();
            foreach (ListItem item in cblPermiso.Items)
            {
                if (item.Selected)
                {
                    permisos.Add(gestor.BuscarPermiso(int.Parse(item.Value)));
                }
            }
            return permisos;
        }
        private bool hayCambiosPorGuardar(Rol rolSeleccionado, IList<Permiso> permisos)
        {
            bool diferencia = false;
            if (permisos.Count != rolSeleccionado.Permisos.Count)
            {
                diferencia = true;
            }
            else
            {
                for (int i = 0; i < permisos.Count; i++)
                {
                    if (permisos[i].Id != rolSeleccionado.Permisos[i].Id)
                    {
                        diferencia = true;
                        break;
                    }
                }
            }
            return diferencia;
        }
        protected void ddlRol_SelectedIndexChanged1(object sender, EventArgs e)
        {
            LimpiarCheckboxListPermisos();
            if (ddlRol.SelectedIndex != 0)
            {
                cblPermiso.Enabled = true;
                seleccionarPermisosDeRol();
            }
            else
            {
                cblPermiso.Enabled = false;
            }
        }

        protected void cblPermiso_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnGuardar.Enabled = ddlRol.SelectedIndex != 0 && hayCambiosPorGuardar(tomarRolSeleccionado(), tomarPermisosSeleccionados());
        }


    }
}