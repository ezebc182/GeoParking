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
    public partial class AdministracionUsuarios : System.Web.UI.Page
    {
        GestorRol gestorRol = new GestorRol();
        GestorUsuario gestorUsuario;
        public SiteMaster master;
        protected void Page_Load(object sender, EventArgs e)
        {
            gestorUsuario = new GestorUsuario();
            master = (SiteMaster)Master;
            if (SessionUsuario == null || SessionUsuario.RolId==1 || SessionUsuario.RolId==2)
            {
                Response.Redirect("/Index.aspx");
            }
            if (!Page.IsPostBack)
            {
                string action = Request.QueryString["action"];
                panelBotones.Visible = true;
                switch (action)
                {
                    case "NuevoRol":
                        CargarPanelNuevoRol();
                        break;
                    case "AsignarRol":
                        CargarPanelAsignarRol();
                        break;
                    case "AsignarPermiso":
                        CargarPanelAsignarPermiso();
                        break;
                    default:
                        Response.Redirect("/Index.aspx");
                        break;
                }
            }
        }
        #region PanelNuevoRol
        private void CargarPanelNuevoRol()
        {
            panelNuevoRol.Visible = true;
            panelAsignarRol.Visible = false;
            panelAsignarPermiso.Visible = false;
            
        }
        private void crearRol()
        {
            Rol rolNuevo = new Rol();
            rolNuevo.Nombre = txtNombre.Text;
            rolNuevo.Descripcion = txtDescripcion.Text;
            gestorRol.CrearRol(rolNuevo);
        }
        
        #endregion

        #region PanelAsignarRol
        private void CargarPanelAsignarRol()
        {
            panelNuevoRol.Visible = false;
            panelAsignarRol.Visible = true;
            panelAsignarPermiso.Visible = false;
            cargarComboUsuario();
        }
        protected void ddlUsuario_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlUsuario.SelectedIndex != 0)
            {
                cargarComboRolUsuario();
                ddlRol.Enabled = true;
            }
            else
            {
                limpiarComponentesAsignarRol();
            }
        }
        private bool hayCambiosPorGuardarEnAsignarRol()
        {
            Usuario usuarioSeleccionado = gestorUsuario.BuscarUsuarioPorId(int.Parse(ddlUsuario.SelectedValue));
            return usuarioSeleccionado.RolId != int.Parse(ddlRol.SelectedValue);

        }
        public void limpiarComponentesAsignarRol()
        {
            ddlRol.SelectedIndex = 0;
            ddlUsuario.SelectedIndex = 0;
            ddlRol.Enabled = false;
            btnGuardar.Enabled = false;
        }
        private void cargarComboUsuario()
        {
            FormHelper.CargarCombo(ddlUsuario, gestorUsuario.BuscarUsuarios(), "NombreUsuario", "Id", "Seleccione");
        }
        private void cargarComboRolUsuario()
        {
            FormHelper.CargarCombo(ddlRol, gestorUsuario.BuscarRoles(), "Nombre", "Id", "Seleccione");
            if (ddlUsuario.SelectedIndex != 0)
            {
                Usuario usuarioSeleccionado = gestorUsuario.BuscarUsuarioPorId(int.Parse(ddlUsuario.SelectedValue));
                if (usuarioSeleccionado != null)
                {
                    ddlRol.SelectedValue = usuarioSeleccionado.Rol.Id.ToString();
                }
            }
        }
        private void guardarRolAUsuario()
        {
            try
            {
                gestorUsuario.AsigarRolAUsuario(int.Parse(ddlUsuario.SelectedValue), int.Parse(ddlRol.SelectedValue));
                master.MostrarMensajeInformacion("El rol '" + ddlRol.SelectedItem.Text + "' ha sido asignado al usuario '" + ddlUsuario.SelectedItem.Text + "'", "Rol guardado con éxito.");
                limpiarComponentesAsignarRol();
            }
            catch (Exception)
            {
                master.MostrarMensajeError("No se pudo asignar el rol '" + ddlRol.SelectedItem.Text + "' al usuario '" + ddlUsuario.SelectedItem.Text + "'", "Error al guardar el rol");
            }
        }
        protected void ddlRol_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlRol.SelectedIndex != 0 && hayCambiosPorGuardarEnAsignarRol())
            {
                btnGuardar.Enabled = true;
            }
            else
            {
                btnGuardar.Enabled = false;
            }
        }
        #endregion

        #region PanelAsignarPermiso
        private void CargarPanelAsignarPermiso()
        {
            panelNuevoRol.Visible = false;
            panelAsignarRol.Visible = false;
            panelAsignarPermiso.Visible = true;
            CargarComboRolPermisos();
            cargarListadoCheckBoxPermisos();
            cblPermiso.Enabled = false;
        }
        private void CargarComboRolPermisos()
        {
            FormHelper.CargarCombo(ddlRolPermisos, gestorUsuario.BuscarRoles(), "Nombre", "Id", "Seleccione");
        }
        private void cargarListadoCheckBoxPermisos()
        {
            IList<Permiso> permisos = gestorRol.BuscarPermisos();
            cblPermiso.DataSource = permisos;
            cblPermiso.DataTextField = "Nombre";
            cblPermiso.DataValueField = "Id";
            cblPermiso.DataBind();
            if (ddlRolPermisos.SelectedIndex != 0 && ddlRolPermisos.SelectedIndex != -1)
            {
                seleccionarPermisosDeRol();
            }
        }
        private void seleccionarPermisosDeRol()
        {
            Rol rol = gestorRol.BuscarRol(int.Parse(ddlRolPermisos.SelectedValue));
            rol.Permisos = gestorRol.BuscarPermisosPorRol(rol);
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
        private void AsignarPermisosARol()
        {
            Rol rolSeleccionado = tomarRolSeleccionado();
            IList<Permiso> permisos = tomarPermisosSeleccionados();

            if (hayCambiosPorGuardarAsignarPermiso(rolSeleccionado, permisos))
            {
                //rolSeleccionado.Permisos = permisos;
                foreach (Permiso permiso in permisos)
                {
                    if (!(rolSeleccionado.Permisos.Contains(permiso)))
                    {
                        rolSeleccionado.Permisos.Add(permiso);
                    }
                }
                foreach (Permiso permiso in permisos)
                {
                    if (!(permiso.Roles.Contains(rolSeleccionado)))
                    {
                        permiso.Roles.Add(rolSeleccionado);
                    }
                }
                gestorRol.GuardarRol(rolSeleccionado);
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
                    + ddlRolPermisos.SelectedItem.Text + "'",
                    "Error al guardar el rol");
            }

        }
        private Rol tomarRolSeleccionado()
        {
            return gestorRol.BuscarRol(int.Parse(ddlRolPermisos.SelectedValue));
        }
        protected void cblPermiso_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnGuardar.Enabled = ddlRolPermisos.SelectedIndex != 0 && hayCambiosPorGuardarAsignarPermiso(tomarRolSeleccionado(), tomarPermisosSeleccionados());
        }
        private IList<Permiso> tomarPermisosSeleccionados()
        {
            IList<Permiso> permisos = new List<Permiso>();
            foreach (ListItem item in cblPermiso.Items)
            {
                if (item.Selected)
                {
                    permisos.Add(gestorRol.BuscarPermiso(int.Parse(item.Value)));
                }
            }
            return permisos;
        }
        private bool hayCambiosPorGuardarAsignarPermiso(Rol rolSeleccionado, IList<Permiso> permisos)
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
            if (ddlRolPermisos.SelectedIndex != 0)
            {
                cblPermiso.Enabled = true;
                seleccionarPermisosDeRol();
            }
            else
            {
                cblPermiso.Enabled = false;
            }
        }
        #endregion

        public Usuario SessionUsuario
        {
            get { return (Usuario)Session["Usuario"]; }
            set { Session["Usuario"] = value; }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            if (panelNuevoRol.Visible)
            {
                crearRol();
                txtDescripcion.Text = "";
                txtNombre.Text = "";
            }
            else if (panelAsignarRol.Visible)
            {
                guardarRolAUsuario();
            }
            else if (panelAsignarPermiso.Visible)
            {
                if (ddlRolPermisos.SelectedIndex != 0)
                {
                    AsignarPermisosARol();
                }
                ddlRolPermisos.SelectedIndex = 0;
                LimpiarCheckboxListPermisos();
                cblPermiso.Enabled = false;
            }
        }
        public int IdUsuarioSeleccionado
        {
            get { return string.IsNullOrEmpty(ddlUsuario.SelectedValue) ? 0 : Convert.ToInt32(ddlUsuario.SelectedValue); }
            set { ddlUsuario.SelectedValue = value.ToString(); }
        }
        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            if (panelNuevoRol.Visible)
            {
                txtDescripcion.Text = "";
                txtNombre.Text = "";
            }
            else if (panelAsignarRol.Visible)
            {
                limpiarComponentesAsignarRol();
            }
            else if (panelAsignarPermiso.Visible)
            {
                LimpiarCheckboxListPermisos();
                ddlRolPermisos.SelectedIndex = -1;
                cblPermiso.Enabled = false;
            }
        }
    }
}
