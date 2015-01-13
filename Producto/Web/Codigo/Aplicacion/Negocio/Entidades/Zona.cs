using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Data.Entity.Spatial;
using System.IO;
using Entidades.util;

namespace Entidades
{
    public class Zona : EntidadBase
    {
        public string Nombre { get; set; }
        [JsonConverter(typeof(DbGeographyConverter))]
        public DbGeography Poligono { get; set; }

        //usuario
        public int UsuarioId { get; set; }
        [JsonIgnore]
        public virtual Usuario Usuario{ get; set; }

        public Zona ToObjectRepresentation(string zonaJSON)
        {
            JsonReader jr = new JsonTextReader(new StringReader(zonaJSON));

            return JsonConvert.DeserializeObject<Zona>(zonaJSON);
        }
    }
}
