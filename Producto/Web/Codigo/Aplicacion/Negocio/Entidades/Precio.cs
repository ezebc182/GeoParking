using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entidades
{
    public class Precio : EntidadBase
    {

        //referencia a un TipoVehiculo
        public int TipoVehiculoId { get; set; }
        public virtual TipoVehiculo TipoVehiculo { get; set; }

        //referencia a un dia de atencion
        public int DiaAtencionId { get; set; }
        public virtual DiaAtencion DiaAtencion { get; set; }

        //referecia a un tiempo
        public int TiempoId { get; set; }
        public virtual Tiempo Tiempo { get; set; }

        //precio
        [Column(TypeName="Money")]
        public decimal Monto { get; set; }

        [NotMapped]
        private TipoVehiculo tipoVehiculo;
        [NotMapped]
        private DiaAtencion diaAtencion;
        [NotMapped]
        private Tiempo tiempo;
        [NotMapped]
        private string TipoVehiculoStr { get; set; }
        [NotMapped]
        private string DiaAtencionStr { get; set; }
        [NotMapped]
        private string TiempoStr { get; set; }

    }
}
