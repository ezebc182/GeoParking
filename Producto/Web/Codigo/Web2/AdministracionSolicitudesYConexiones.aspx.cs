using Entidades;
using System;
using System.Collections.Generic;
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
    }
}