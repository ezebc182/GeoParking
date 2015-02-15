using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using RefactorThis.GraphDiff;
using System.Data.SqlClient;

namespace Datos
{
    public class RepositorioSolicitud : Repositorio<SolicitudConexion>, IRepositorioSolicitudConexion
    {
        public override IList<SolicitudConexion> FindAll()
        {
            return DbSet
                .ToList();
        }

        public override IList<SolicitudConexion> FindWhere(Func<SolicitudConexion, bool> predicate)
        {
            var lista = DbSet
                .Where(predicate);
            return lista.ToList();
        }
    }
}
