using Entidades;
using ReglasDeNegocio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web2
{
    public partial class AdministracionSolicitudesYConexiones : System.Web.UI.Page
    {
        private int rolId;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (SessionUsuario != null)
                {
                    rolId = SessionUsuario.RolId;
                    if (rolId == 1)
                    {
                        t_solicitudes.InnerText = " Mis Solicitudes";
                        t_conexiones.InnerText = " Mis Conexiones";
                        gvSolicitudes.DataSource = GetMisSolicitudes(SessionUsuario.NombreUsuario);
                        gvSolicitudes.DataBind();
                    }
                    else
                    {
                        gvSolicitudes.DataSource = GetSolicitudes();
                        gvSolicitudes.DataBind();
                    }
                }
            }
        }
        public Usuario SessionUsuario
        {
            get
            {
                if (Request.Cookies["SessionUsuario"] != null)
                {
                    Usuario sesion = new Usuario();
                    sesion.RolId = Int32.Parse(Request.Cookies["SessionUsuario"]["Rol"]);
                    sesion.NombreUsuario = Request.Cookies["SessionUsuario"]["NombreUsuario"];
                    sesion.Contraseña = Request.Cookies["SessionUsuario"]["Contraseña"];
                    sesion.Id = Int32.Parse(Request.Cookies["SessionUsuario"]["IdUsuario"]);
                    sesion.Nombre = Request.Cookies["SessionUsuario"]["Nombre"];
                    sesion.Apellido = Request.Cookies["SessionUsuario"]["Apellido"];
                    sesion.Mail = Request.Cookies["SessionUsuario"]["Mail"];
                    return sesion;
                }
                else
                {
                    return null;
                }
            }
        }

        private static DataTable GetSolicitudes()
        {
            GestorSolicitud gestorSolicitud = new GestorSolicitud();
            DataTable dt = new DataTable();
            var resultado = gestorSolicitud.BuscarSolicitudes();
            dt.Columns.Add("Id");
            dt.Columns.Add("NombrePlaya");
            dt.Columns.Add("UsuarioResponsable");
            dt.Columns.Add("EstadoId");
            foreach (var item in resultado)
            {
                DataRow row = dt.NewRow();
                row["Id"] = item.Id;
                row["NombrePlaya"] = item.NombrePlaya;
                row["UsuarioResponsable"] = item.UsuarioResponsable;
                row["EstadoId"] = item.EstadoId;
                dt.Rows.Add(row);
            }
            return dt;
        }

        private static DataTable GetMisSolicitudes(string usuario)
        {
            GestorSolicitud gestorSolicitud = new GestorSolicitud();
            DataTable dt = new DataTable();
            var resultado = gestorSolicitud.BuscarMisSolicitudes(usuario);
            dt.Columns.Add("Id");
            dt.Columns.Add("NombrePlaya");
            dt.Columns.Add("UsuarioResponsable");
            dt.Columns.Add("EstadoId");
            foreach (var item in resultado)
            {
                DataRow row = dt.NewRow();
                row["Id"] = item.Id;
                row["NombrePlaya"] = item.NombrePlaya;
                row["UsuarioResponsable"] = item.UsuarioResponsable;
                row["EstadoId"] = item.EstadoId;
                dt.Rows.Add(row);
            }
            return dt;
        }
    }
}