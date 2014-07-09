using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using RefactorThis.GraphDiff;

namespace Datos
{
    //interfaces que implementan la interface IRepositorio 
    public interface IRepositorioPlayaDeEstacionamiento : IRepositorio<PlayaDeEstacionamiento> { }
    public interface IRepositorioTipoDePlaya : IRepositorio<TipoPlaya> { }
    public interface IRepositorioTipoVehiculo : IRepositorio<TipoVehiculo> { }
    public interface IRepositorioServicio : IRepositorio<Servicio> { }
    public interface IRepositorioDireccion : IRepositorio<Direccion> { }
    public interface IRepositorioHorario : IRepositorio<Horario> { }
    public interface IRepositorioPrecio : IRepositorio<Precio> { }
    public interface IRepositorioDiaAtencion : IRepositorio<DiaAtencion> { }
    public interface IRepositorioTiempo : IRepositorio<Tiempo> { }
    public interface IRepositorioCiudad : IRepositorio<Ciudad> { }
    public interface IRepositorioDepartamento : IRepositorio<Departamento> { }
    public interface IRepositorioProvincia : IRepositorio<Provincia> { }

    //Clases DAO para cada entidad que heredan de la clase Repositorio
    public class RepositorioTipoDePlaya : Repositorio<TipoPlaya>, IRepositorioTipoDePlaya { }
    public class RepositorioTipoVehiculo : Repositorio<TipoVehiculo>, IRepositorioTipoVehiculo { }
    public class RepositorioServicio : Repositorio<Servicio>, IRepositorioServicio { }
    public class RepositorioDireccion : Repositorio<Direccion>, IRepositorioDireccion { }
    public class RepositorioHorario : Repositorio<Horario>, IRepositorioHorario { }
    public class RepositorioPrecio : Repositorio<Precio>, IRepositorioPrecio { }
    public class RepositorioDiaAtencion : Repositorio<DiaAtencion>, IRepositorioDiaAtencion { }
    public class RepositorioTiempo : Repositorio<Tiempo>, IRepositorioTiempo { }
    public class RepositorioCiudad : Repositorio<Ciudad>, IRepositorioCiudad { }
    public class RepositorioDepartamento : Repositorio<Departamento>, IRepositorioDepartamento { }
    public class RepositorioProvincia : Repositorio<Provincia>, IRepositorioProvincia { }

    public class RepositorioPlayaDeEstacionamiento : Repositorio<PlayaDeEstacionamiento>, IRepositorioPlayaDeEstacionamiento 
    { 

        public override int Update(PlayaDeEstacionamiento t)
        {
            var entry = contexto.Entry(t);
            if (entry.State == System.Data.Entity.EntityState.Detached)
            {
                contexto.UpdateGraph(t, map => map
                    .OwnedCollection(p => p.Direcciones, with => with
                        .AssociatedEntity(d => d.PlayaDeEstacionamiento))
                    .OwnedCollection(p => p.Horarios, with => with
                    .AssociatedEntity(h => h.PlayaDeEstacionamiento))
                    .OwnedCollection(p => p.Precios, with => with
                    .AssociatedEntity(p => p.PlayaDeEstacionamiento))
                    .OwnedCollection(p => p.Servicios, with => with
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

