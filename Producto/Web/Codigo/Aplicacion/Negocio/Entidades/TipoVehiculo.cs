using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    public class TipoVehiculo : EntidadBase
    {
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public String ToJSONRepresentation()
        {
            StringBuilder sb = new StringBuilder();
            JsonWriter jw = new JsonTextWriter(new StringWriter(sb));
            jw.Formatting = Formatting.Indented;
            jw.WriteStartObject();
            jw.WritePropertyName("Id");
            jw.WriteValue(this.Id);
            jw.WritePropertyName("Nombre");
            jw.WriteValue(this.Nombre);
            jw.WriteEndObject();

            return sb.ToString();
        }
    }
}
