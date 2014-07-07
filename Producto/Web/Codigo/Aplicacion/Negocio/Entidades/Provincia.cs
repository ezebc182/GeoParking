using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Provincia : EntidadBase
    {
        public string Nombre { get; set; }
        
        public virtual IList<Departamento> Departamentos{get;set;}
    }
}
