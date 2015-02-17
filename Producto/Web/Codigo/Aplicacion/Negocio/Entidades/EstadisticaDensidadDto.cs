using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Data.Entity.Spatial;
using Entidades.util;

namespace Entidades
{
    public class EstadisticaDensidadDto: EntidadBase
    {
        public DateTime Hora { get; set; }
        [JsonConverter(typeof(DbGeographyConverter))]
        public DbGeography Posicion { get; set; }

        public string ToJSONRepresentation()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
