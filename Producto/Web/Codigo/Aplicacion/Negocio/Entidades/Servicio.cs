using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entidades
{
    public class Servicio : EntidadBase
    {
        //referencia a tabla TipoVehiculo
        public int TipoVehiculoId { get; set; }
        //Playa
        public int? PlayaDeEstacionamientoId { get; set; }
        public virtual PlayaDeEstacionamiento PlayaDeEstacionamiento { get; set; }

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

        //capacidad de lugares para el tipo de vehiculo
        public int Capacidad { get; set; }

        [NotMapped]
        public string TipoVehiculoStr { get; set; }

    }
}
