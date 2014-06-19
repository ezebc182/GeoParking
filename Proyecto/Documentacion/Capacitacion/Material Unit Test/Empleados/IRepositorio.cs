using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace Datos
{
    public interface IRepositorio<TEntity> where TEntity : class
    {
        TEntity FindById(int id);

        IList<TEntity> FindAll(Expression<Func<TEntity, bool>> predicate);

        IList<TEntity> FindWhere(Expression<Func<TEntity, bool>> predicate);

        TEntity Create(TEntity t);

        int Delete(Expression<Func<TEntity, bool>> predicate);

        int Update(TEntity t);
    }

}
