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
    public class RepositorioDireccionFalso : IRepositorioDireccion
    {
        public Direccion FindById(int id)
        {
            throw new NotImplementedException();
        }

        public IList<Direccion> FindAll()
        {
            throw new NotImplementedException();
        }

        public IList<Direccion> FindWhere(System.Linq.Expressions.Expression<Func<Direccion, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Direccion Create(Direccion t)
        {
            throw new NotImplementedException();
        }

        public int Delete(System.Linq.Expressions.Expression<Func<Direccion, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public int Update(Direccion t)
        {
            throw new NotImplementedException();
        }
    }
}
