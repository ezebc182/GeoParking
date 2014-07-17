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
    public class RepositorioDepartamentoFalso : IRepositorioDepartamento
    {
        List<Departamento> lista;
        public RepositorioDepartamentoFalso()
        {
            lista = new List<Departamento>();
            lista.Add(new Departamento { Id = 1, Nombre = "Capital", ProvinciaId = 1, FechaAlta = new DateTime(2014, 07, 13) });
            lista.Add(new Departamento { Id = 2, Nombre = "Rio Cuarto", ProvinciaId = 1, FechaAlta = new DateTime(2014, 07, 13) });
        }

        public Departamento FindById(int id)
        {
            return lista.Where(x => x.Id == id).First();
        }

        public IList<Departamento> FindAll()
        {
            return lista;
        }

        public IList<Departamento> FindWhere(System.Linq.Expressions.Expression<Func<Departamento, bool>> predicate)
        {
            Func<Departamento, bool> func = predicate.Compile();
            Predicate<Departamento> pred = t => func(t);

            return lista.FindAll(pred);
        }

        public Departamento Create(Departamento t)
        {
            lista.Add(t);
            return t;
        }

        public int Delete(System.Linq.Expressions.Expression<Func<Departamento, bool>> predicate)
        {
            Func<Departamento, bool> func = predicate.Compile();
            Predicate<Departamento> pred = t => func(t);
            var borrar = lista.FindAll(pred);
            foreach (var item in borrar)
            {
                lista.Remove(item);
            }
            return borrar.Count();
        }

        public int Update(Departamento t)
        {
            lista.Remove(FindById(t.Id));
            Create(t);
            return 1;
        }
    }
}
