using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Entidades.util;
namespace Entidades.util
{
    public class DbGeographyConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType.IsAssignableFrom(typeof(string));
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JObject location = JObject.Load(reader);
            JToken token = location["Geography"]["WellKnownText"];
            string tokenString = token.ToString();

            System.Data.Entity.Spatial.DbGeography converted = DbGeographyHelper.CreatePolygon(tokenString);
            return converted;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            // Base serialization is fine
            serializer.Serialize(writer, value);
        }
    }
}
