using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;


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
        public virtual DiaAtencion DiaAtencion 
        {
            get { return diaAtencion; }
            set
            {
                diaAtencion = value;
                DiaAtencionStr = value.Nombre;
            }
        }

        [NotMapped]
        private DiaAtencion diaAtencion;
        [NotMapped]
        public String DiaAtencionStr{get;set;}
    }
}
