using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Spatial;
using Entidades.util;
using Newtonsoft.Json;

namespace Entidades
{
    public class EstadisticaDisponibilidadDto
    {
        //% ocupacion
        public double Ocupacion { get; set; }
        public int PlayaId { get; set; }
        public int ZonaId { get; set; }
        public int TipoPlayaId { get; set; }
        public int TipoVehiculoId { get; set; }
        //posicion de la playa
        [JsonConverter(typeof(DbGeographyConverter))]
        public DbGeography Posicion { get; set; }
    }
}
