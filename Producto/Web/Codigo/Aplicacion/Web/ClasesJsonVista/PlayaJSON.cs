using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.ClasesJsonVista
{
    public class PlayaJSON
    {
        public int id { get; set; }
        //Nombre
        public string Nombre { get; set; }
        //Mail
        public string Mail { get; set; }
        //Telefono
        public string Telefono { get; set; }
        //tipo playa
        public string TipoPlaya { get; set; }

        //x e y
        public string Latitud { get; set; }
        public string Longitud { get; set; }

        //Direcciones (calle, numero,ciudad y coordenadas)
        public List<DireccionJSON> Direcciones { get; set; }

        //Servicios (tipo de vehculo y capacidad)
        public List<ServicioJSON> Servicios { get; set; }

        //Horarios (dia, horaDesde, HoraHasta)
        public List<HorarioJSON> Horarios { get; set; }

        //Precios (Vehiculo, dia, tiempo, precio)
        public List<PrecioJSON> Precios { get; set; }       
    }
}