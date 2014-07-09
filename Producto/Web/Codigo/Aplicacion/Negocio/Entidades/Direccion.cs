using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
namespace Entidades
{
    public class Direccion : EntidadBase
    {
        //Calle
        public string Calle { get; set; }
        //Numero
        public int Numero { get; set; }
        //Ciudad
        public int CiudadId { get; set; }
        //Playa
        public int? PlayaDeEstacionamientoId { get; set; }
        public virtual PlayaDeEstacionamiento PlayaDeEstacionamiento { get; set; }

        //Coordenadas Geograficas
        public string Latitud { get; set; }
        public string Longitud { get; set; }

        //referencia a ciudad
        public virtual Ciudad Ciudad { get; set; }

        [NotMapped]
        public Departamento Departamento { get; set; }
        [NotMapped]
        public Provincia Provincia { get; set; }
        [NotMapped]
        public string DepartamentoStr { get { return Departamento != null ? Departamento.Nombre : ""; } }
        [NotMapped]
        public string ProvinciaStr { get { return Provincia != null ? Provincia.Nombre : ""; } }
        [NotMapped]
        public string CiudadStr { get { return Ciudad != null ? Ciudad.Nombre : ""; } }

    }
}
