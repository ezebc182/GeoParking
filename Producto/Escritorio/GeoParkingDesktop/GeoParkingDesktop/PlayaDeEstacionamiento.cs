using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoParkingDesktop
{
    class PlayaDeEstacionamiento
    {
        public int id { get; set; }
        public List<VehiculoEstacionado> vehiculos { get; set; }
        public List<Precio> preciosXhora { get; set; }
        public List<Disponibilidades> disponibilidades { get; set; }

        public PlayaDeEstacionamiento()
        {
            vehiculos = new List<VehiculoEstacionado>();
            preciosXhora = new List<Precio>();
            disponibilidades = new List<Disponibilidades>();
        }
    }
}
