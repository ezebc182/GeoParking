using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class HistorialDisponibilidadPlayas : EntidadBase
    {
        public int PlayaDeEstacionamietoId { get; set; }
        public int TipoVehiculoId { get; set; }
        public int EventoId { get; set; }
        public DateTime FechaHora { get; set; }
        public int Disponibilidad { get; set; }
        
        //public virtual PlayaDeEstacionamiento PlayaDeEstacionamiento { get; set; }
        //public virtual TipoVehiculo TipoVehiculo { get; set; }
        //public virtual Evento Evento { get; set; }

        public string ToJSONRepresentation()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
