using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public double Latitud { get; set; }
        public double Longitud { get; set; }

        //referencia a ciudad
        public virtual Ciudad Ciudad { get; set; }

    }
}
