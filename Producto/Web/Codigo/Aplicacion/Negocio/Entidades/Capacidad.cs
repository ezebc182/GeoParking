using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Entidades
{
    public class Capacidad : EntidadBase
    {
        public int Cantidad { get; set; }

        //servicio
        public int ServicioId { get; set; }
        [JsonIgnore]
        public virtual Servicio Servicio { get; set; }
    }
}
