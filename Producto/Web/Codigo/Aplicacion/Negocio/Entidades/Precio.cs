using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    class Precio : EntidadBase
    {

        //referencia a un TipoVehiculo
        public int TipoVehiculoId { get; set; }
        public virtual TipoVehiculo TipoVehiculo { get; set; }

        //referencia a un dia de atencion
        public int DiaAtencioId { get; set; }
        public virtual DiaAtencion DiaAtencion { get; set; }

        //referecia a un tiempo
        public int TiempoId { get; set; }
        public virtual Tiempo Tiempo { get; set; }

        //precio
        public double Precio { get; set; }
    }
}
