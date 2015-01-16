using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using System.Data.SqlClient;
using RefactorThis.GraphDiff;

namespace Datos
{
    public class RepositorioZona : Repositorio<Zona>, IRepositorioZonas
    {

        public override IList<Zona> FindWhere(Func<Zona, bool> predicate)
        {
            var lista = DbSet
                .Include("Usuario")
                .Where(predicate);

            return lista.ToList();
        }

        public override int Delete(Func<Zona, bool> predicate)
        {
            var cont = 0;
            var objects = FindWhere(predicate);
            foreach (var obj in objects)
            {
                obj.FechaBaja = DateTime.Now;
                cont += Update(obj);
            }
            return cont;
        }
        public override int Update(Zona t)
        {
            using (contexto = new ContextoBD())
            {
                var entry = contexto.Entry(t);
                if (entry.State == System.Data.Entity.EntityState.Detached)
                {
                    contexto.UpdateGraph(t, map => map
                   .AssociatedEntity(z => z.Usuario)
                   );
                    return contexto.SaveChanges();
                }

                else
                {
                    return base.Update(t);
                }
            }
        }
    }
    
}
