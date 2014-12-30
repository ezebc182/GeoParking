using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web2
{
    public partial class Formulario_web1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (SessionUsuario != null)
            {

            }
        }

        public Usuario SessionUsuario
        {
            get
            {
                if (Request.Cookies["SessionUsuario"] != null)
                {
                    Usuario sesion = new Usuario();
                    sesion.NombreUsuario = Request.Cookies["SessionUsuario"]["NombreUsuario"];
                    sesion.Contraseña = Request.Cookies["SessionUsuario"]["Contraseña"];
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
                myCookie.Values.Add("Contraseña", value.Contraseña.ToString());
                myCookie.Values.Add("Rol", value.RolId.ToString());

                // You can add multiple values

                DateTime CookieExpir = DateTime.Now.AddDays(1); //Cookie life

                Response.Cookies["SessionUsuario"].Expires = CookieExpir; //Maximum day of cookie's life       

            }
        }
    }
}