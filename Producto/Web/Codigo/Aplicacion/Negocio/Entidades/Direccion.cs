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
        public virtual Ciudad Ciudad
        {
            get { return ciudad; }
            set
            {
                ciudad = value;
                CiudadStr = value.Nombre;
                CiudadId = value.Id;
            }
        }

        [NotMapped]
        private Ciudad ciudad;
        [NotMapped]
        private Departamento departamento;
        [NotMapped]
        public Departamento Departamento
        {
            get { return departamento; }
            set
            {
                departamento = value;
                DepartamentoStr = value.Nombre;
            }
        }
        [NotMapped]
        private Provincia provincia;
        [NotMapped]
        public Provincia Provincia
        {
            get { return provincia; }
            set
            {
                provincia = value;
                ProvinciaStr = value.Nombre;
            }
        }
        [NotMapped]
        public string DepartamentoStr { get; set; }
        [NotMapped]
        public string ProvinciaStr { get; set; }
        [NotMapped]
        public string CiudadStr { get; set; }

    }
}
