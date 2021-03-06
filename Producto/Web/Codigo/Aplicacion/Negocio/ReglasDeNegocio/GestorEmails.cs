﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ReglasDeNegocio
{
    public class GestorEmails
    {
        public bool EnviarEmail(string contenidoMensaje, string destinatario, string asunto)
        {
            try
            {
                System.Net.Mail.MailMessage message = new System.Net.Mail.MailMessage();
                message.To.Add(destinatario);
                message.Subject = asunto;
                message.From = new System.Net.Mail.MailAddress("info.geoparking@gmail.com");
                message.Body = contenidoMensaje;
                System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient("smtp.gmail.com", 587);
                NetworkCredential basicCredential = new NetworkCredential("info.geoparking", "geoparking5");
                smtp.Credentials = basicCredential;
                smtp.EnableSsl = true;
                smtp.Send(message);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
