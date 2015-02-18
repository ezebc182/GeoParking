using Datos;
using Entidades;
using Newtonsoft.Json;
using ReglasDeNegocio.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReglasDeNegocio
{
    public class GestorSolicitud
    {
        IRepositorioSolicitudConexion daoSolicitud;

        public GestorSolicitud()
        {
            daoSolicitud = new RepositorioSolicitud();
        }

        public IList<SolicitudConexion> BuscarSolicitudes()
        {   
            return daoSolicitud.FindWhere(x => x.FechaBaja == null);
        }

        public IList<SolicitudConexion> BuscarMisSolicitudes(string usuario)
        {
            return daoSolicitud.FindWhere(x => x.FechaBaja == null && x.UsuarioResponsable == usuario && x.EstadoId != 7);
        }

        public string CrearSolicitudJSON(SolicitudConexion solicitud)
        {
            return JsonConvert.SerializeObject(RegistrarNuevaSolicitud(solicitud));
        }

        public bool RegistrarNuevaSolicitud(SolicitudConexion solicitud)
        {
            var resultado = new Resultado();

            if (resultado.Ok)
            {
                daoSolicitud.Create(solicitud);
            }

            return resultado.Ok;
        }

        public SolicitudConexion BuscarSolicitud(int id)
        {
            return daoSolicitud.FindWhere(x => x.FechaBaja == null && x.Id == id).FirstOrDefault();
        }

        public SolicitudConexion BuscarSolicitudByUsuario(string usuario)
        {
            return daoSolicitud.FindWhere(x => x.FechaBaja == null && x.UsuarioResponsable == usuario && x.EstadoId == 6).FirstOrDefault();
        }

        public bool UpdateSolicitud(SolicitudConexion solicitud)
        {
            var resultado = new Resultado();

            if (resultado.Ok)
            {
                daoSolicitud.Update(solicitud);
            }

            return resultado.Ok;
        }
    }
}
