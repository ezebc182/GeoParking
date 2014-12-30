using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace Entidades
{
    public class Servicio : EntidadBase
    {
        //referencia a tabla TipoVehiculo
        public int TipoVehiculoId { get; set; }
        //Playa
        public int? PlayaDeEstacionamientoId { get; set; }
        [JsonIgnore]
        public virtual PlayaDeEstacionamiento PlayaDeEstacionamiento { get; set; }
        
        //Disponibilidad Playa
        public int? DisponibilidadPlayasId { get; set; }
        public virtual DisponibilidadPlayas DisponibilidadPlayas { get; set; }

        [NotMapped]
        private TipoVehiculo tipoVehiculo;
        public virtual TipoVehiculo TipoVehiculo
        {
            get { return tipoVehiculo; }
            set
            {
                tipoVehiculo = value;
                TipoVehiculoStr = value != null ? value.Nombre : "";
                TipoVehiculoId = value != null ? value.Id : 0;
            }
        }

        //Precios (Vehiculo, dia, tiempo, precio)
        public virtual IList<Precio> Precios { get; set; }

        //capacidad
        public virtual Capacidad Capacidad { get; set; }
        [NotMapped]
        public string TipoVehiculoStr { get; set; }

    }
}
