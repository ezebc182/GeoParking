using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using ReglasDeNegocio.Util;
using Datos;

namespace ReglasDeNegocio
{
    public class GestorPlaya
    {
        IRepositorioPlayaDeEstacionamiento playaDao;
        IRepositorioTipoDePlaya tipoPlayaDao;
        IRepositorioDiaAtencion diaAtencionDao;
        IRepositorioTipoVehiculo tipoVehiculoDao;
        IRepositorioDireccion direccionDao;
        IRepositorioHorario horarioDao;
        IRepositorioServicio servicioDao;
        IRepositorioPrecio precioDao;

        public GestorPlaya()
        {
            tipoVehiculoDao = new RepositorioTipoVehiculo();
            playaDao = new RepositorioPlayaDeEstacionamiento();
            tipoPlayaDao = new RepositorioTipoDePlaya();
            diaAtencionDao = new RepositorioDiaAtencion();
            direccionDao = new RepositorioDireccion();
            horarioDao = new RepositorioHorario();
            servicioDao = new RepositorioServicio();
            precioDao = new RepositorioPrecio();
        }

        public GestorPlaya(IRepositorioPlayaDeEstacionamiento repositorioPlaya, IRepositorioTipoDePlaya repositorioTipoPlaya)
        {
            playaDao = repositorioPlaya;
            tipoPlayaDao = repositorioTipoPlaya;
        }


        public Resultado RegistrarPlaya(PlayaDeEstacionamiento playa)
        {
            var resultado = ValidarRegistracion(playa);

            if (resultado.Ok)
            {
                playaDao.Create(playa);
            }

            return resultado;
        }

        private Resultado ValidarRegistracion(PlayaDeEstacionamiento playa)
        {
            var resultado = new Resultado();
            ValidarDatosGrales(playa, resultado);
            ValidarDiasDeAtencion(playa, resultado);
            ValidarTiposDeVehiculos(playa, resultado);
            ValidarDirecciones(playa, resultado);

            return resultado;
        }


        private void ValidarDatosGrales(PlayaDeEstacionamiento playa, Resultado resultado)
        {
            if (string.IsNullOrEmpty(playa.Nombre) || ((string.IsNullOrEmpty(playa.Mail) || string.IsNullOrEmpty(playa.Telefono)) || ((string.IsNullOrEmpty(playa.Mail) && string.IsNullOrEmpty(playa.Telefono)))) || playa.TipoPlayaId == 0)
            {
                resultado.AddErrorMessage("Debe ingresar todos los datos de la playa.");
            }
            
        }

        private void ValidarDiasDeAtencion(PlayaDeEstacionamiento playa, Resultado resultado)
        {
            var precios = playa.Precios.Select(p => p.DiaAtencionId).Distinct();
            var horarios = playa.Horarios.Select(h => h.DiaAtencionId).Distinct();
            var contador = 0;
            if (precios.Count() != horarios.Count())
            {
                if (precios.Count() > horarios.Count()) { resultado.AddErrorMessage("No puede cargar precios para dias en los que no se atiende al publico."); }
                else if (precios.Count() < horarios.Count()) { resultado.AddErrorMessage("Debe cargar precios para todos los dias de atencion."); }
            }
            else
            {
                foreach (var precio in precios)
                {
                    foreach (var horario in horarios)
                    {
                        if (precio == horario)
                        {
                            contador++;
                            break;
                        }
                    }
                }
                if (contador != precios.Count())
                {
                    resultado.AddErrorMessage("Debe cargar precios para todos los horarios de atencion indicados.");
                }
            }
        }
        private void ValidarTiposDeVehiculos(PlayaDeEstacionamiento playa, Resultado resultado)
        {
            var servicios = playa.Servicios.Select(p => p.TipoVehiculoId).Distinct();
            var precios = playa.Precios.Select(h => h.TipoVehiculoId).Distinct();
            var contador = 0;

            if (servicios.Count() != precios.Count())
            {
                if (servicios.Count() > precios.Count()) { resultado.AddErrorMessage("Debe cargar precios para todos los tipos de vehiculos aceptados."); }
                else if (servicios.Count() < precios.Count()) { resultado.AddErrorMessage("Se cargaron precios para vehiculos no aceptados en la playa."); }
            }
            else
            {
                foreach (var servicio in servicios)
                {
                    foreach (var precio in precios)
                    {
                        if (precio == servicio)
                        {
                            contador++;
                            break;
                        }
                    }
                }
                if (contador != precios.Count())
                {
                    resultado.AddErrorMessage("Debe cargar precios para todos los Tipos de vehiculos aceptados por la playa.");
                }
            }
        }
        private void ValidarDirecciones(PlayaDeEstacionamiento playa, Resultado resultado)
        {
            foreach (var direccion in playa.Direcciones)
            {
                if (!String.IsNullOrEmpty(direccion.Longitud) && !String.IsNullOrEmpty(direccion.Latitud))
                {
                    return;
                }
            }
            resultado.AddErrorMessage("Debe indicar al menos una direccion en el mapa.");
        }

