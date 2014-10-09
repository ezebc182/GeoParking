using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;

namespace Repositorios
{
    public class RepositorioTipoVehiculoFalso : IRepositorioTipoVehiculo
    {

        public Entidades.TipoVehiculo FindById(int id)
        {
            throw new NotImplementedException();
        }

        public IList<Entidades.TipoVehiculo> FindAll()
        {
            throw new NotImplementedException();
        }

        public IList<Entidades.TipoVehiculo> FindWhere(Func<Entidades.TipoVehiculo, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public Entidades.TipoVehiculo Create(Entidades.TipoVehiculo t)
        {
            throw new NotImplementedException();
        }

        public int Delete(Func<Entidades.TipoVehiculo, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public int Update(Entidades.TipoVehiculo t)
        {
            throw new NotImplementedException();
        }
    }
}
