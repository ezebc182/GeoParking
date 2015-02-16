using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using Web2.Util;
using Entidades;
using ReglasDeNegocio;
using ReglasDeNegocio.Util;

namespace Web2
{
    public partial class MasterUsuario : System.Web.UI.MasterPage
    {
        //gestor encargado de todas las funcionalidades del ABM
        private static GestorUsuario gestor;
        private static Encriptacion encriptacion;
        private int rolId;

        protected void Page_Load(object sender, EventArgs e)
        {
            gestor = new GestorUsuario();
            encriptacion = new Encriptacion();

            if (Request.QueryString["usuario"] != null)
            {
                hfNuevoRegistro.Value = encriptacion.Desencriptar(Request.QueryString["usuario"].Replace(' ', '+'));
                Usuario usuario = gestor.BuscarPorNombreDeUsuario(hfNuevoRegistro.Value);
                usuario.Estado = true;
                if (usuario != null)
                {
                    gestor.UpdateUsuario(usuario);
                }
            }
            if (!Page.IsPostBack)
            {
                if (SessionUsuario != null)
                {
                    lblLogin.Text = SessionUsuario.NombreUsuario;
                    li_Ingresar.Visible = false;
                    li_Login.Visible = true;
                    rolId = SessionUsuario.RolId;
                    if (rolId == 1)
                    {
                        hrefAdministracion.Attributes["href"] = "/AdministracionSolicitudesYConexiones.aspx";
                    }
                }
            }
        }

        protected void btnIniciarSesion_Click(object sender, EventArgs e)
        {
            var resultado = gestor.Login(txtUsuarioLogin.Text, txtContraseñaLogin.Text);
            if (resultado != null)
            {
                SessionUsuario = resultado;
                lblLogin.Text = SessionUsuario.NombreUsuario;
                li_Ingresar.Visible = false;
                li_Login.Visible = true;
                rolId = SessionUsuario.RolId;
                if (rolId == 3 || rolId == 2)
                {
                    Response.Redirect("AdministracionPlayas.aspx");
                }
                else
                {
                    Response.Redirect("AdministracionSolicitudesYConexiones.aspx");
                }
            }
            else
            {
                hfResultadoLogin.Value = "false";
            }
        }

        protected void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            rolId = 0;
            if (Request.Cookies["SessionUsuario"] != null)
            {
                Response.Cookies["SessionUsuario"].Expires = DateTime.Now.AddDays(-1);
            }

            string[] segmentosURL = HttpContext.Current.Request.Url.Segments;
            string pagina = segmentosURL[segmentosURL.Length - 1];

            if (!(pagina == "BusquedaPlaya.aspx" || pagina == "Index.apsx"))
            {
                Response.Redirect("Index.aspx");
            }
            else
            {
                Response.Redirect(HttpContext.Current.Request.Url.ToString());
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
            set
            {

                HttpCookie myCookie = new HttpCookie("SessionUsuario"); //new cookie object
                Response.Cookies.Add(myCookie); //This will create new cookie

                myCookie.Values.Add("IdUsuario", value.Id.ToString());
                myCookie.Values.Add("NombreUsuario", value.NombreUsuario.ToString());
                myCookie.Values.Add("Nombre", value.Nombre.ToString());
                myCookie.Values.Add("Apellido", value.Apellido.ToString());
                myCookie.Values.Add("Mail", value.Mail.ToString());
                myCookie.Values.Add("Contraseña", value.Contraseña.ToString());
                myCookie.Values.Add("Rol", value.RolId.ToString());

                // You can add multiple values

                DateTime CookieExpir = DateTime.Now.AddDays(1); //Cookie life

                Response.Cookies["SessionUsuario"].Expires = CookieExpir; //Maximum day of cookie's life       

            }
        }
        
    }
}