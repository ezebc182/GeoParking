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
                Id = 1,
                Direccion = "Calle Falsa 123",
                CapacidadAutos = 123,
                FechaAlta = DateTime.Now,
                HoraDesde = "00:00",
                HoraHasta = "00:00",
                Nombre = "Playa de Prueba",
                Latitud = -31.436111,
                Longitud = -64.193725,
                Motos = false,
                Utilitarios = true,
                Bicicletas = false,
                PrecioUtilitarios = 20.00,
                TipoPlayaId = 1,
                PrecioBicicletas = 0,
                PrecioMotos = 0
            };
        }

        public IList<PlayaDeEstacionamiento> FindAll()
        {            
            List<PlayaDeEstacionamiento> lista = new List<PlayaDeEstacionamiento>();
            lista.Add(new PlayaDeEstacionamiento
                {
                    Id = 1,
                    Direccion = "Calle Falsa 123",
                    CapacidadAutos = 123,
                    FechaAlta = DateTime.Now,
                    HoraDesde = "00:00",
                    HoraHasta = "00:00",
                    Nombre = "Playa de Prueba",
                    Latitud = -31.436111,
                    Longitud = -64.193725,
                    Motos = false,
                    Utilitarios = true,
                    Bicicletas = false,
                    PrecioUtilitarios = 20.00,
                    TipoPlayaId = 1,
                    PrecioBicicletas = 0,
                    PrecioMotos = 0
                });
            lista.Add(new PlayaDeEstacionamiento
                {
                    Id = 2,
                    Direccion = "Calle Falsa 321",
                    CapacidadAutos = 321,
                    FechaAlta = DateTime.Now,
                    HoraDesde = "00:00",
                    HoraHasta = "00:00",
                    Nombre = "Playa de Prueba2",
                    Latitud = -64.193725,
                    Longitud = -31.436111,
                    Motos = false,
                    Utilitarios = true,
                    Bicicletas = false,
                    PrecioUtilitarios = 20.00,
                    TipoPlayaId = 1,
                    PrecioBicicletas = 0,
                    PrecioMotos = 0
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
