using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Rol : EntidadBase
    {
        public String Nombre { get; set; }
        public String Descripcion { get; set; }
        public virtual IList<Permiso> Permisos { get; set; }
    }
}
