using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using System.Data.Entity;

namespace Datos
{
    public class Repositorio<TEntity> : IRepositorio<TEntity> where TEntity : EntidadBase
    {
        //Contexto de la BD
        protected ContextoBD contexto = null;

        /// <summary>
        /// Constructor
        /// </summary>  
        public Repositorio()
        {
            //Contexto especifico del contexto
            contexto = ContextoBD.getInstace();
        }

        /// <summary>
        /// DbSet de la entidad
        /// </summary>
        protected DbSet<TEntity> DbSet
        {
            get { return contexto.Set<TEntity>(); }
        }

        /// <summary>
        /// busca la entidad por ID
        /// </summary>
        /// <param name="id">ID de la entidad</param>
        /// <returns>una entidad</returns>
        public TEntity FindById(int id)
        {
            var lista = DbSet.Where(x => x.Id == id).ToList<TEntity>();
            return lista[0];
        }

        /// <summary>
        /// busca todas las entidades
        /// </summary>
        /// <returns>lista de todas las entidades</returns>
        public IList<TEntity> FindAll()
        {
            return DbSet.ToList<TEntity>();
        }

        /// <summary>
        /// busca todas las entidades de acuerdo a una consulta
        /// </summary>
        /// <param name="predicate">consulta</param>
        /// <returns>lista de entidades</returns>
        public IList<TEntity> FindWhere(System.Linq.Expressions.Expression<Func<TEntity, bool>> predicate)
        {
            var lista = DbSet.Where(predicate).ToList<TEntity>();
            return lista;
        }

        /// <summary>
        /// crea una entidad
        /// </summary>
        /// <param name="entity">entidad a crear</param>
        /// <returns>la entidad creada</returns>
        public TEntity Create(TEntity entity)
        {
            var result = DbSet.Add(entity);
            contexto.SaveChanges();
            return result;
        }

        /// <summary>
        /// elimina segun una consulta
        /// </summary>
        /// <param name="predicate">consulta</param>
        /// <returns>0 sino se realizo la accion</returns>
        public int Delete(System.Linq.Expressions.Expression<Func<TEntity, bool>> predicate)
        {
            var objects = FindWhere(predicate);
            foreach (var obj in objects)
            {
                obj.FechaBaja = DateTime.Now;
                Update(obj);
            }
            return contexto.SaveChanges();
            // TODO: Control de excepciones
        }

        /// <summary>
        /// Actualiza una entidad
        /// </summary>
        /// <param name="t">entidad a actualizar</param>
        /// <returns>0 sino se realizo ninguna accion</returns>
        public int Update(TEntity t)
        {
            var currentEntity = FindById(t.Id);
            var entry = contexto.Entry(currentEntity);
            //DbSet.Attach(t);
            entry.CurrentValues.SetValues(t);
            return contexto.SaveChanges();
        }
    }
}
