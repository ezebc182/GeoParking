using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReglasDeNegocio.Util
{
    public class Resultado
    {        
        public bool Ok { get; set; }
        public List<string> Mensajes { get; set; }

        public Resultado()
        {
            Ok = true;
            Mensajes = new List<string>();
        }

        public void AgregarMensaje(string message)
        {
            Ok = false;
            Mensajes.Add(message);
        }

        public void AgregarListaDeMensajes(List<string> messages)
        {
            if (messages.Count <= 0) return;
            Ok = false;
            Mensajes.AddRange(messages);
        }

        public String MensajesString()
        {
            return string.Join("<br/>", Mensajes);
        }
    }
}
