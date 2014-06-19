using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Entidades;

namespace Datos
{

    public class Repositorio<TEntity> : IRepositorio<TEntity> where TEntity : EntidadBase
    {
        protected ContextoBD contexto = null;

        ///
        /// Constructor de clase
        ///
        ///Contexto específico del proyecto
        public Repositorio()
        {
            contexto = ContextoBD.getInstace();
        }

        protected DbSet<TEntity> DbSet
        {
            get { return contexto.Set<TEntity>(); }
        }

        public TEntity FindById(int id)
        {
           var lista = DbSet.Where(x => x.Id == id).ToList<TEntity>();
           return lista[0];
        }

        public IList<TEntity> FindAll(System.Linq.Expressions.Expression<Func<TEntity, bool>> predicate)
        {
            return DbSet.ToList<TEntity>();
        }

        public IList<TEntity> FindWhere(System.Linq.Expressions.Expression<Func<TEntity, bool>> predicate)
        {
            var lista = DbSet.Where(predicate).ToList<TEntity>();
            return lista;
        }

        public TEntity Create(TEntity entity)
        {
            return DbSet.Add(entity);
        }
        
        public int Delete(System.Linq.Expressions.Expression<Func<TEntity, bool>> predicate)
        {
            var objects = FindWhere(predicate);
            foreach (var obj in objects)
            {
                DbSet.Remove(obj);
            }
            return contexto.SaveChanges();
            // TODO: Control de excepciones
        }

        public int Update(TEntity t)
        {
            var entry = contexto.Entry(t);
            DbSet.Attach(t);
            entry.State = EntityState.Modified;
            return contexto.SaveChanges();
        }
    }
}
