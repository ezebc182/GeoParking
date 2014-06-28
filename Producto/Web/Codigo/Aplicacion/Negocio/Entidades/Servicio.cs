using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Servicio : EntidadBase
    {
        public int Capacidad { get; set; }
        public double PrecioXHora { get; set; }

        //referencia a tabla TipoVehiculo
        public int TipoVehiculoId { get; set; }
        public virtual TipoVehiculo TipoVehiculo { get; set; }
    }
}
