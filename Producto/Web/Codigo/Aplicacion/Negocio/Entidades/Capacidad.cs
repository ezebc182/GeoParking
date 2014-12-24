using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Capacidad : EntidadBase
    {
        public int Cantidad { get; set; }

        //servicio
        public int ServicioId { get; set; }
        public virtual Servicio Servicio { get; set; }
    }
}
