using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using RefactorThis.GraphDiff;
using System.Data.SqlClient;
using System.Data.Entity.Spatial;

namespace Datos
{
    public class RepositorioPlayaDeEstacionamiento : Repositorio<PlayaDeEstacionamiento>, IRepositorioPlayaDeEstacionamiento
    {


        public override IList<PlayaDeEstacionamiento> FindAll()
        {
            return DbSet
                .Include("Direcciones")
                .Include("Horario.DiaAtencion")
                .Include("Servicios.Precios.Tiempo")
                .Include("Servicios.TipoVehiculo")
                .Include("Servicios.Capacidad")
                .Include("TipoPlaya")
                .ToList();
        }

        public override IList<PlayaDeEstacionamiento> FindWhere(Func<PlayaDeEstacionamiento, bool> predicate)
        {
            var lista = DbSet
                .Include("Direcciones")
                .Include("Horario.DiaAtencion")
                .Include("Servicios.Precios.Tiempo")
                .Include("Servicios.TipoVehiculo")
                .Include("Servicios.Capacidad")
                .Include("TipoPlaya")
                .Include("Servicios.DisponibilidadPlayas")
                .Where(predicate);

            return lista.ToList();
        }

        public override PlayaDeEstacionamiento Create(PlayaDeEstacionamiento entity)
        {
            Update(entity);
            return entity;
        }

        public override int Delete(Func<PlayaDeEstacionamiento, bool> predicate)
        {
            var cont = 0;
            var objects = FindWhere(predicate);
            foreach (var obj in objects)
            {
                obj.FechaBaja = DateTime.Now;
                cont += Update(obj);
            }
            return cont;
        }
        public override int Update(PlayaDeEstacionamiento t)
        {
            using (contexto = new ContextoBD())
            {
                var entry = contexto.Entry(t);
                if (entry.State == System.Data.Entity.EntityState.Detached)
                {
                    contexto.UpdateGraph(t, map => map
                   .OwnedCollection(p => p.Direcciones, with => with
                       .AssociatedEntity(d => d.PlayaDeEstacionamiento))
                   .OwnedCollection(p => p.Servicios, with => with
                   .OwnedCollection(s => s.Precios, con => con
                       .AssociatedEntity(p => p.Servicio))
                   .OwnedEntity(s => s.DisponibilidadPlayas)
                       .AssociatedEntity(s => s.PlayaDeEstacionamiento)
                       .OwnedEntity(s => s.Capacidad))
                   .OwnedEntity(p => p.Horario)
                   );
                    return contexto.SaveChanges();
                }

                else
                {
                    return base.Update(t);
                }
            }
        }


    }

}
