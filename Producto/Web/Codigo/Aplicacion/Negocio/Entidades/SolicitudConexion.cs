using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace Entidades
{
    public class SolicitudConexion : EntidadBase
    {
        public int EstadoId { get; set; }
        public virtual Estado Estado { get; set; }
        public string NombrePlaya { get; set; }
        public string  UsuarioResponsable { get; set; }
        public virtual Usuario Responsable { get; set; }
    }
}
