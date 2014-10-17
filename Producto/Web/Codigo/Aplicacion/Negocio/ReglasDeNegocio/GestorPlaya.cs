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
        GestorDireccion gestorDireccion;
        IRepositorioPlayaDeEstacionamiento playaDao;
        IRepositorioTipoDePlaya tipoPlayaDao;
        IRepositorioTiempo tiempoDao;
        IRepositorioDiaAtencion diaAtencionDao;
        IRepositorioTipoVehiculo tipoVehiculoDao;
        IRepositorioHorario horarioDao;
        IRepositorioServicio servicioDao;
        IRepositorioPrecio precioDao;
        IRepositorioDireccion direccionDao;
        /// <summary>
        /// Constructor 
        /// </summary>
        public GestorPlaya()
        {
            gestorDireccion = new GestorDireccion();
            tipoVehiculoDao = new RepositorioTipoVehiculo();
            playaDao = new RepositorioPlayaDeEstacionamiento();
            tipoPlayaDao = new RepositorioTipoDePlaya();
            diaAtencionDao = new RepositorioDiaAtencion();
            horarioDao = new RepositorioHorario();
            servicioDao = new RepositorioServicio();
            precioDao = new RepositorioPrecio();
            tiempoDao = new RepositorioTiempo();
        }
        /// <summary>
        /// Constructor utilizado en unit test
        /// </summary>
        /// <param name="playaDao"></param>
        /// <param name="tipoPlayaDao"></param>
        /// <param name="diaAtencionDao"></param>
        /// <param name="tipoVehiculoDao"></param>
        /// <param name="horarioDao"></param>
        /// <param name="servicioDao"></param>
        /// <param name="precioDao"></param>
        public GestorPlaya(IRepositorioPlayaDeEstacionamiento playaDao,
            IRepositorioTipoDePlaya tipoPlayaDao,
            IRepositorioDiaAtencion diaAtencionDao,
            IRepositorioTipoVehiculo tipoVehiculoDao,
            IRepositorioHorario horarioDao,
            IRepositorioServicio servicioDao,
            IRepositorioPrecio precioDao,
            GestorDireccion gestorDireccion)
        {
            this.gestorDireccion = gestorDireccion;
            this.playaDao = playaDao;
            this.tipoPlayaDao = tipoPlayaDao;
            this.diaAtencionDao = diaAtencionDao;
            this.tipoVehiculoDao = tipoVehiculoDao;
            this.horarioDao = horarioDao;
            this.servicioDao = servicioDao;
            this.precioDao = precioDao;
        }

        /// <summary>
        /// Valida los datos de la playa, y de ser correctos la registra.
        /// </summary>
        /// <param name="playa">playa a registrar</param>
        /// <returns>Resultado</returns>
        public Resultado RegistrarPlaya(PlayaDeEstacionamiento playa)
        {
            var resultado = ValidarRegistracion(playa);

            if (resultado.Ok)
            {
                try
                {
                    playaDao.Create(playa);
                }
                catch (DataBaseException e)
                {
                    resultado.AgregarMensaje("Se ha producido un error de base de datos");
                }
            }

            return resultado;
        }
        /// <summary>
        /// Valida los datos de la playa para registrarla
        /// </summary>
        /// <param name="playa">playa que se esta registrando</param>
        /// <returns>Resultado</returns>
        private Resultado ValidarRegistracion(PlayaDeEstacionamiento playa)
        {
            var resultado = new Resultado();

            ValidarDatosGrales(playa, resultado);
            ValidarDiasDeAtencion(playa, resultado);
            ValidarTiposDeVehiculos(playa, resultado);
            ValidarDirecciones(playa, resultado);

            return resultado;
        }

        /// <summary>
        /// Valida que se hayan ingresado todos los datos generales de manera correcta.
        /// </summary>
        /// <param name="playa">Playa cuyos datos se quieren validar</param>
        /// <param name="resultado">Resultado</param>
        private void ValidarDatosGrales(PlayaDeEstacionamiento playa, Resultado resultado)
        {
            if (string.IsNullOrEmpty(playa.Nombre) || ((string.IsNullOrEmpty(playa.Mail) || string.IsNullOrEmpty(playa.Telefono)) || ((string.IsNullOrEmpty(playa.Mail) && string.IsNullOrEmpty(playa.Telefono)))) || playa.TipoPlayaId == 0)
            {
                resultado.AgregarMensaje("Debe ingresar todos los datos de la playa.");
            }

        }
        /// <summary>
        /// Valida que se hayan ingresado los precios para los dias de atencion y viceversa
        /// </summary>
        /// <param name="playa">playa cuyos datos se estan validando</param>
        /// <param name="resultado">Resultado</param>
        private void ValidarDiasDeAtencion(PlayaDeEstacionamiento playa, Resultado resultado)
        {

            var precios = playa.Precios.Select(p => p.DiaAtencionId).Distinct();
            var horarios = playa.Horarios.Select(h => h.DiaAtencionId).Distinct();
            var contador = 0;
            if (precios.Count() != horarios.Count())
            {
                if (precios.Count() > horarios.Count()) { resultado.AgregarMensaje("No puede cargar precios para dias en los que no se atiende al publico."); }
                else if (precios.Count() < horarios.Count()) { resultado.AgregarMensaje("Debe cargar precios para todos los dias de atencion."); }
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
                    resultado.AgregarMensaje("No puede cargar precios para dias en los que no se atiende al publico.");
                    resultado.AgregarMensaje("Debe cargar precios para todos los dias de atencion.");
                }
            }
        }
        /// <summary>
        /// Valida que se hayan ingresado los precios para todos los tipos de vehiculos aceptados y viceversa
        /// </summary>
        /// <param name="playa">playa cuyos datos se estan validando</param>
        /// <param name="resultado">Resultado</param>
        private void ValidarTiposDeVehiculos(PlayaDeEstacionamiento playa, Resultado resultado)
        {
            var servicios = playa.Servicios.Select(p => p.TipoVehiculoId).Distinct();
            var precios = playa.Precios.Select(h => h.TipoVehiculoId).Distinct();
            var contador = 0;

            if (servicios.Count() != precios.Count())
            {
                if (servicios.Count() > precios.Count()) { resultado.AgregarMensaje("Debe cargar precios para todos los tipos de vehiculos aceptados."); }
                else if (servicios.Count() < precios.Count()) { resultado.AgregarMensaje("Se cargaron precios para vehiculos no aceptados en la playa."); }
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
                    resultado.AgregarMensaje("Debe cargar precios para todos los tipos de vehiculos aceptados.");
                    resultado.AgregarMensaje("Se cargaron precios para vehiculos no aceptados en la playa.");
                }
            }
        }
        /// <summary>
        /// Valida que se haya ingresado al menos una direccion con sus respectivo punto en el mapa
        /// </summary>
        /// <param name="playa">Playa cuyos datos se estan validando</param>
        /// <param name="resultado">Resultado</param>
        private void ValidarDirecciones(PlayaDeEstacionamiento playa, Resultado resultado)
        {
            foreach (var direccion in playa.Direcciones)
            {
                if (!String.IsNullOrEmpty(direccion.Longitud) && !String.IsNullOrEmpty(direccion.Latitud))
                {
                    return;
                }
            }
            resultado.AgregarMensaje("Debe indicar al menos una direccion en el mapa.");
        }
        /// <summary>
        /// Actualiza los datos de una playa
        /// </summary>
        /// <param name="playa">Playa que se esta actualizando</param>
        /// <returns>Resultado</returns>
        public Resultado ActualizarPlaya(PlayaDeEstacionamiento playa)
        {
            var resultado = ValidarActualizacion(playa);

            if (resultado.Ok)
            {
                try
                {
                    playaDao.Update(playa);
                }
                catch (DataBaseException e)
                {
                    resultado.AgregarMensaje("Se ha producido un error de base de datos.");
                }
            }
            return resultado;
        }
        /// <summary>
        /// Valida los datos de la playa que se esta actualizando
        /// </summary>
        /// <param name="playa">playa a validar</param>
        /// <returns>Resultado</returns>
        private Resultado ValidarActualizacion(PlayaDeEstacionamiento playa)
        {
            var resultado = new Resultado();

            ValidarDatosGrales(playa, resultado);
            ValidarDiasDeAtencion(playa, resultado);
            ValidarTiposDeVehiculos(playa, resultado);
            ValidarDirecciones(playa, resultado);

            return resultado;
        }
        /// <summary>
        /// Elimina una playa
        /// </summary>
        /// <param name="idPlaya">Id de la playa a eliminar</param>
        /// <returns>Resultado</returns>
        public Resultado EliminarPlaya(int idPlaya)
        {
            var resultado = ValidarEliminacion();

            if (resultado.Ok)
            {
                try
                {
                    playaDao.Delete(m => m.Id == idPlaya);
                }
                catch (DataBaseException e)
                {
                    resultado.AgregarMensaje("Se ha producido un error de base de datos.");
                }
            }

            return resultado;
        }
        /// <summary>
        /// Validaciones necesarias para eliminar una playa
        /// </summary>
        /// <returns></returns>
        private Resultado ValidarEliminacion()
        {
            var resultado = new Resultado();

            //Agregar validaciones

            return resultado;
        }

        /// <summary>
        /// Busca una playa por un id
        /// </summary>
        /// <param name="idPlaya">Id de la playa a buscar</param>
        /// <returns>PlayaDeEstacionamiento</returns>
        public PlayaDeEstacionamiento BuscarPlayaPorId(int idPlaya)
        {
            var playa = playaDao.FindById(idPlaya);
            CargarPlaya(playa);
            return playa;
        }
        /// <summary>
        /// Busca playas que coincidan con el nombre pasado por parametro
        /// </summary>
        /// <param name="nombre">Nombre de la playa a buscar</param>
        /// <returns>Lista de playas que coinciden con los parametros de busqueda</returns>
        public IList<PlayaDeEstacionamiento> BuscarPlayaPorNombre(string nombre)
        {
            var lista = playaDao.FindWhere(m => m.Nombre.Contains(nombre) && !m.FechaBaja.HasValue);

            //foreach (var playa in lista)
            //{
            //    CargarPlaya(playa);
            //}
            return lista;
        }
        /// <summary>
        /// Carga las direcciones, precios, horarios y servicios de una playa.
        /// </summary>
        /// <param name="playa">playa a la que se le van a cargar los datos.</param>
        private void CargarPlaya(PlayaDeEstacionamiento playa)
        {
            playa.Direcciones = BuscarDireccionesPorPlaya(playa.Id);
            playa.Precios = BuscarPreciosPorPlaya(playa.Id);
            playa.Horarios = BuscarHorariosPorPlaya(playa.Id);
            playa.Servicios = BuscarServiciosPorPlaya(playa.Id);
            playa.TipoPlaya = BuscarTipoPlayas().Where(t => t.Id == playa.TipoPlayaId).First();
        }
        /// <summary>
        /// Busca todos los tipos de playas
        /// </summary>
        /// <returns>lista de tipos de playa</returns>
        public IList<TipoPlaya> BuscarTipoPlayas()
        {
            return tipoPlayaDao.FindAll();
        }
        /// <summary>
        /// Busca las direcciones de una playa
        /// </summary>
        /// <param name="idPlaya">Id de la playa de la cual se esta buscando las direcciones</param>
        /// <returns></returns>
        public IList<Direccion> BuscarDireccionesPorPlaya(int idPlaya)
        {
            return gestorDireccion.BuscarDireccionesPorPlaya(idPlaya);
        }
        /// <summary>
        /// Busca los servicios de una playa
        /// </summary>
        /// <param name="idPlaya">Id de la playa de la cual se esta buscando los servicios</param>
        /// <returns></returns>
        public IList<Servicio> BuscarServiciosPorPlaya(int idPlaya)
        {
            var lista = servicioDao.FindWhere(d => d.PlayaDeEstacionamientoId == idPlaya);
            foreach (var servicio in lista)
            {
                servicio.TipoVehiculo = tipoVehiculoDao.FindWhere(tv => tv.Id == servicio.TipoVehiculoId).First();
            }

            return lista;
        }

        /// <summary>
        /// Busca los precios de una playa
        /// </summary>
        /// <param name="idPlaya">Id de la playa de la cual se esta buscando los precios</param>
        /// <returns></returns>
        public IList<Precio> BuscarPreciosPorPlaya(int idPlaya)
        {
            var lista =precioDao.FindWhere(d => d.PlayaDeEstacionamientoId == idPlaya);
            foreach (var precio in lista)
            {
                precio.DiaAtencion = diaAtencionDao.FindWhere(d => d.Id == precio.DiaAtencionId).First();
                precio.TipoVehiculo = tipoVehiculoDao.FindWhere(t => t.Id == precio.TipoVehiculoId).First();
                precio.Tiempo = tiempoDao.FindWhere(t => t.Id == precio.TiempoId).First();
            }
            return lista;
        }
        /// <summary>
        /// Busca los horarios de una playa
        /// </summary>
        /// <param name="idPlaya">Id de la playa de la cual se es buscando los horarios</param>
        /// <returns></returns>
        public IList<Horario> BuscarHorariosPorPlaya(int idPlaya)
        {
            var lista = horarioDao.FindWhere(d => d.PlayaDeEstacionamientoId == idPlaya);
            foreach(var horario in lista)
            {
                horario.DiaAtencion = diaAtencionDao.FindWhere(d => d.Id == horario.DiaAtencionId).First();
            }
            return lista;
        }

        /// <summary>
        /// Busca las playas de acuerdo a la ciudad 
        /// </summary>
        /// <param name="ciudad">ciudad donde se ubica la playa</param>
        /// <returns>lista de playas de esa ciudad</returns>
        public IList<PlayaDeEstacionamiento> BuscarPlayasPorCiudad(string ciudad)
        {
            //aca va un findwehere
            
            var lista= playaDao.FindWhere(p => p.Direcciones.Any(d => d.Ciudad.Nombre.Equals(ciudad, StringComparison.OrdinalIgnoreCase)) && !p.FechaBaja.HasValue);
            
            return lista;
        }

        public IList<PlayaDeEstacionamiento> BuscarPlayasPorFiltro(string ciudad, int tipoPlaya, int tipoVehiculo, int diasAtencion, decimal precioDesde, decimal precioHasta,
             int horaDesde, int horaHasta)
        {

            Func<PlayaDeEstacionamiento, bool> consulta = p => !p.FechaBaja.HasValue;

            if (!string.IsNullOrEmpty(ciudad))
            {
                consulta.And(p => p.Direcciones.Any(d => d.Ciudad.Nombre.Equals(ciudad, StringComparison.OrdinalIgnoreCase)));
            }
            
            if (tipoPlaya != 0)
            {
                if (consulta != null)
                {
                    consulta = consulta.And(p => p.TipoPlayaId == tipoPlaya);
                }
                else consulta = p => p.TipoPlayaId == tipoPlaya;
                }

            if (tipoVehiculo != 0)
            {
                if (consulta != null)
                {
                    consulta = consulta.And(p => p.Servicios.Any(s => s.TipoVehiculoId == tipoVehiculo));
                }
                else consulta = p => p.Servicios.Any(s => s.TipoVehiculoId == tipoVehiculo);
                }

            if (diasAtencion != 0)
            {
                if (consulta != null)
                {
                    consulta = consulta.And(p => p.Horarios.Any(h => h.DiaAtencionId == diasAtencion));
                }
                else consulta = p => p.Horarios.Any(h => h.DiaAtencionId == diasAtencion);
                }

            if (precioDesde != 0)
            {
                if (consulta != null)
                {
                    consulta = consulta.And(p => p.Precios.Any(prec => prec.Monto >= precioDesde));
                }
                else consulta = p => p.Precios.Any(prec => prec.Monto >= precioDesde);
                }

            if (precioHasta != 0)
            {
                if (consulta != null)
                {
                    consulta = consulta.And(p => p.Precios.Any(prec => prec.Monto <= precioHasta));
                }
                else consulta = p => p.Precios.Any(prec => prec.Monto <= precioHasta);

                //lista = (IList<PlayaDeEstacionamiento>)lista.Where(p => p.Precios.Any(prec => prec.Monto <= precioHasta));

            }

            if (horaDesde != 0)
            {
                if (consulta != null)
                {
                    consulta = consulta.And(p => p.Horarios.Any(h => int.Parse(h.HoraDesde.Substring(0, 2)) <= horaDesde));
                }
                else consulta = p => p.Horarios.Any(h => int.Parse(h.HoraDesde.Substring(0, 2)) <= horaDesde);
            }

            if (horaHasta != 0)
            {
                if (consulta != null)
                {
                    consulta = consulta.And(p => p.Horarios.Any(h => int.Parse(h.HoraHasta.Substring(0, 2)) >= horaHasta));
                }
                else consulta = p => p.Horarios.Any(h => int.Parse(h.HoraHasta.Substring(0, 2)) >= horaHasta);
            }

            var listaPlayas = playaDao.FindWhere(consulta);

            return listaPlayas;
        }
    }
}
