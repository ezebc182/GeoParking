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
    public class RepositorioPlayasFalso : IRepositorioPlayaDeEstacionamiento
    {

        public PlayaDeEstacionamiento FindById(int id)
        {
            return new PlayaDeEstacionamiento
            {
                //Id = 1,
                //Direccion = "Calle Falsa 123",
                //CapacidadAutos = 123,
                //FechaAlta = DateTime.Now,
                //HoraDesde = "00:00",
                //HoraHasta = "00:00",
                //Nombre = "Playa de Prueba",
                //Latitud = -31.436111,
                //Longitud = -64.193725,
                //Motos = false,
                //Utilitarios = true,
                //Bicicletas = false,
                //PrecioUtilitarios = 20.00,
                //TipoPlayaId = 1,
                //PrecioBicicletas = 0,
                //PrecioMotos = 0
            };
        }

        public IList<PlayaDeEstacionamiento> FindAll()
        {
            List<PlayaDeEstacionamiento> lista = new List<PlayaDeEstacionamiento>();
            lista.Add(new PlayaDeEstacionamiento
                {
                    Id = 1,
                    FechaAlta = DateTime.Now,
                    Nombre = "Playa de Prueba",
                    Telefono = "49081274",
                    Mail = "mail@playa.com"
                });
            lista.Add(new PlayaDeEstacionamiento
                {
                    Id = 2,
                    FechaAlta = DateTime.Now,
                    Nombre = "Playa de Prueba 2",
                    Telefono = "49875642",
                    Mail = "mail@playa2.com"
                });
            return lista;
        }

        public IList<PlayaDeEstacionamiento> FindWhere(System.Linq.Expressions.Expression<Func<Entidades.PlayaDeEstacionamiento, bool>> predicate)
        {
            Func<PlayaDeEstacionamiento, bool> func = predicate.Compile();
            Predicate<PlayaDeEstacionamiento> pred = t => func(t);

            var lista = FindAll().ToList<PlayaDeEstacionamiento>();
            return lista.FindAll(pred);
        }

        public PlayaDeEstacionamiento Create(Entidades.PlayaDeEstacionamiento t)
        {
            throw new NotImplementedException();
        }

        public int Delete(System.Linq.Expressions.Expression<Func<PlayaDeEstacionamiento, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public int Update(PlayaDeEstacionamiento t)
        {
            throw new NotImplementedException();
        }
    }
}
