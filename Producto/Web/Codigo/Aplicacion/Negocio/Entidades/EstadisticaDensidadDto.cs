﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Entidades
{
    public class EstadisticaDensidadDto: EntidadBase
    {
        public DateTime Hora { get; set; }
        public string Latitud { get; set; }
        public string Longitud { get; set; }

        public string ToJSONRepresentation()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}