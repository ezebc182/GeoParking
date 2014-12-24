using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;
using System.IO;

namespace Entidades
{
    public class Precio : EntidadBase
    {
        //referencia a servicio
        public int ServicioId { get; set; }
        public virtual Servicio Servicio { get; set; }

        //referecia a un tiempo
        public int TiempoId { get; set; }
        public virtual Tiempo Tiempo { get; set; }

        //precio
        [Column(TypeName="Money")]
        public decimal Monto { get; set; }

        [NotMapped]
        public string TiempoStr { get { return Tiempo != null ? Tiempo.Nombre : ""; } }

        public String GetPreciosToJSONRepresentation()
        {
            StringBuilder sb = new StringBuilder();
            JsonWriter jw = new JsonTextWriter(new StringWriter(sb));

            jw.WriteStartObject();

            jw.Formatting = Formatting.Indented;
            jw.WritePropertyName("IdPlaya");
            jw.WriteValue(this.Servicio.PlayaDeEstacionamientoId);
            jw.WritePropertyName("Monto");
            jw.WriteValue(this.Monto);
            jw.WritePropertyName("Tiempo");
            jw.WriteValue(this.TiempoStr);

            jw.WriteEndObject();

            return sb.ToString();
        }
    }
}
