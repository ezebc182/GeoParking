using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class EntidadBase
    {
        public int Id { get; set; }
        public DateTime FechaAlta { get; set; }
        public DateTime FechaBaja { get; set; }
    }
}
