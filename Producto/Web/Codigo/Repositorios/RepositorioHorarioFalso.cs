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
    public class RepositorioHorarioFalso : IRepositorioHorario
    {

        public Horario FindById(int id)
        {
            throw new NotImplementedException();
        }

        public IList<Horario> FindAll()
        {
            throw new NotImplementedException();
        }

        public IList<Horario> FindWhere(Func<Horario, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public Horario Create(Horario t)
        {
            throw new NotImplementedException();
        }

        public int Delete(Func<Horario, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public int Update(Horario t)
        {
            throw new NotImplementedException();
        }
    }
}
