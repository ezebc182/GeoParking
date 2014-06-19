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
        public List<string> Messages { get; set; }

        public Resultado()
        {
            Messages = new List<string>();
        }

        public void AddErrorMessage(string message)
        {
            Ok = false;
            Messages.Add(message);
        }

        public void AddErrorMessageList(List<string> messages)
        {
            if (messages.Count <= 0) return;
            Ok = false;
            Messages.AddRange(messages);
        }

        public String MessagesAsString()
        {
            return string.Join("<br/>", Messages);
        }
    }
}
