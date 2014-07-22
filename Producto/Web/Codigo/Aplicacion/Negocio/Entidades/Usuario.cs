using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Usuario : EntidadBase
    {
        public String NombreUsuario { get; set; }
        public String Contraseña { get; set; }
        public String Apellido { get; set; }
        public String Nombre { get; set; }
        public virtual IList<Rol> Roles { get; set; }
    }
}
