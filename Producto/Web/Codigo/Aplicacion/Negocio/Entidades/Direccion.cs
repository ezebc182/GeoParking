using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;
using System.Data.Entity.Spatial;

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
        [JsonIgnore]
        public virtual PlayaDeEstacionamiento PlayaDeEstacionamiento { get; set; }

        //Coordenadas Geograficas
        [JsonConverter(typeof(DbGeographyConverter))]
        public DbGeography Posicion { get; set; }
        [NotMapped]
        public string Latitud
        {
            get { return Posicion.Latitude.HasValue ? Posicion.Latitude.Value.ToString() : ""; }
        }
        [NotMapped]
        public string Longitud
        {
            get { return Posicion.Longitude.HasValue ? Posicion.Longitude.Value.ToString() : ""; }
        }

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
            jw.WritePropertyName("Calle");
            jw.WriteValue(this.Calle);
            jw.WritePropertyName("Numero");
            jw.WriteValue(this.Numero);


            jw.WriteEndObject();

            return sb.ToString();
        }
    }
    public class DbGeographyConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType.IsAssignableFrom(typeof(string));
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JObject location = JObject.Load(reader);
            JToken tokenLongitud = location["Longitude"];
            JToken tokenLatitud = location["Latitude"];
            string longitud = tokenLongitud.ToString();
            string latitud = tokenLatitud.ToString();

            System.Data.Entity.Spatial.DbGeography converted = System.Data.Entity.Spatial.DbGeography.FromText(string.Format("POINT({0} {1})",longitud,latitud));
            return converted;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            // Base serialization is fine
            serializer.Serialize(writer, value);
        }
    }
}
