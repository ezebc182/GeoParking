using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Ciudad : EntidadBase
    {
        public string Nombre { get; set; }
        public int DepartamentoId { get; set; }
        public virtual Departamento Departamento { get; set; }
    }
}
