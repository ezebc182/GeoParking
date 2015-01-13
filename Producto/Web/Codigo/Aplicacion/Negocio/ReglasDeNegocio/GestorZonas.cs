﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;
using Entidades;
using System.Data.Entity.Spatial;
using ReglasDeNegocio.Util;

namespace ReglasDeNegocio
{
    public class GestorZonas
    {
        IRepositorioZonas zonasDao;

        public GestorZonas()
        {
            zonasDao = new RepositorioZona();
        }

        public Resultado RegistrarZona(Zona zona)
        {
            var resultado = ValidarZona(zona);
            if (resultado.Ok)
            {
                try
                {
                    zonasDao.Create(zona);
                }
                catch (DataBaseException e)
                {
                    resultado.AgregarMensaje("Se ha producido un error de base de datos");
                }
            }
            return resultado;
        }

        private Resultado ValidarZona(Zona zona)
        {
            Resultado resultado = new Resultado();

            if (String.IsNullOrWhiteSpace(zona.Nombre))
            {
                resultado.AgregarMensaje("Debe especificar un nombre para la zona ingresada.");
            }
            return resultado;
        }
    }
}
