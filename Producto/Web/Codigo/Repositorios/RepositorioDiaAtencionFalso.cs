using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;

namespace Repositorios
{
    public class RepositorioDiaAtencionFalso : IRepositorioDiaAtencion
    {
        public Entidades.DiaAtencion FindById(int id)
        {
            throw new NotImplementedException();
        }

        public IList<Entidades.DiaAtencion> FindAll()
        {
            throw new NotImplementedException();
        }

        public IList<Entidades.DiaAtencion> FindWhere(System.Linq.Expressions.Expression<Func<Entidades.DiaAtencion, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Entidades.DiaAtencion Create(Entidades.DiaAtencion t)
        {
            throw new NotImplementedException();
        }

        public int Delete(System.Linq.Expressions.Expression<Func<Entidades.DiaAtencion, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public int Update(Entidades.DiaAtencion t)
        {
            throw new NotImplementedException();
        }
    }
}
