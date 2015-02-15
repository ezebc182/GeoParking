using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace Entidades
{
    public class Conexion : EntidadBase
    {
        public bool EstadoConfirmacion { get; set; }
        public int PlayaDeEstacionamientoId { get; set; }
        public virtual PlayaDeEstacionamiento PlayaDeEstacionamiento { get; set; }
        public string UsuarioResponsable { get; set; }
        public virtual Usuario Responsable { get; set; }
    }
}
