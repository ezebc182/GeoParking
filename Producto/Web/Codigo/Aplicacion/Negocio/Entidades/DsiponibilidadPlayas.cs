using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class DisponibilidadPlayas : EntidadBase
    {
        public int Disponibilidad { get; set; }

        //Servicio
        public int? ServicioId { get; set; }
        [JsonIgnore]
        public virtual Servicio Servicio { get; set; }

        public string ToJSONRepresentation()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
