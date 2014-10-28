using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Entidades
{
    public class EstadisticaConsultas: EntidadBase
    {
        public DateTime Hora { get; set; }
        public int Ciudad { get; set; }
        public int IdPlaya { get; set; }
        public int IdTipoPlaya { get; set; }
        public int IdTipoVehiculo { get; set; }
        public string Latitud { get; set; }
        public string Longitud { get; set; }

        public string ToJSONRepresentation()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
