using ReglasDeNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web2
{
    public partial class web : System.Web.UI.Page
    {
        static GestorBusquedaPlayas gestor;
        private static GestorUsuario gestorUsuario;
        //public SiteMaster master;  --para cuando se haga la master-- 

        protected void Page_Load(object sender, EventArgs e)
        {
            gestorUsuario = new GestorUsuario();
            //primer carga de la pagina
            if (!IsPostBack)
            {
                //NO SE -- EXPLICAR
                var queryString = Request.QueryString["r"] as string;
                if (queryString != null) { }
                //master.MostrarMensajeError(Util.TipoMensajeEnum.MensajeModal, "No tiene permiso para acceder a " + queryString, "Acceso denegado.");
            }

            //focus en la busqueda de ciudad                
            txtBuscar.Focus();

            //instancia del gestor de busqueda
            gestor = new GestorBusquedaPlayas();
        }

        

        /// <summary>
        /// Obtiene la ciudad para filtrar la busqueda y la guarda en la session
        /// </summary>
        protected void btnBuscar_Click(object sender, EventArgs e)
        {

            if (txtBuscar.Text != "")
            {
                //Objeto session con la ciudad
                Session["idCiudadPlace"] = txtIdPlace.Text;
                Session["ciudad"] = txtBuscar.Text;

                //redirijo a la pagina que mostrara los resultados
                Response.Redirect("BusquedaPlaya.aspx");
            }
        }

        [WebMethod]
        public static bool ValidarLogin(string nombre, string contraseña)
        {
            var resultado = gestorUsuario.Login(nombre, contraseña);
            if (resultado == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}