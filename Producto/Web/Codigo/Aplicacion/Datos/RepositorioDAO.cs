using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;

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
    public class RepositorioPlayaDeEstacionamiento : Repositorio<PlayaDeEstacionamiento>, IRepositorioPlayaDeEstacionamiento { }
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
    
}
