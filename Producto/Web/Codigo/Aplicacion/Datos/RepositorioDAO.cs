using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using RefactorThis.GraphDiff;
using System.Data.SqlClient;

namespace Datos
{
    //interfaces que implementan la interface IRepositorio 
    public interface IRepositorioPlayaDeEstacionamiento : IRepositorio<PlayaDeEstacionamiento> { }
    public interface IRepositorioTipoDePlaya : IRepositorio<TipoPlaya> { }
    public interface IRepositorioTipoVehiculo : IRepositorio<TipoVehiculo> { }
    public interface IRepositorioServicio : IRepositorio<Servicio> { }
    public interface IRepositorioDireccion : IRepositorio<Direccion> { IList<Direccion> GetDireccionesDePlayasPorCiudadYTipoVehiculo(string ciudad, int tipoVehiculoId);}
    public interface IRepositorioHorario : IRepositorio<Horario> { }
    public interface IRepositorioPrecio : IRepositorio<Precio> { IList<Precio> GetPreciosDePlayasPorTipoVehiculoEIdPlayas(string idsPlayas, int tipoVehiculo);}
    public interface IRepositorioDiaAtencion : IRepositorio<DiaAtencion> { }
    public interface IRepositorioTiempo : IRepositorio<Tiempo> { }
    public interface IRepositorioUsuario : IRepositorio<Usuario> { }
    public interface IRepositorioRol : IRepositorio<Rol> { }
    public interface IRepositorioPermiso : IRepositorio<Permiso> { }
    public interface IRepositorioEstadisticaConsultas : IRepositorio<EstadisticaConsultas> { }
    public interface IRepositorioEventos : IRepositorio<Evento> { }
    public interface IRepositorioDisponibilidadPlayas : IRepositorio<DisponibilidadPlayas> { List<DisponibilidadPlayas> GetDisponibilidadDePlayasPorTipoVehiculo(string idPlayas, int tipoVehiculo);}

    public interface IRepositorioHistorialDisponibilidadPlayas : IRepositorio<HistorialDisponibilidadPlayas> { }

    //Clases DAO para cada entidad que heredan de la clase Repositorio
    public class RepositorioTipoDePlaya : Repositorio<TipoPlaya>, IRepositorioTipoDePlaya { }
    public class RepositorioTipoVehiculo : Repositorio<TipoVehiculo>, IRepositorioTipoVehiculo { }
    public class RepositorioServicio : Repositorio<Servicio>, IRepositorioServicio { }

    public class RepositorioHorario : Repositorio<Horario>, IRepositorioHorario { }
    public class RepositorioPrecio : Repositorio<Precio>, IRepositorioPrecio
    {
        //spGetPreciosDePlayasPorTipoVehiculoEIdPlayas
        public IList<Precio> GetPreciosDePlayasPorTipoVehiculoEIdPlayas(string idsPlayas, int tipoVehiculo)
        {
            using (var context = new ContextoBD())
            {
                var idsPlayasParameter = new SqlParameter("@ListaIds", idsPlayas);
                var tipoVehiculoParameter = new SqlParameter("@TipoVehiculoId", tipoVehiculo);

                var result = context.Database
                    .SqlQuery<Precio>("spGetPreciosDePlayasPorTipoVehiculoEIdPlayas @ListaIds , @TipoVehiculoId", idsPlayasParameter, tipoVehiculoParameter)
                    .ToList();
                return result;
            }
        }
    }
    public class RepositorioDiaAtencion : Repositorio<DiaAtencion>, IRepositorioDiaAtencion { }
    public class RepositorioTiempo : Repositorio<Tiempo>, IRepositorioTiempo { }
    public class RepositorioUsuario : Repositorio<Usuario>, IRepositorioUsuario { }

    public class RepositorioEvento : Repositorio<Evento>, IRepositorioEventos { }    
    public class RepositorioDisponibilidadPlayas : Repositorio<DisponibilidadPlayas>, IRepositorioDisponibilidadPlayas
    {
        public List<DisponibilidadPlayas> GetDisponibilidadDePlayasPorTipoVehiculo(string idPlayas, int tipoVehiculo)
        {
            using (var context = new ContextoBD())
            {
                var idsPlayasParameter = new SqlParameter("@ListaIds", idPlayas);
                var tipoVehiculoParameter = new SqlParameter("@TipoVehiculoId", tipoVehiculo);

                var result = context.Database
                    .SqlQuery<DisponibilidadPlayas>("spObtenerDisponibilidadPlayasPorTipoVehiculo @ListaIds , @TipoVehiculoId", idsPlayasParameter, tipoVehiculoParameter)
                    .ToList();
                return result;
            }
        }
    }
    public class RepositorioHistorialDisponibilidadPlayas : Repositorio<HistorialDisponibilidadPlayas>, IRepositorioHistorialDisponibilidadPlayas { }

