using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Tiempo : EntidadBase
    {
        //1h, 12hs, 24hs, semana, mes
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        
    }
}
