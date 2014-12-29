using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace Entidades
{
    public class Horario : EntidadBase
    {
        //Hora de apertura
        public string HoraDesde { get; set; }
        //Hora de cierre
        public String HoraHasta { get; set; }

        //Referencia a Dia de Atencion
        public int DiaAtencionId { get; set; }
        public virtual DiaAtencion DiaAtencion { get; set; }
        
        //Playa
        //[Key, ForeignKey("PlayaDeEstacionamiento")]
        public int PlayaDeEstacionamientoId { get; set; }
        [JsonIgnore]
        public virtual PlayaDeEstacionamiento PlayaDeEstacionamiento { get; set; }

        public String DiaAtencionStr { get { return DiaAtencion != null ? DiaAtencion.Nombre : ""; } }
    }
}
