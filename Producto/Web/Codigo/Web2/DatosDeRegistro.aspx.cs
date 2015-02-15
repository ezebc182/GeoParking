using Entidades;
using ReglasDeNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using ReglasDeNegocio.Util;

namespace Web2
{
    public partial class DatosDeRegistro : System.Web.UI.Page
    {
        private static GestorUsuario gestor;
        private static GestorEmails mandarEmail;
        private static Encriptacion encriptacion;

        protected void Page_Load(object sender, EventArgs e)
        {
            gestor = new GestorUsuario();
            mandarEmail = new GestorEmails();
            encriptacion = new Encriptacion();
            if (SessionUsuario != null)
            {
                CargarDatosUsuario();
                hfNuevo.Value = "false";
            }
            else
            {
                divContraseñaVieja.Attributes["style"] = "display:none";
                lbltxtContraseñaNueva.InnerText = "(*) Contraseña:";
                lblRepetirContraseñaNueva.InnerText = "(*) Repetir Contraseña:";
                divContraseñaNueva.Attributes["class"] = "col-lg-6";
                divRepetirContraseñaNueva.Attributes["class"] = "col-lg-6";
                h_Titulo.InnerText = "Registro de Usuario -  Complete con sus datos";
                hfNuevo.Value = "true";
            }
        }

        public void CargarDatosUsuario()
        {
            Usuario usuario = gestor.BuscarUsuario(SessionUsuario.Id);
            txtNombreEditar.Text = usuario.Nombre;
            txtApellidoEditar.Text = usuario.Apellido;
            txtEmailEditar.Text = usuario.Mail;
            lblUsuarioEditar.Text = usuario.NombreUsuario;
            txtUsuario.Text = usuario.NombreUsuario;
            txtUsuario.Enabled = false;
            if (usuario.DNI != 0)
            {
                txtDni.Text = usuario.DNI.ToString();
            }
            if (usuario.Direccion != null)
            {
                txtDireccion.Text = usuario.Direccion.ToString();
            }
            if (usuario.FechaDeNacimiento.Year != 1900)
            {
                txtfechaNacimiento.Text = usuario.FechaDeNacimiento.ToString("yyyy-MM-dd");
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

        [WebMethod]
        public static string RegistrarUsuario(string nombre, string apellido, string usuario, string fecha, string direccion, string dni, string email, string contraseña)
        {
            Usuario NuevoUsuario = new Usuario();
            NuevoUsuario.Apellido = apellido;
            NuevoUsuario.Contraseña = encriptacion.Encriptar(contraseña);
            NuevoUsuario.Direccion = direccion;
            NuevoUsuario.DNI = Int32.Parse(dni);
            NuevoUsuario.Estado = false;
            NuevoUsuario.FechaDeNacimiento = DateTime.Parse(fecha);
            NuevoUsuario.Mail = email;
            NuevoUsuario.Nombre = nombre;
            NuevoUsuario.NombreUsuario = usuario;
            NuevoUsuario.RolId = 1;
            string url = HttpContext.Current.Request.Url.ToString();
            Uri uri = new Uri(url);
            mandarEmail.EnviarEmail("Presione el siguiente link para activar la cuenta " + uri.GetLeftPart(UriPartial.Authority) + "/Index.aspx?usuario="+ encriptacion.Encriptar(NuevoUsuario.NombreUsuario), NuevoUsuario.Mail, "Registro de Usuario en Geoparking");
            return gestor.RegistrarUsuarioJSON(NuevoUsuario);
        }
    }
}