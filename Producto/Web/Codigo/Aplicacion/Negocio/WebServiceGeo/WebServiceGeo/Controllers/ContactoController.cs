using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using ReglasDeNegocio;
using Entidades;

namespace WebServiceGeo.Controllers
{
    public class Contacto
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public string Mensaje { get; set; }
        
    }
    public class ContactoController : ApiController
    {
        GestorEmails emails = new GestorEmails();
        [System.Web.Mvc.HttpPost]
        public void PostEnviarEmailDeContacto([FromBody] Contacto mensaje)
        {
            var headers = Request.Headers;
            System.Web.HttpContext.Current.Response.Clear();
            try
            {
                //IEnumerable<string> headerPasswordValues = Request.Headers.GetValues("x-password");
                string token = Request.Headers.GetValues("x-token").FirstOrDefault();
                if (token.CompareTo("eqwadasdasd") != 0)//aca es donde se validaria el token con el almacenado en el servidor
                {
                    throw new HttpRequestException("No posee acceso al sistema");
                }
                string contenidoMensaje = "Nombre: " + mensaje.Nombre;
                contenidoMensaje += "\nApellido: " + mensaje.Apellido;
                contenidoMensaje += "\nTelefono: " + mensaje.Telefono;
                contenidoMensaje += "\nEmail: " + mensaje.Email;
                contenidoMensaje += "\nCosulta:\n" + mensaje.Mensaje;
                emails.EnviarEmail(contenidoMensaje).ToString();
            }
            catch (HttpRequestException)
            {
                System.Web.HttpContext.Current.Response.StatusCode = 403;
                //throw new Exception("No posee acceso al sistema");
            }
            catch (Exception)
            {
                System.Web.HttpContext.Current.Response.StatusCode = 400;
            }
        }

    }
}
