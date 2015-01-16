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
    //interfaces que implementan la interface IRepositorio 
    public interface IRepositorioPlayaDeEstacionamiento : IRepositorio<PlayaDeEstacionamiento> { }
    public interface IRepositorioTipoDePlaya : IRepositorio<TipoPlaya> { }
    public interface IRepositorioTipoVehiculo : IRepositorio<TipoVehiculo> { }
    public interface IRepositorioServicio : IRepositorio<Servicio> { }
    public interface IRepositorioDireccion : IRepositorio<Direccion> { IList<Direccion> GetDireccionesDePlayasPorCiudadYTipoVehiculo(string ciudad, int tipoVehiculoId);
    IList<Direccion> GetDireccionesPorDistanciaYTipoVehiculo(string latitud, string longitud, int tipoVehiculoId);
    }
    public interface IRepositorioHorario : IRepositorio<Horario> { }
    public interface IRepositorioPrecio : IRepositorio<Precio> { IList<Precio> GetPreciosDePlayasPorTipoVehiculoEIdPlayas(string idsPlayas, int tipoVehiculo);}
    public interface IRepositorioDiaAtencion : IRepositorio<DiaAtencion> { }
    public interface IRepositorioTiempo : IRepositorio<Tiempo> { }
    public interface IRepositorioUsuario : IRepositorio<Usuario> { }
    public interface IRepositorioRol : IRepositorio<Rol> { }
    public interface IRepositorioPermiso : IRepositorio<Permiso> { }
    public interface IRepositorioEstadisticaConsultas : IRepositorio<EstadisticaConsultas> { }
    public interface IRepositorioEventos : IRepositorio<Evento> { }
    public interface IRepositorioDisponibilidadPlayas : IRepositorio<DisponibilidadPlayas> { List<ConsultaDisponibilidad> GetDisponibilidadDePlayasPorTipoVehiculo(string idPlayas, int tipoVehiculo);}
    public interface IRepositorioZonas : IRepositorio<Zona> { }
    public interface IRepositorioHistorialDisponibilidadPlayas : IRepositorio<HistorialDisponibilidadPlayas> { }

    //Clases DAO para cada entidad que heredan de la clase Repositorio
    public class RepositorioTipoDePlaya : Repositorio<TipoPlaya>, IRepositorioTipoDePlaya { }
    public class RepositorioTipoVehiculo : Repositorio<TipoVehiculo>, IRepositorioTipoVehiculo { }   
    public class RepositorioHorario : Repositorio<Horario>, IRepositorioHorario { }
    public class RepositorioDiaAtencion : Repositorio<DiaAtencion>, IRepositorioDiaAtencion { }
    public class RepositorioTiempo : Repositorio<Tiempo>, IRepositorioTiempo { }
    public class RepositorioUsuario : Repositorio<Usuario>, IRepositorioUsuario { }
    public class RepositorioHistorialDisponibilidadPlayas : Repositorio<HistorialDisponibilidadPlayas>, IRepositorioHistorialDisponibilidadPlayas { }
    public class RepositorioEvento : Repositorio<Evento>, IRepositorioEventos { }


    public class RepositorioServicio : Repositorio<Servicio>, IRepositorioServicio 
    {
        public override IList<Servicio> FindWhere(Func<Servicio,bool> predicate)
        {
            var lista = DbSet
                .Include("PlayaDeEstacionamiento")
                .Include("TipoVehiculo")
                .Include("DisponibilidadPlayas")
                .Include("Capacidad")
                .Include("Precios")
                .Where(predicate);

            return lista.ToList();
        }

        public override int Update(Servicio t)
        {
            using (contexto = new ContextoBD())
            {
                var entry = contexto.Entry(t);
                if (entry.State == System.Data.Entity.EntityState.Detached)
                {
                    contexto.UpdateGraph(t, map => map
                     .OwnedCollection(s => s.Precios, with => with
                         .AssociatedEntity(d => d.Servicio))
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

