using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace Entidades
{
    public class Estado : EntidadBase
    {
        public string Nombre { get; set; }
        public string Descripcion{ get; set; }
    }
}
