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
        public string TipoVehiculoStr { get { return TipoVehiculo != null ? TipoVehiculo.Nombre : ""; } }
        [NotMapped]
        public string DiaAtencionStr { get { return DiaAtencion != null ? DiaAtencion.Nombre : ""; } }
        [NotMapped]
        public string TiempoStr { get { return Tiempo != null ? Tiempo.Nombre : ""; } }

    }
}
