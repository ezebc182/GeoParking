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
        SiteMaster master;
        protected void Page_Load(object sender, EventArgs e)
        
        {
            gestorUsuario = new GestorUsuario();
            master = (SiteMaster)Master;
            if (!Page.IsPostBack)
            {
                //cargarComboRol();
                //cargarListadoCheckBoxPermisos();
                //cblPermiso.Enabled = false;
                //btnGuardar.Enabled = false;
                //cargarComboUsuario();
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            crearRol();
            txtDescripcion.Text = "";
            txtNombre.Text = "";
        }

        private void crearRol()
        {
            Rol rolNuevo = new Rol();
            rolNuevo.Nombre = txtNombre.Text;
            rolNuevo.Descripcion = txtDescripcion.Text;
            gestorRol.CrearRol(rolNuevo);
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
        private bool hayCambiosPorGuardar()
        {
            Usuario usuarioSeleccionado = gestorUsuario.BuscarUsuarioPorId(int.Parse(ddlUsuario.SelectedValue));
            return usuarioSeleccionado.RolId != int.Parse(ddlRol.SelectedValue);

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
            FormHelper.CargarCombo(ddlUsuario, gestorUsuario.BuscarUsuarios(), "NombreUsuario", "Id", "Seleccione");
        }

        private void cargarComboRol()
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

        public int IdUsuarioSeleccionado
        {
            get { return string.IsNullOrEmpty(ddlUsuario.SelectedValue) ? 0 : Convert.ToInt32(ddlUsuario.SelectedValue); }
            set { ddlUsuario.SelectedValue = value.ToString(); }
        }

        protected void ddlRol_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlRol.SelectedIndex != 0 && hayCambiosPorGuardar())
            {
                btnGuardar.Enabled = true;
            }
            else
            {
                btnGuardar.Enabled = false;
            }
        }

       

        private void guardar()
        {
            try
            {
                gestorUsuario.AsigarRolAUsuario(int.Parse(ddlUsuario.SelectedValue), int.Parse(ddlRol.SelectedValue));
                master.MostrarMensajeInformacion("El rol '" + ddlRol.SelectedItem.Text + "' ha sido asignado al usuario '" + ddlUsuario.SelectedItem.Text + "'", "Rol guardado con éxito.");
                limpiarComponentes();
            }
            catch (Exception)
            {
                master.MostrarMensajeError("No se pudo asignar el rol '" + ddlRol.SelectedItem.Text + "' al usuario '" + ddlUsuario.SelectedItem.Text + "'", "Error al guardar el rol");
            }


        }

        protected void btnGuardarAsignacion_Click(object sender, EventArgs e)
        {
            guardar();
        }


        private void cargarListadoCheckBoxPermisos()
        {
            IList<Permiso> permisos = gestorRol.BuscarPermisos();
            cblPermiso.DataSource = permisos;
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
            Rol rol = gestorRol.BuscarRol(int.Parse(ddlRol.SelectedValue));
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

        protected void Button1_Click(object sender, EventArgs e)
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

            if (hayCambiosPorGuardar(rolSeleccionado, permisos))
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
                    + ddlRol.SelectedItem.Text + "'",
                    "Error al guardar el rol");
            }

        }
        private Rol tomarRolSeleccionado()
        {
            return gestorRol.BuscarRol(int.Parse(ddlRol.SelectedValue));
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
