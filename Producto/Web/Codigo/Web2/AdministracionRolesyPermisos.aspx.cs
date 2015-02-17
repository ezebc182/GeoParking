using Entidades;
using ReglasDeNegocio;
using ReglasDeNegocio.Util;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using Web2.Util;

namespace Web2
{
    public partial class AdministracionRolesyPermisos : System.Web.UI.Page
    {

        public static GestorRol gestorRol = new GestorRol();
        public static GestorUsuario gestorUsuario = new GestorUsuario();
        public MasterAdmin master;

        protected void Page_Load(object sender, EventArgs e)
        {
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
                    case "AsignarPermiso":
                        CargarPanelAsignarPermiso();
                        break;
                    case "AsignarRol":
                        CargarPanelAsignarRol();
                        break;

                    default:
                        Response.Redirect("/web.aspx");
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

        [WebMethod]
        public static string CrearRol(string nombre, string descripcion)
        {
            Rol rolNuevo = new Rol();
            rolNuevo.Nombre = nombre;
            rolNuevo.Descripcion = descripcion;
            return gestorRol.ResultadoCrearRolJSON(rolNuevo);
        }

        #endregion

        #region PanelAsignarPermiso
        private void CargarPanelAsignarPermiso()
        {
            divCrearRol.Visible = false;
            divAsignarPermiso.Visible = true;
            divAsignarRol.Visible = false;
            CargarComboRolPermisos();
            hdPermisos.Value = gestorRol.GetPermisosJSON(Int32.Parse(ddlRolPermisos.SelectedValue));
            CargarListadoCheckBoxPermisos();

        }

        private void CargarComboRolPermisos()
        {
            ddlRolPermisos.DataSource = GetRoles();
            ddlRolPermisos.DataTextField = "Nombre";
            ddlRolPermisos.DataValueField = "Id";
            ddlRolPermisos.DataBind();
        }

        private void CargarListadoCheckBoxPermisos()
        {
            IList<Permiso> permisos = gestorRol.BuscarPermisos();
            cblPermiso.DataSource = permisos;
            cblPermiso.DataTextField = "Nombre";
            cblPermiso.DataValueField = "Id";
            cblPermiso.DataBind();
        }

        [WebMethod]
        public static List<Permiso> GetPermisos(int rol)
        {
            var query = from item in GetRoles().AsEnumerable()
                        where Convert.ToInt32(item["Id"]) == rol
                        select new Permiso
                        {
                            Id = Convert.ToInt32(item["Id"]),
                            Nombre = Convert.ToString(item["Nombre"])
                        };

            return query.ToList<Permiso>();
        }

        [WebMethod]
        public static string Permisos(string idPermiso)
        {
            return gestorRol.GetPermisosJSON(Int32.Parse(idPermiso));
        }

        [WebMethod]
        public static string GuardarPermisos(string idRol, string listaPermisos)
        {
            //Resultado resultado;
            Rol rolSeleccionado = gestorRol.BuscarRol(Int32.Parse(idRol));
            List<Permiso> nuevaListaPermisos = new List<Permiso>();
            char[] arrayPermisos = listaPermisos.ToCharArray();
            foreach (var item in arrayPermisos)
            {
                if (item != '-')
                {
                    nuevaListaPermisos.Add(gestorRol.BuscarPermiso(Int32.Parse(item.ToString())));
                }
            }
            rolSeleccionado.Permisos = nuevaListaPermisos;

            return gestorRol.ResultadoGuardarJSON(rolSeleccionado);
        }
       
        #endregion

        #region PanelAsignarRol
        private void CargarPanelAsignarRol()
        {
            divCrearRol.Visible = false;
            divAsignarPermiso.Visible = false;
            divAsignarRol.Visible = true;
            cargarComboUsuario();
            cargarComboRoles();
        }

        private void cargarComboUsuario()
        {
            ddlUsuario.DataSource = GetUsuarios();
            ddlUsuario.DataTextField = "NombreUsuario";
            ddlUsuario.DataValueField = "Id";
            ddlUsuario.DataBind();
        }

        private void cargarComboRoles()
        {
            ddlRol.DataSource = GetRoles();
            ddlRol.DataTextField = "Nombre";
            ddlRol.DataValueField = "Id";
            ddlRol.DataBind();
        }

        [WebMethod]
        public static string CargarComboRol(string idUsuario)
        {
            return gestorUsuario.BuscarUsuarioJSON(Int32.Parse(idUsuario));
        }

        [WebMethod]
        public static string GuardarRolUsuario(string usuario, string rol)
        {
            return gestorUsuario.AsigarRolAUsuarioJSON(Int32.Parse(usuario), Int32.Parse(rol));
        }

        #endregion

        private static DataTable GetUsuarios()
        {
            GestorUsuario gestorUsuario = new GestorUsuario();
            DataTable dt = new DataTable();
            var resultado = gestorUsuario.BuscarUsuarios();
            dt.Columns.Add("Id");
            dt.Columns.Add("NombreUsuario");
            foreach (var item in resultado)
            {
                DataRow row = dt.NewRow();
                row["Id"] = item.Id;
                row["NombreUsuario"] = item.NombreUsuario;
                dt.Rows.Add(row);
            }
            return dt;
        }

        private static DataTable GetRoles()
        {
            GestorRol gestorRol = new GestorRol();
            DataTable dt = new DataTable();
            var resultado = gestorRol.BuscarRoles();
            dt.Columns.Add("Id");
            dt.Columns.Add("Nombre");
            foreach (var item in resultado)
            {
                DataRow row = dt.NewRow();
                row["Id"] = item.Id;
                row["Nombre"] = item.Nombre;
                dt.Rows.Add(row);
            }
            return dt;
        }

    }
}