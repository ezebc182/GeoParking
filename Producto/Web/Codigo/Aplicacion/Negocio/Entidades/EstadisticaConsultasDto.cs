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
    public class EstadisticaConsultasDto
    {
        public int Ano { get; set; }
        public int Mes { get; set; }
        public int Cantidad { get; set; }
        public int PlayaId { get; set; }
        public string PlayaNombre { get; set; }
        public int ZonaId { get; set; }
        public string ZonaNombre { get; set; }
        public int TipoPlayaId { get; set; }
        public string TipoPlayaNombre { get; set; }
        public int TipoVehiculoId { get; set; }
        public string TipoVehiculoNombre { get; set; }
        //posicion de la playa o centro de la zona
        [JsonConverter(typeof(DbGeographyConverter))]
        public DbGeography Posicion { get; set; }
    }
}
