using Datos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReglasDeNegocio
{
    public class GestorSolicitud
    {
        IRepositorioSolicitudConexion rolSolicitud;

        public GestorSolicitud()
        {
            rolSolicitud = new RepositorioSolicitud();
        }

        public IList<SolicitudConexion> BuscarSolicitudes()
        {   
            return rolSolicitud.FindWhere(x => x.FechaBaja == null);
        }

        public IList<SolicitudConexion> BuscarMisSolicitudes(string usuario)
        {
            return rolSolicitud.FindWhere(x => x.FechaBaja == null && x.UsuarioResponsable == usuario);
        } 
    }
}
