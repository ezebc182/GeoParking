using Entidades;
using ReglasDeNegocio;
using ReglasDeNegocio.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Web2.Util;

namespace Web2
{
    public partial class AdministracionUsuarios : System.Web.UI.Page
    {
        GestorRol gestorRol = new GestorRol();
        GestorUsuario gestorUsuario;
        public MasterAdmin master;
        protected void Page_Load(object sender, EventArgs e)
        {
            gestorUsuario = new GestorUsuario();
            master = (MasterAdmin) Master;

            if (!Page.IsPostBack)
            {
                string action = Request.QueryString["accion"];
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
            divCrearRol.Visible = true;
            divAsignarPermiso.Visible = false;
            divAsignarRol.Visible = false;

        }
        private Resultado crearRol()
        {
            Resultado resultado;
            Rol rolNuevo = new Rol();
            rolNuevo.Nombre = txtNombre.Text;
            rolNuevo.Descripcion = txtDescripcion.Text;
            resultado = gestorRol.CrearRol(rolNuevo);
            return resultado;
        }

        #endregion

        #region PanelAsignarRol
        private void CargarPanelAsignarRol()
        {
            divCrearRol.Visible = false;
            divAsignarPermiso.Visible = true;
            divAsignarRol.Visible = false;
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
            return UsuarioSeleccionado.RolId != IdRolSeleccionado;
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
            var ge = gestorUsuario.BuscarUsuarios();
            FormHelper.CargarCombo(ddlUsuario, gestorUsuario.BuscarUsuarios(), "NombreUsuario", "Id", "Seleccione");
        }
        private void cargarComboRolUsuario()
        {
            FormHelper.CargarCombo(ddlRol, gestorUsuario.BuscarRoles(), "Nombre", "Id", "Seleccione");
            if (ddlUsuario.SelectedIndex != 0)
            {
                Usuario usuarioSeleccionado = gestorUsuario.BuscarUsuarioPorId(IdUsuarioSeleccionado);
                if (usuarioSeleccionado != null)
                {
                    ddlRol.SelectedValue = usuarioSeleccionado.Rol.Id.ToString();
                }
            }
        }
        private Resultado guardarRolAUsuario()
        {
            Resultado resultado;
            resultado = gestorUsuario.AsigarRolAUsuario(IdUsuarioSeleccionado, IdRolSeleccionado);
            return resultado;
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
            divCrearRol.Visible = false;
            divAsignarPermiso.Visible = false;
            divAsignarRol.Visible = true;
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
        private Resultado AsignarPermisosARol()
        {
            Resultado resultado;

            Rol rolSeleccionado = RolSeleccionado;
            rolSeleccionado.Permisos = tomarPermisosSeleccionados();
            resultado = gestorRol.GuardarRol(rolSeleccionado);
            return resultado;
        }


        private int IdRolSeleccionado
        {
            get
            {
                if (divAsignarPermiso.Visible)
                {
                    return int.Parse(ddlRolPermisos.SelectedValue);
                }
                else if (divAsignarRol.Visible)
                {
                    return int.Parse(ddlRol.SelectedValue);
                }
                else return 0;
            }
        }
        public Usuario UsuarioSeleccionado
        {
            get
            {
                return gestorUsuario.BuscarUsuarioPorId(IdUsuarioSeleccionado);
            }
        }

        public Rol RolSeleccionado
        {
            get
            {
                if (divAsignarPermiso.Visible)
                {
                    return gestorRol.BuscarRol(IdRolSeleccionado);
                }
                else if (divAsignarRol.Visible)
                {
                    return gestorRol.BuscarRol(IdRolSeleccionado);
                }
                else return null;
            }
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
            Resultado resultado = new Resultado();
            String mensaje = "";
            string titulo = "Rol guardado con éxito.";

            if (divCrearRol.Visible)
            {
                resultado = crearRol();
                mensaje = "El Rol " + txtNombre.Text + " se creo correctamente.";
                txtDescripcion.Text = "";
                txtNombre.Text = "";
            }
            else if (divAsignarRol.Visible)
            {
                resultado = guardarRolAUsuario();
                mensaje = "El Rol " + RolSeleccionado.Nombre + " se asigno correctamente al usuario " + UsuarioSeleccionado.Nombre + ".";
                limpiarComponentesAsignarRol();
            }
            else if (divAsignarPermiso.Visible)
            {
                if (ddlRolPermisos.SelectedIndex != 0)
                {
                    if (hayCambiosPorGuardarAsignarPermiso(RolSeleccionado, tomarPermisosSeleccionados()))
                    {
                        resultado = AsignarPermisosARol();
                        mensaje = "Los permisos han sido guardados para el rol '" + RolSeleccionado.Nombre + "'";
                    }
                    else
                    {
                        mensaje = "No se encontraron cambios para el rol'" + ddlRolPermisos.SelectedItem.Text + "'";
                    }

                }
                ddlRolPermisos.SelectedIndex = 0;
                LimpiarCheckboxListPermisos();
                cblPermiso.Enabled = false;
            }

            //if (resultado.Ok)
            //    master.MostrarMensajeInformacion(TipoMensajeEnum.MostrarAlertaYModal, mensaje, titulo);
        }

        public int IdUsuarioSeleccionado
        {
            get { return string.IsNullOrEmpty(ddlUsuario.SelectedValue) ? 0 : Convert.ToInt32(ddlUsuario.SelectedValue); }
            set { ddlUsuario.SelectedValue = value.ToString(); }
        }
        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            if (divCrearRol.Visible)
            {
                txtDescripcion.Text = "";
                txtNombre.Text = "";
            }
            else if (divAsignarRol.Visible)
            {
                limpiarComponentesAsignarRol();
            }
            else if (divAsignarPermiso.Visible)
            {
                LimpiarCheckboxListPermisos();
                ddlRolPermisos.SelectedIndex = -1;
                cblPermiso.Enabled = false;
            }
        }
    }
}