    public class RepositorioDireccion : Repositorio<Direccion>, IRepositorioDireccion
    {
        public IList<Direccion> GetDireccionesDePlayasPorCiudadYTipoVehiculo(string ciudad, int tipoVehiculoId)
        {
            using (var context = new ContextoBD())
            {
                var ciudadParameter = new SqlParameter("@Ciudad", ciudad);
                var tipoVehiculoParameter = new SqlParameter("@TipoVehiculoId", tipoVehiculoId);

                var result = context.Database
                    .SqlQuery<Direccion>("spObtenerUbicacionesDePlayasPorCiudadYTipoVehiculo @Ciudad , @TipoVehiculoId", ciudadParameter, tipoVehiculoParameter)
                    .ToList();
                return result;
            }
        }
    }
    /// <summary>
    /// Repositorios DAO de estadisticas
    /// </summary>
    public class RepositorioEstadisticaConsultas : Repositorio<EstadisticaConsultas>, IRepositorioEstadisticaConsultas
    {
        public IList<EstadisticaPorTipoPlayaDto> GetConsultasTipoPlayaByCiudad(int idCiudad)
        {
            return GetConsultasTipoPlayaByCiudad(idCiudad, null, null);
        }

        public IList<EstadisticaPorTipoPlayaDto> GetConsultasTipoPlayaByCiudad(int idCiudad, DateTime? desde, DateTime? hasta)
        {
            IList<EstadisticaPorTipoPlayaDto> lista = new List<EstadisticaPorTipoPlayaDto>();
            SqlConnection sqlConnection1 = new SqlConnection("Data Source=SQL5004.Smarterasp.net;Initial Catalog=DB_9B3453_Geoparking;User Id=DB_9B3453_Geoparking_admin;Password=geoparking");
            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader;

            cmd.CommandText = "spGetCantidadConsultasPorTipoPlaya";
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Connection = sqlConnection1;

            sqlConnection1.Open();

            reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    lista.Add(new EstadisticaPorTipoPlayaDto { Fecha = reader.GetInt32(0), Nombre = reader.GetString(1), Cantidad = reader.GetInt32(2) });
                }
            }

            sqlConnection1.Close();
            return lista;
            //using (var contexto = new ContextoBD())
            //{
            //    System.Data.SqlClient.SqlParameter fechaDesde, fechaHasta;

            //    var ciudad = new System.Data.SqlClient.SqlParameter("ciudad", idCiudad);
            //    if(desde.HasValue)  fechaDesde = new System.Data.SqlClient.SqlParameter("fechaDesde", desde.Value);
            //    else  fechaDesde = new System.Data.SqlClient.SqlParameter("fechaDesde", DBNull.Value);

            //    if(hasta.HasValue) fechaHasta = new System.Data.SqlClient.SqlParameter("fechaHasta", hasta.Value);
            //    else fechaHasta = new System.Data.SqlClient.SqlParameter("fechaHasta", DBNull.Value);

