using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class PlayaDeEstacionamiento : EntidadBase   
    {
        public PlayaDeEstacionamiento()
        {
            FechaAlta = DateTime.Now;
        }

        public string Nombre { get; set; }
        
        public int TipoPlayaId { get; set; }
        public string TipoPlaya { get; set; }

        public string Direccion { get; set; }
        public double Latitud { get; set; }
        public double Longitud { get; set; }

        public int Capacidad { get; set; }

        public String HoraDesde { get; set; }
        public String HoraHasta { get; set; }

        public bool Motos { get; set; }
        public double PrecioMotos { get; set; }
        public bool Bicicletas { get; set; }
        public double PrecioBicicletas { get; set; }
        public bool Utilitarios { get; set; }
        public double PrecioUtilitarios { get; set; }
        
    }
}
