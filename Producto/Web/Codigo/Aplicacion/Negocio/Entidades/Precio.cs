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

        //referencia a un TipoVehiculo
        public int TipoVehiculoId { get; set; }
        public virtual TipoVehiculo TipoVehiculo { get; set; }
        //Playa
        public int? PlayaDeEstacionamientoId { get; set; }
        public virtual PlayaDeEstacionamiento PlayaDeEstacionamiento { get; set; }
        

        //referecia a un tiempo
        public int TiempoId { get; set; }
        public virtual Tiempo Tiempo { get; set; }

        //precio
        [Column(TypeName="Money")]
        public decimal Monto { get; set; }

        [NotMapped]
        public string TipoVehiculoStr { get { return TipoVehiculo != null ? TipoVehiculo.Nombre : ""; } }
       
        [NotMapped]
        public string TiempoStr { get { return Tiempo != null ? Tiempo.Nombre : ""; } }

        public String GetPreciosToJSONRepresentation()
        {
            StringBuilder sb = new StringBuilder();
            JsonWriter jw = new JsonTextWriter(new StringWriter(sb));

            jw.WriteStartObject();

            jw.Formatting = Formatting.Indented;
            jw.WritePropertyName("IdPlaya");
            jw.WriteValue(this.PlayaDeEstacionamientoId);
            jw.WritePropertyName("Monto");
            jw.WriteValue(this.Monto);
            jw.WritePropertyName("Tiempo");
            jw.WriteValue(this.TiempoStr);

            jw.WriteEndObject();

            return sb.ToString();
        }
    }
}
