using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Data.Entity.Spatial;
using System.ComponentModel.DataAnnotations.Schema;
using Entidades.util;

namespace Entidades
{
    public class EstadisticaConsultas: EntidadBase
    {
        public DateTime Hora { get; set; }
        public int Ciudad { get; set; }
        public int IdPlaya { get; set; }
        public int IdTipoPlaya { get; set; }
        public int IdTipoVehiculo { get; set; }
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


        public string ToJSONRepresentation()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
