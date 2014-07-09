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
        public string Provincia { get { return Direcciones.Count > 0 ? Direcciones[0].ProvinciaStr : ""; } }

        #endregion
    }
}
