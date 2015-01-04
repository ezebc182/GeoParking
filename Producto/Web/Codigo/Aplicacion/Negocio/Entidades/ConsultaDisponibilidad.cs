using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class ConsultaDisponibilidad
    {
        public int PlayaId { get; set; }
        public int TipoVehiculoId { get; set; }
        public int Disponibilidad { get; set; }

        public string toJSONRepresentation()
        {
            StringBuilder sb = new StringBuilder();
            JsonWriter jw = new JsonTextWriter(new StringWriter(sb));

            jw.WriteStartObject();

            jw.Formatting = Formatting.Indented;
            jw.WritePropertyName("PlayaId");
            jw.WriteValue(this.PlayaId);
            jw.WritePropertyName("TipoVehiculoId");
            jw.WriteValue(this.TipoVehiculoId);
            jw.WritePropertyName("Disponibilidad");
            jw.WriteValue(this.Disponibilidad);

            jw.WriteEndObject();

            return sb.ToString();
        }
    }
}
