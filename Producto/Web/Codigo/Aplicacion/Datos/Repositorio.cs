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
            ////Contexto especifico del contexto
            //try
            //{
            //    contexto = new ContextoBD();
            //}
            //catch (Exception e)
            //{
            //    throw new DataBaseException(e.Message, e);
            //}
        }

        /// <summary>
        /// DbSet de la entidad
        /// </summary>
        protected virtual DbSet<TEntity> DbSet
        {
            get
            {
                contexto = new ContextoBD();

                return contexto.Set<TEntity>();

            }
        }

        /// <summary>
        /// busca la entidad por ID
        /// </summary>
        /// <param name="id">ID de la entidad</param>
        /// <returns>una entidad</returns>
        public virtual TEntity FindById(int id)
        {
            var lista = DbSet.Where(x => x.Id == id).ToList<TEntity>();
            return lista[0];
        }

        /// <summary>
        /// busca todas las entidades
        /// </summary>
        /// <returns>lista de todas las entidades</returns>
        public virtual IList<TEntity> FindAll()
        {
            return DbSet.ToList<TEntity>();
        }

        /// <summary>
        /// busca todas las entidades de acuerdo a una consulta
        /// </summary>
        /// <param name="predicate">consulta</param>
        /// <returns>lista de entidades o null si no se encuentra nada</returns>
        public virtual IList<TEntity> FindWhere(Func<TEntity, bool> predicate)
        {
            var lista = DbSet.Where(predicate);

            return lista.ToList<TEntity>();

        }

        /// <summary>
        /// crea una entidad
        /// </summary>
        /// <param name="entity">entidad a crear</param>
        /// <returns>la entidad creada</returns>
        public virtual TEntity Create(TEntity entity)
        {
            using (contexto = new ContextoBD())
            {
                var result = DbSet.Add(entity);
                try
                {
                    contexto.SaveChanges();
                }
                catch (Exception e)
                {
                    throw new DataBaseException(e.Message, e);
                }
                return result;
            }
        }

        /// <summary>
        /// elimina segun una consulta
        /// </summary>
        /// <param name="predicate">consulta</param>
        /// <returns>0 sino se realizo la accion, -1 si dio error</returns>
        public int Delete(Func<TEntity, bool> predicate)
        {
            using (contexto = new ContextoBD())
            {
                var objects = FindWhere(predicate);
                foreach (var obj in objects)
                {
                    obj.FechaBaja = DateTime.Now;
                    Update(obj);
                }
                try
                {
                    return contexto.SaveChanges();
                }
                catch (Exception e)
                {
                    throw new DataBaseException(e.Message, e);
                }
            }
        }

        /// <summary>
        /// Actualiza una entidad
        /// </summary>
        /// <param name="t">entidad a actualizar</param>
        /// <returns>0 sino se realizo ninguna accion</returns>
        public virtual int Update(TEntity t)
        {
            using (contexto = new ContextoBD())
            {
                var currentEntity = FindById(t.Id);
                var entry = contexto.Entry(currentEntity);

                entry.CurrentValues.SetValues(t);
                try
                {
                    return contexto.SaveChanges();
                }
                catch (Exception e)
                {
                    throw new DataBaseException(e.Message, e);
                }
            }
        }
    }

    public class DataBaseException : Exception
    {
        public DataBaseException(string msj)
            : base(msj)
        {
        }
        public DataBaseException(string msj, Exception innerException)
            : base(msj, innerException)
        {
        }

    }
}
