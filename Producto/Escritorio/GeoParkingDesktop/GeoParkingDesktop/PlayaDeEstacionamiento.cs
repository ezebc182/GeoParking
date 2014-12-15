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
        public string nombre { get; set; }
        public string email { get; set; }
        public int tipoPlaya { get; set; }
        public int dias { get; set; }
        public string horaDesde { get; set; }
        public string horaHata { get; set; }
        public List<VehiculoEstacionado> vehiculos { get; set; }
        public List<Precio> precios { get; set; }
        public List<Disponibilidades> disponibilidades { get; set; }

        public PlayaDeEstacionamiento()
        {
            vehiculos = new List<VehiculoEstacionado>();
            precios = new List<Precio>();
            disponibilidades = new List<Disponibilidades>();
        }
    }
}
