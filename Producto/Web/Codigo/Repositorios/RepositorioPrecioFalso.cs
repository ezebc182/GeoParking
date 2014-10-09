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
    public class RepositorioPrecioFalso : IRepositorioPrecio
    {
        public Precio FindById(int id)
        {
            throw new NotImplementedException();
        }

        public IList<Precio> FindAll()
        {
            throw new NotImplementedException();
        }

        public IList<Precio> FindWhere(Func<Precio, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public Precio Create(Precio t)
        {
            throw new NotImplementedException();
        }

        public int Delete(Func<Precio, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public int Update(Precio t)
        {
            throw new NotImplementedException();
        }
    }
}
