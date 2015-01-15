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
    public class RepositorioRol : Repositorio<Rol>, IRepositorioRol
    {
        public override IList<Rol> FindAll()
        {
            return DbSet
                 .Include("Permisos")
                .ToList();
        }

        public override IList<Rol> FindWhere(Func<Rol, bool> predicate)
        {
            var lista = DbSet
                .Include("Permisos")
                .Where(predicate);

            return lista.ToList();
        }
        public override int Update(Rol t)
        {
            RepositorioPermiso repoPermisos = new RepositorioPermiso();
            using (var contexto = new ContextoBD())
            {
                contexto.UpdateGraph(t, map => map
                    .AssociatedCollection(r => r.Permisos));
                foreach (var permiso in t.Permisos)
                {
                    contexto.UpdateGraph(permiso, map => map
                    .AssociatedCollection(p => p.Roles));
                }
                return contexto.SaveChanges();
            }
        }
    }
    
}
