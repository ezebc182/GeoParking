using ReglasDeNegocio.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;

namespace ReglasDeNegocio
{
    public class GestorAutenticacion
    {
        IRepositorioConexion repositorioDao = new RepositorioConexion();

        public Resultado verificarAutenticacion(int idPlaya, string token)
        {
            Resultado resultado = new Resultado();

            var conexion = repositorioDao.FindWhere(c => c.PlayaDeEstacionamientoId == idPlaya & c.Token == token).FirstOrDefault();

            if (conexion == null)
            {
                resultado.AgregarMensaje("no existe conexion");
            }

            return resultado;
        }
    }
}
