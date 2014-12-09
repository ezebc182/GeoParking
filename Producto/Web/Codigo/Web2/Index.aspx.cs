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
    public partial class Index : System.Web.UI.Page
    {
        static GestorBusquedaPlayas gestor;
        //public SiteMaster master;  --para cuando se haga la master-- 

        protected void Page_Load(object sender, EventArgs e)
        {
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
        /// Retorna una lista de string con las posibles ciudades de acuerdo
        /// a lo que el ususario va ingresando(prefijo)
        /// </summary>
        /// <param name="pre">prefijo o principio del nombre de la ciudad</param>
        /// <returns>Lista de string con nombre de ciudades que comienzan con "pre"</returns>
        [WebMethod]
        public static string GetNombreCiudades(string pre)
        {
            //lista de normbres de payas
            List<string> nombrePlayas = new List<string>();

            //realizar la consulta y setear la lista
            nombrePlayas = gestor.GetNombreCiudades(pre);

            //Pasamos la colección a formato JSON. Se guardará en jsonLista:
            StringBuilder jsonLista = new StringBuilder();
            JavaScriptSerializer js = new JavaScriptSerializer();
            js.Serialize(nombrePlayas, jsonLista);

            //retorna la lista
            return jsonLista.ToString();

        }

        /// <summary>
        /// Obtiene la ciudad para filtrar la busqueda y la guarda en la session
        /// </summary>
        protected void btnBuscar_Click(object sender, EventArgs e)
        {

            if (txtBuscar.Text != "")
            {
                //Objeto session con la ciudad
                string[] direccionCiudad =txtBuscar.Text.Split(',');

                string ciudad = direccionCiudad[0];
                string textoNormalizado = ciudad.Normalize(NormalizationForm.FormD);
                Regex reg = new Regex("[^a-zA-Z0-9 ]");
                string ciudadSinAcentos = reg.Replace(textoNormalizado, "");
                Session["ciudad"] = ciudadSinAcentos;

                //redirijo a la pagina que mostrara los resultados
                Response.Redirect("BusquedaPlaya.aspx");
            }
        }
    }
}