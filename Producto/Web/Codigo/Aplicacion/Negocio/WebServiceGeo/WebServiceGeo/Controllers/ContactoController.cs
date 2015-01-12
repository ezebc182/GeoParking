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
            string contenidoMensaje = "Nombre: " + mensaje.Nombre;
            contenidoMensaje += "\nApellido: " + mensaje.Apellido;
            contenidoMensaje += "\nTelefono: " + mensaje.Telefono;
            contenidoMensaje += "\nEmail: " + mensaje.Email;
            contenidoMensaje += "\nCosulta:\n" + mensaje.Mensaje;
            emails.EnviarEmail(contenidoMensaje).ToString();
        }

    }
}
