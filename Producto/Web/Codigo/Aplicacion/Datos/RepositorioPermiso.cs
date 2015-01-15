using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using System.Data.SqlClient;

namespace Datos
{
    public class RepositorioPermiso : Repositorio<Permiso>, IRepositorioPermiso
    {
        public override IList<Permiso> FindAll()
        {
            return DbSet
                 .Include("Roles")
                .ToList();
        }

        public override IList<Permiso> FindWhere(Func<Permiso, bool> predicate)
        {
            var lista = DbSet
                .Include("Roles")
                .Where(predicate);

            return lista.ToList();
        }
    }

}
