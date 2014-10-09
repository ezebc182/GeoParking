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
    public class RepositorioProvinciaFalso : IRepositorioProvincia
    {
        List<Provincia> lista;
        public RepositorioProvinciaFalso()
        {
            lista = new List<Provincia>();
            lista.Add(new Provincia { Id = 1, Nombre = "Cordoba", FechaAlta = new DateTime(2014, 07, 13) });
            lista.Add(new Provincia { Id = 2, Nombre = "Mendoza", FechaAlta = new DateTime(2014, 07, 13) });
        }
        public Provincia FindById(int id)
        {
            return lista.Where(x => x.Id == id).First();
        }

        public IList<Provincia> FindAll()
        {
            return lista;
        }

        public IList<Provincia> FindWhere(Func<Provincia, bool> predicate)
        {
           Predicate<Provincia> pred = t => predicate(t);

            return lista.FindAll(pred);
        }

        public Provincia Create(Provincia t)
        {
            lista.Add(t);
            return t;
        }

        public int Delete(Func<Provincia, bool> predicate)
        {
           
            Predicate<Provincia> pred = t => predicate(t);
            var borrar = lista.FindAll(pred);
            foreach (var item in borrar)
            {
                lista.Remove(item);
            }
            return borrar.Count();
        }

        public int Update(Provincia t)
        {
            lista.Remove(FindById(t.Id));
            Create(t);
            return 1;
        }
    }
}
