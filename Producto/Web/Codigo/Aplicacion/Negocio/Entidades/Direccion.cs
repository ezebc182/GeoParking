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

        //Coordenadas Geograficas
        public string Latitud { get; set; }
        public string Longitud { get; set; }

        //referencia a ciudad
        public virtual Ciudad Ciudad{get;set;}

        [NotMapped]
        public string DepartamentoStr { get { return Ciudad != null ? Ciudad.Departamento.Nombre : ""; } }
        [NotMapped]
        public string ProvinciaStr { get { return Ciudad != null ? Ciudad.Departamento.Provincia.Nombre : ""; } }
        [NotMapped]
        public string CiudadStr { get { return Ciudad != null ? Ciudad.Nombre : ""; } }

    }
}
