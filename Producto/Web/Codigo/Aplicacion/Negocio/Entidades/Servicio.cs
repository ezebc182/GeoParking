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

        [NotMapped]
        private TipoVehiculo tipoVehiculo;
        public virtual TipoVehiculo TipoVehiculo
        {
            get { return tipoVehiculo; }
            set
            {
                tipoVehiculo = value;
                TipoVehiculoStr = value.Nombre;
                TipoVehiculoId = value.Id;
            }
        }

        //capacidad de lugares para el tipo de vehiculo
        public int Capacidad { get; set; }

        [NotMapped]
        public string TipoVehiculoStr { get; set; }
        
    }
}
