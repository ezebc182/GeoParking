using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;
using System.IO;
namespace Entidades
{
    public class PlayaDeEstacionamiento : EntidadBase
    {
        //Nombre
        public string Nombre { get; set; }
        //Mail
        public string Mail { get; set; }
        //Telefono
        public string Telefono { get; set; }

        //Referencia a Tipo de Playa
        public int? TipoPlayaId { get; set; }
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
        public virtual string TipoPlayaStr { get { return TipoPlaya != null ? TipoPlaya.Nombre : ""; } }
        [NotMapped]
        public virtual string Extras
        {
            get
            {
                string extras = "";
                if (Servicios.Count > 0)
                {
                    foreach (var item in Servicios)
                    {
                        extras += item.TipoVehiculoStr + " - ";
                    }
                    extras = extras.Remove(extras.Length - 2);
                }
                return extras;
            }
        }
        #region Direccion

        [NotMapped]
        public string Calle { get { return Direcciones.Count > 0 ? Direcciones[0].Calle : ""; } }
        [NotMapped]
        public int Numero { get { return Direcciones.Count > 0 ? Direcciones[0].Numero : 0; } }
        [NotMapped]
        public string Ciudad { get { return Direcciones.Count > 0 ? Direcciones[0].CiudadStr : ""; } }
        [NotMapped]
        public string Provincia { get { return Direcciones.Count > 0 ? Direcciones[0].Ciudad.Departamento.Provincia.Nombre : ""; } }

        #endregion

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
            jw.WritePropertyName("Telefono");
            jw.WriteValue(this.Telefono);
            jw.WritePropertyName("TipoPlaya");
            jw.WriteValue(this.TipoPlayaStr);
            jw.WritePropertyName("Latitud");
            jw.WriteValue(this.Direcciones[0].Latitud);
            jw.WritePropertyName("Longitud");
            jw.WriteValue(this.Direcciones[0].Longitud);

            //DIRECCIONES
            jw.WritePropertyName("Direcciones");
            jw.WriteStartArray();

            int i;
            i = 0;

            for (i = 0; i < this.Direcciones.Count; i++)
            {
                jw.WriteStartObject();
                jw.WritePropertyName("Calle");
                jw.WriteValue(Direcciones[i].Calle);
                jw.WritePropertyName("Numero");
                jw.WriteValue(Direcciones[i].Numero);
                jw.WriteEndObject();
            }

            jw.WriteEndArray();

            //SERVICIOS
            jw.WritePropertyName("Servicios");
            jw.WriteStartArray();

            int j;
            j = 0;

            for (j = 0; j < this.Servicios.Count; j++)
            {
                jw.WriteStartObject();                
                jw.WritePropertyName("TipoVehiculo");
                jw.WriteValue(Servicios[j].TipoVehiculoStr);
                jw.WritePropertyName("Capacidad");
                jw.WriteValue(Servicios[j].Capacidad);
                jw.WriteEndObject();
            }

            jw.WriteEndArray();

            //HORARIOS
            jw.WritePropertyName("Horarios");
            jw.WriteStartArray();

            int k;
            k = 0;

            for (k = 0; k < this.Horarios.Count; k++)
            {
                jw.WriteStartObject();                
                jw.WritePropertyName("Dia");
                jw.WriteValue(Horarios[k].DiaAtencionStr);
                jw.WritePropertyName("HoraDesde");
                jw.WriteValue(Horarios[k].HoraDesde);
                jw.WritePropertyName("HoraHasta");
                jw.WriteValue(Horarios[k].HoraHasta);
                jw.WriteEndObject();
            }

            jw.WriteEndArray();            

            //PRECIOS
            jw.WritePropertyName("Precios");
            jw.WriteStartArray();

            int l;
            l = 0;

            for (l = 0; l < this.Precios.Count; l++)
            {
                jw.WriteStartObject();               
                jw.WritePropertyName("TipoVehiculo");
                jw.WriteValue(Precios[l].TipoVehiculoStr);
                jw.WritePropertyName("Dia");
                jw.WriteValue(Precios[l].DiaAtencionStr);
                jw.WritePropertyName("Tiempo");
                jw.WriteValue(Precios[l].TiempoStr);
                jw.WritePropertyName("Monto");
                jw.WriteValue(Precios[l].Monto);
                jw.WriteEndObject();
            }

            jw.WriteEndArray(); 

            jw.WriteEndObject();

            return sb.ToString();
        }
    }
}
    

