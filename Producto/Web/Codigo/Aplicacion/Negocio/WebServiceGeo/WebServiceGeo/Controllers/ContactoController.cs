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
using WebServiceGeo.Models;

namespace WebServiceGeo.Controllers
{
    
    public class ContactoController : ApiController
    {
        GestorEmails emails = new GestorEmails();
        [System.Web.Mvc.HttpPost]
        public void PostEnviarEmailDeContacto([FromBody] Contacto mensaje)
        {
            string contenidoMensaje = "Nombre: " + mensaje.Nombre;           
            contenidoMensaje += "\nEmail: " + mensaje.Email;
            contenidoMensaje += "\nCosulta:\n" + mensaje.Mensaje;
            string asunto = mensaje.Asunto;
            emails.EnviarEmail(contenidoMensaje, "info.geoparking@gmail.com", asunto).ToString();
        }

    }
}
