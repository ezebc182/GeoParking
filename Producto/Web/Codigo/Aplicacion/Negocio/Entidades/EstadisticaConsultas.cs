using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Entidades
{
    public class EstadisticaConsultas: EntidadBase
    {
        public DateTime Hora { get; set; }
        public int Ciudad { get; set; }
        public int IdPlaya { get; set; }
        public int IdTipoPlaya { get; set; }
        public int IdTipoVehiculo { get; set; }
        public string latitud { get; set; }
        public string longitud { get; set; }
    }
}
