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
        /// <summary>
        /// busca una entidad por el ID
        /// </summary>
        /// <param name="id">id de la entidad</param>
        /// <returns>la entidad con ese ID</returns>
        TEntity FindById(int id);

        /// <summary>
        /// busca todos las entidades
        /// </summary>
        /// <returns>todas las entidades</returns>
        IList<TEntity> FindAll();

        /// <summary>
        /// busca las entidades de acuerdo a una consulta
        /// </summary>
        /// <param name="predicate">consulta</param>
        /// <returns>lista de entidades encontradas</returns>
        IList<TEntity> FindWhere(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        /// crea una entidad
        /// </summary>
        /// <param name="t">entidad a crear</param>
        /// <returns>entidad creada</returns>
        TEntity Create(TEntity t);

        /// <summary>
        /// elimina una entidad
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns>0 sino se realizo ninguna accion</returns>
        int Delete(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        /// actualiza una entidad
        /// </summary>
        /// <param name="t">es la entidad actualizada</param>
        /// <returns>0 sino se realizo ninguna accion</returns>
        int Update(TEntity t);
    }
}
