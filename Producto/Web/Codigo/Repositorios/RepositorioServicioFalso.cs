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
    public class RepositorioServicioFalso : IRepositorioServicio
    {

        public Servicio FindById(int id)
        {
            throw new NotImplementedException();
        }

        public IList<Servicio> FindAll()
        {
            throw new NotImplementedException();
        }

        public IList<Servicio> FindWhere(Func<Servicio, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public Servicio Create(Servicio t)
        {
            throw new NotImplementedException();
        }

        public int Delete(Func<Servicio, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public int Update(Servicio t)
        {
            throw new NotImplementedException();
        }
    }
}
