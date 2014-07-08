using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
namespace Entidades
{
    public class PlayaDeEstacionamiento : EntidadBase   
    {
        //Nombre
        public string Nombre { get; set; }      
        
        //Referencia a Tipo de Playa
        public int TipoPlayaId { get; set; }
        public virtual TipoPlaya TipoPlaya { get; set; }               

        //Direcciones (calle, numero,ciudad y coordenadas)
        public virtual IList<Direccion> Direcciones { get; set; }
        
        //Servicios (tipo de vehculo y capacidad)
        public virtual IList<Servicio> Servicios { get; set; }
        
        //Horarios (dia, horaDesde, HoraHasta)
        public virtual IList<Horario> Horarios { get; set; }
        
        //Precios (Vehiculo, dia, tiempo, precio)
        public virtual IList<Precio> Precios { get; set; }       
       
        //datos extras
        [NotMapped]
        public virtual string TipoPlayaNombre { get; set; }
        [NotMapped]
        public virtual string Extras { get; set; }
        
    }
}
