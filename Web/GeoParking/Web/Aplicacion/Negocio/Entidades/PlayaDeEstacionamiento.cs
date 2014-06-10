using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class PlayaDeEstacionamiento
    {
        public int id { get; set; }

        public string nombre { get; set; }
        public string direccion { get; set; }
        public int tipoPlaya { get; set; }

        public double latitud { get; set; }
        public double longitud { get; set; }

        public int capacidad { get; set; }

        public DateTime horaDesde { get; set; }
        public DateTime horaHasta { get; set; }

        public bool motos { get; set; }
        public bool bicicletas { get; set; }
        public bool utilitarios { get; set; }
        
    }
}
