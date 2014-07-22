using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Permiso : EntidadBase
    {
        public String Nombre { get; set; }
        public String Url { get; set; }
        public bool Acceso { get; set; }
    }
}
