using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Departamento : EntidadBase
    {
        public string Nombre { get; set; }
        public int ProvinciaId { get; set; }
        public virtual Provincia Provincia { get; set; }
        public virtual IList<Ciudad> Ciudades{get;set;}
    }
}
