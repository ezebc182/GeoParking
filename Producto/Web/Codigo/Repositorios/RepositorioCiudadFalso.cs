using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;
using Entidades;
using System.Data;
using System.Data.Entity;

namespace Repositorios
{
    public class RepositorioCiudadFalso : IRepositorioCiudad
    {
        List<Ciudad> lista;
        public RepositorioCiudadFalso()
        {
            lista = new List<Ciudad>();
            lista.Add(new Ciudad { Id = 1, Nombre = "Cordoba", DepartamentoId = 1, FechaAlta = new DateTime(2014, 07, 13) });
            lista.Add(new Ciudad { Id = 2, Nombre = "Rio Cuarto", DepartamentoId = 2, FechaAlta = new DateTime(2014, 07, 13) });
        }
        public Ciudad FindById(int id)
        {
            return (FindAll().Where(x => x.Id == id)).First();
        }

        public IList<Ciudad> FindAll()
        {            
            return lista;
        }

        public IList<Ciudad> FindWhere(System.Linq.Expressions.Expression<Func<Ciudad, bool>> predicate)
        {
            Func<Ciudad, bool> func = predicate.Compile();
            Predicate<Ciudad> pred = t => func(t);

            return lista.FindAll(pred);
        }

        public Ciudad Create(Ciudad t)
        {
            lista.Add(t);
            return t;
        }

        public int Delete(System.Linq.Expressions.Expression<Func<Ciudad, bool>> predicate)
        {
             Func<Ciudad, bool> func = predicate.Compile();
            Predicate<Ciudad> pred = t => func(t);
            var borrar = lista.FindAll(pred);
            foreach (var item in borrar)
            {
                lista.Remove(item);
            }
            return borrar.Count();
        }

        public int Update(Ciudad t)
        {
            lista.Remove(FindById(t.Id));
            Create(t);
            return 1;
        }
    }
}
