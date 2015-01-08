using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
﻿using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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
        public virtual Horario Horario { get; set; }



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
        public string Ciudad { get { return Direcciones.Count > 0 ? Direcciones[0].Ciudad : ""; } }


        #endregion


        /// <summary>
        /// Convierte a un objeto "PlayaDeEstacionamiento" el JSON pasado como parametro
        /// </summary>
        /// <param name="playaJSON"></param>
        /// <returns>PlayaDeEstacionamiento</returns>
        public PlayaDeEstacionamiento ToObjectRepresentation(string playaJSON)
        {
            JsonReader jr = new JsonTextReader(new StringReader(playaJSON));
            
            return JsonConvert.DeserializeObject<PlayaDeEstacionamiento>(playaJSON);
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
            jw.WritePropertyName("Telefono");
            jw.WriteValue(this.Telefono);
            jw.WritePropertyName("TipoPlaya");
            jw.WriteValue(this.TipoPlayaStr);
            jw.WritePropertyName("IdTipoPlaya");
            jw.WriteValue(this.TipoPlayaId);
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
                jw.WritePropertyName("Ciudad");
                jw.WriteValue(Direcciones[i].Ciudad);
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

            foreach (var servicio in Servicios)
            {
                jw.WriteStartObject();
                jw.WritePropertyName("TipoVehiculo");
                jw.WriteValue(servicio.TipoVehiculoStr);
                jw.WritePropertyName("IdTipoVehiculo");
                jw.WriteValue(servicio.TipoVehiculoId);

                //PRECIOS
                jw.WritePropertyName("Precios");
                jw.WriteStartArray();



                foreach (var precio in servicio.Precios)
                {
                    jw.WriteStartObject();
                    jw.WritePropertyName("Tiempo");
                    jw.WriteValue(precio.TiempoStr);
                    jw.WritePropertyName("IdTiempo");
                    jw.WriteValue(precio.TiempoId);
                    jw.WritePropertyName("Monto");
                    jw.WriteValue(precio.Monto);
                    jw.WriteEndObject();
                }

                jw.WriteEndArray();

                jw.WritePropertyName("Capacidad");


                try
                {
                    jw.WriteValue(servicio.Capacidad.Cantidad);
                }
                catch (Exception)
                {
                    jw.WriteValue("0");
                }

                jw.WriteEndObject();
            }


            jw.WriteEndArray();

            //HORARIOS
            jw.WritePropertyName("Horario");
            jw.WriteStartObject();
            jw.WritePropertyName("Dia");
            jw.WriteValue(this.Horario.DiaAtencionStr);
            jw.WritePropertyName("HoraDesde");
            jw.WriteValue(this.Horario.HoraDesde);
            jw.WritePropertyName("HoraHasta");
            jw.WriteValue(this.Horario.HoraHasta);
            jw.WriteEndObject();
            jw.WriteEndObject();

            return sb.ToString();
        }
    }
    
}


