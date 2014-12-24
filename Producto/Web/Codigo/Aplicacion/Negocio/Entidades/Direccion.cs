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
    public class Direccion : EntidadBase
    {
        //Calle
        public string Calle { get; set; }
        //Numero
        public int Numero { get; set; }
        //Ciudad
        public string Ciudad { get; set; }
        //Playa
        public int? PlayaDeEstacionamientoId { get; set; }
        public virtual PlayaDeEstacionamiento PlayaDeEstacionamiento { get; set; }

        //Coordenadas Geograficas
        public string Latitud { get; set; }
        public string Longitud { get; set; }
       
        public String GetUbicacionesToJSONRepresentation()
        {
            StringBuilder sb = new StringBuilder();
            JsonWriter jw = new JsonTextWriter(new StringWriter(sb));
                
            jw.WriteStartObject();
                
            jw.Formatting = Formatting.Indented;
            jw.WritePropertyName("Id");
            jw.WriteValue(this.PlayaDeEstacionamientoId);
            jw.WritePropertyName("Latitud");
            jw.WriteValue(this.Latitud);
            jw.WritePropertyName("Longitud");
            jw.WriteValue(this.Longitud);
                
            jw.WriteEndObject();

            return sb.ToString();
        }
    }
}
