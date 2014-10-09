using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;

namespace Repositorios
{
    public class RepositorioTipoPlayasFalso : IRepositorioTipoDePlaya
    {
        public Entidades.TipoPlaya FindById(int id)
        {
            throw new NotImplementedException();
        }

        public IList<Entidades.TipoPlaya> FindAll()
        {
            throw new NotImplementedException();
        }

        public IList<Entidades.TipoPlaya> FindWhere(Func<Entidades.TipoPlaya, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public Entidades.TipoPlaya Create(Entidades.TipoPlaya t)
        {
            throw new NotImplementedException();
        }

        public int Delete(Func<Entidades.TipoPlaya, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public int Update(Entidades.TipoPlaya t)
        {
            throw new NotImplementedException();
        }
    }
}
