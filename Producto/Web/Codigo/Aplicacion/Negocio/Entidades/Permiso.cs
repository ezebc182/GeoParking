using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Permiso : EntidadBase
    {
        public String Nombre { get; set; }
        public String Url { get; set; }
        public bool Acceso { get; set; }
        public virtual IList<Rol> Roles { get; set; }

        public Permiso ToObjectRepresentation(string permisoJSON)
        {
            JsonReader jr = new JsonTextReader(new StringReader(permisoJSON));

            return JsonConvert.DeserializeObject<Permiso>(permisoJSON);
        }
    }
}