        public Resultado ActualizarPlaya(PlayaDeEstacionamiento playa)
        {
            var resultado = ValidarActualizacion(playa);

            if (resultado.Ok)
            {
                playaDao.Update(playa);

            }
            return resultado;
        }


        private Resultado ValidarActualizacion(PlayaDeEstacionamiento playa)
        {
            var resultado = new Resultado();

            ValidarDatosGrales(playa, resultado);
            ValidarDiasDeAtencion(playa, resultado);
            ValidarTiposDeVehiculos(playa, resultado);
            ValidarDirecciones(playa, resultado);

            return resultado;
        }

        public Resultado EliminarPlaya(int idPlaya)
        {
            var resultado = ValidarEliminacion();

            if (resultado.Ok)
            {
                playaDao.Delete(m => m.Id == idPlaya);
            }

            return resultado;
        }

        private Resultado ValidarEliminacion()
        {
            var resultado = new Resultado();

            //Agregar validaciones

            return resultado;
        }


        public PlayaDeEstacionamiento BuscarPlayaPorId(int idPlaya)
        {
            var playa = playaDao.FindById(idPlaya);
            CargarPlaya(playa);
            return playa;
        }

        public IList<PlayaDeEstacionamiento> BuscarPlayaPorNombre(string nombre)
        {
            var lista = playaDao.FindWhere(m => m.Nombre.Contains(nombre) && !m.FechaBaja.HasValue);

            foreach (var playa in lista)
            {
                CargarPlaya(playa);
            }
            return lista;
        }

        private void CargarPlaya(PlayaDeEstacionamiento playa)
        {
            playa.Direcciones = BuscarDireccionesPorPlaya(playa.Id);
            playa.Precios = BuscarPreciosPorPlaya(playa.Id);
            playa.Horarios = BuscarHorariosPorPlaya(playa.Id);
            playa.Servicios = BuscarServiciosPorPlaya(playa.Id);
        }
        public IList<TipoPlaya> BuscarTipoPlayas()
        {
            return tipoPlayaDao.FindAll();
        }
        public IList<TipoVehiculo> BuscarTipoVehiculos()
        {
            return tipoVehiculoDao.FindAll();
        }
        public TipoVehiculo BuscarTipoVehiculo(int id)
        {
            return tipoVehiculoDao.FindById(id);
        }
        public DiaAtencion GetDiaAtencionById(int IdDiaAtencionSeleccionado)
        {
            return diaAtencionDao.FindById(IdDiaAtencionSeleccionado);
        }
        public IList<DiaAtencion> BuscarDiasDeAtencion()
        {
            return diaAtencionDao.FindAll();
        }

        public IList<Direccion> BuscarDireccionesPorPlaya(int idPlaya)
        {
            return new GestorDireccion().BuscarDireccionesPorPlaya(idPlaya);
        }

        public IList<Servicio> BuscarServiciosPorPlaya(int idPlaya)
        {
            return servicioDao.FindWhere(d => d.PlayaDeEstacionamientoId == idPlaya);
        }

        public IList<Precio> BuscarPreciosPorPlaya(int idPlaya)
        {
            return precioDao.FindWhere(d => d.PlayaDeEstacionamientoId == idPlaya);
        }

        public IList<Horario> BuscarHorariosPorPlaya(int idPlaya)
        {
            return horarioDao.FindWhere(d => d.PlayaDeEstacionamientoId == idPlaya);
        }
    }
}
