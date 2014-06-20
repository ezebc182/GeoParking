using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class EntidadBase
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public EntidadBase()
        {
            FechaAlta = DateTime.Now;
        }

        //id de las entidades
        public int Id { get; set; }
        //fecha de alta para su creacion
        public DateTime FechaAlta { get; set; }
        //fecha de baja cuando se elimine la entidad
        public DateTime? FechaBaja{ get; set; }
        
    }
}
