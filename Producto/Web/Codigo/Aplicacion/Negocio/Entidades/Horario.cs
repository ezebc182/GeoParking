using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Horario : EntidadBase
    {
        //Hora de apertura
        public string HoraDesde { get; set; }
        //Hora de cierre
        public String HoraHasta { get; set; }

        //Referencia a Dia de Atencion
        public int DiaAtencioId { get; set; }
        public virtual DiaAtencion DiaAtencion { get; set; }

    }
}
