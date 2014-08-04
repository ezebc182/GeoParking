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
    public partial class ABMRol : System.Web.UI.Page
    {
        GestorRol gestor = new GestorRol();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
               
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
            gestor.CrearRol(rolNuevo);
        }
    }
}