            //    return contexto.Database.SqlQuery<EstadisticaPorTipoPlayaDto>("execute spGetCantidadConsultasPorTipoPlaya @ciudad, @fechaDesde, @fechaHasta", ciudad, fechaDesde, fechaHasta).ToList();
            //}
        }

        public IList<EstadisticaPorTipoVehiculoDto> GetConsultasTipoVehiculoByCiudad(int idCiudad)
        {
            return GetConsultasTipoVehiculoByCiudad(idCiudad, null, null);
        }

        public IList<EstadisticaPorTipoVehiculoDto> GetConsultasTipoVehiculoByCiudad(int idCiudad, DateTime? desde, DateTime? hasta)
        {

            IList<EstadisticaPorTipoVehiculoDto> lista = new List<EstadisticaPorTipoVehiculoDto>();
            SqlConnection sqlConnection1 = new SqlConnection("Data Source=SQL5004.Smarterasp.net;Initial Catalog=DB_9B3453_Geoparking;User Id=DB_9B3453_Geoparking_admin;Password=geoparking");
            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader;

            cmd.CommandText = "spGetCantidadConsultasPorTipoVehiculo";
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Connection = sqlConnection1;

            sqlConnection1.Open();

            reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    lista.Add(new EstadisticaPorTipoVehiculoDto { Fecha = reader.GetInt32(0), Nombre = reader.GetString(1), Cantidad = reader.GetInt32(2) });
                }
            }

            sqlConnection1.Close();
            return lista;

            //using (var contexto = new ContextoBD())
            //{
            //    System.Data.SqlClient.SqlParameter fechaDesde, fechaHasta;

            //    var ciudad = new System.Data.SqlClient.SqlParameter("ciudad", idCiudad);
            //    if (desde.HasValue) fechaDesde = new System.Data.SqlClient.SqlParameter("fechaDesde", desde.Value);
            //    else fechaDesde = new System.Data.SqlClient.SqlParameter("fechaDesde", DBNull.Value);

            //    if (hasta.HasValue) fechaHasta = new System.Data.SqlClient.SqlParameter("fechaHasta", hasta.Value);
            //    else fechaHasta = new System.Data.SqlClient.SqlParameter("fechaHasta", DBNull.Value);

            //    return contexto.Database.SqlQuery<EstadisticaPorTipoVehiculoDto>("execute spGetCantidadConsultasPorTipoVehiculo @ciudad, @fechaDesde, @fechaHasta", ciudad, fechaDesde, fechaHasta).ToList();
            //}
        }

        public IList<EstadisticaDensidadDto> GetConsultasByCiudad(int idCiudad, DateTime? desde, DateTime? hasta)
        {
            using (var contexto = new ContextoBD())
            {
                System.Data.SqlClient.SqlParameter fechaDesde, fechaHasta;

                var ciudad = new System.Data.SqlClient.SqlParameter("ciudad", idCiudad);
                if (desde.HasValue) fechaDesde = new System.Data.SqlClient.SqlParameter("fechaDesde", desde.Value);
                else fechaDesde = new System.Data.SqlClient.SqlParameter("fechaDesde", DBNull.Value);

                if (hasta.HasValue) fechaHasta = new System.Data.SqlClient.SqlParameter("fechaHasta", hasta.Value);
                else fechaHasta = new System.Data.SqlClient.SqlParameter("fechaHasta", DBNull.Value);

                return contexto.Database.SqlQuery<EstadisticaDensidadDto>("execute spGetEstadisticasByFilters @ciudad, @fechaDesde, @fechaHasta", ciudad, fechaDesde, fechaHasta).ToList();
            }
        }


        public IList<EstadisticaDensidadDto> GetConsultasByCiudad(int idCiudad)
        {
            return GetConsultasByCiudad(idCiudad, null, null);
        }
    }



    /// <summary>
    /// Repositorio DAO de administracion de roles y permisos
    /// </summary>
    public class RepositorioRol : Repositorio<Rol>, IRepositorioRol
    {
        public override IList<Rol> FindAll()
        {
            return DbSet
                 .Include("Permisos")
                .ToList();
        }

        public override IList<Rol> FindWhere(Func<Rol, bool> predicate)
        {
            var lista = DbSet
                .Include("Permisos")
                .Where(predicate);

            return lista.ToList();
        }
        public override int Update(Rol t)
        {
            RepositorioPermiso repoPermisos = new RepositorioPermiso();
            using (var contexto = new ContextoBD())
            {
                contexto.UpdateGraph(t, map => map
                    .AssociatedCollection(r => r.Permisos));
                foreach (var permiso in t.Permisos)
                {
                    contexto.UpdateGraph(permiso, map => map
                    .AssociatedCollection(p => p.Roles));
                }
                return contexto.SaveChanges();
            }
        }
    }
    public class RepositorioPermiso : Repositorio<Permiso>, IRepositorioPermiso
    {
        public override IList<Permiso> FindAll()
        {
            return DbSet
                 .Include("Roles")
                .ToList();
        }

        public override IList<Permiso> FindWhere(Func<Permiso, bool> predicate)
        {
            var lista = DbSet
                .Include("Roles")
                .Where(predicate);

            return lista.ToList();
        }
    }

    /// <summary>
    /// Repositorio DAO de las playas de estacionamiento
    /// </summary>
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
                        .AssociatedEntity(s => s.PlayaDeEstacionamiento))
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

