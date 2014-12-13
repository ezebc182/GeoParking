using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class DisponibilidadPlayas : EntidadBase
    {
        public int PlayaDeEstacionamientoId { get; set; }
        public int TipoVehiculoId { get; set; }
        public int Disponibilidad { get; set; }

        //public virtual PlayaDeEstacionamiento PlayaDeEstacioamiento { get; set; }
        //public virtual TipoVehiculo TipoVehiculo { get; set; }

        public string ToJSONRepresentation()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
