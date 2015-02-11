using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Usuario : EntidadBase
    {
        public String NombreUsuario { get; set; }
        public String Contraseña { get; set; }
        public String Apellido { get; set; }
        public String Mail { get; set; }
        public String Nombre { get; set; }
        public int RolId { get; set; }
        public virtual Rol Rol { get; set; }
        public int DNI { get; set; }
        public DateTime FechaDeNacimiento { get; set; }
        public String Direccion { get; set; }

        /// <summary>
        /// Convierte a un objeto "PlayaDeEstacionamiento" el JSON pasado como parametro
        /// </summary>
        /// <param name="playaJSON"></param>
        /// <returns>PlayaDeEstacionamiento</returns>
        public Usuario ToObjectRepresentation(string usuarioJSON)
        {
            return JsonConvert.DeserializeObject<Usuario>(usuarioJSON);
        }

        /// <summary>
        /// retorna el objeto en formato JSON
        /// </summary>
        /// <returns>ObjetoJSON</returns>
        public String ToJSONRepresentation()
        {
            StringBuilder sb = new StringBuilder();
            JsonWriter jw = new JsonTextWriter(new StringWriter(sb));

            jw.Formatting = Formatting.Indented;
            jw.WriteStartObject();
            jw.WritePropertyName("Id");
            jw.WriteValue(this.Id);
            jw.WritePropertyName("Nombre");
            jw.WriteValue(this.Nombre);
            jw.WritePropertyName("Mail");
            jw.WriteValue(this.Mail);
            jw.WritePropertyName("NombreUsuario");
            jw.WriteValue(this.NombreUsuario);
            jw.WritePropertyName("Apellido");
            jw.WriteValue(this.Apellido);
            jw.WritePropertyName("RolId");
            jw.WriteValue(this.RolId);
            jw.WritePropertyName("Pass");
            jw.WriteValue(this.Contraseña);


            //ROL
            jw.WritePropertyName("Rol");
            jw.WriteStartArray();

            jw.WriteStartObject();
            jw.WritePropertyName("Nombre");
            jw.WriteValue(this.Rol.Nombre);
            jw.WriteEndObject();
            jw.WriteEndArray();

            jw.WritePropertyName("Permisos");
            jw.WriteStartArray();
            foreach (var permiso in this.Rol.Permisos)
            {
                jw.WriteStartObject();
                jw.WritePropertyName("IdPermiso");
                jw.WriteValue(permiso.Id);
                jw.WritePropertyName("Nombre");
                jw.WriteValue(permiso.Nombre);
                jw.WriteEndObject();
            }

            jw.WriteEndArray();

            return sb.ToString();
        }
    }
}
