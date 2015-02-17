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
    public class RepositorioConexion : Repositorio<Conexion>, IRepositorioConexion
    {
        public override IList<Conexion> FindAll()
        {
            return DbSet
                .ToList();
        }

        public override IList<Conexion> FindWhere(Func<Conexion, bool> predicate)
        {
            var lista = DbSet
                .Where(predicate);
            return lista.ToList();
        }
    }
}