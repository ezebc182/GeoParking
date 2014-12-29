using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using ReglasDeNegocio.Util;
using Datos;
using Newtonsoft.Json;

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
        IRepositorioDisponibilidadPlayas disponibilidadesDao;
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

                    //creo las entradas para manejar las disponibilidades de lugares
                    //de la playas de estacionamiento por cada uno de los tipos de vehiculos
                    disponibilidadesDao = new RepositorioDisponibilidadPlayas();
                    foreach (var item in playa.Servicios)
                    {
                        DisponibilidadPlayas disponibilidad = new DisponibilidadPlayas();
                        disponibilidad.PlayaDeEstacionamientoId = playa.Id;
                        disponibilidad.TipoVehiculoId = item.TipoVehiculoId;
                        disponibilidad.Disponibilidad = item.Capacidad.Cantidad;

                        //creo el registro para el manejo de disponibilidades
                        disponibilidadesDao.Create(disponibilidad);
                    }
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
            //ValidarTiposDeVehiculos(playa, resultado);
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

            //IMPORTANTE: todo esto cambia por que no hay dias atencion por precio y hay un solo horario, reveer

            //var precios = playa.Precios.Select(p => p.DiaAtencionId).Distinct();
            //var horarios = playa.Horario.Select(h => h.DiaAtencionId).Distinct();
            //var contador = 0;
            //if (precios.Count() != horarios.Count())
            //{
            //    if (precios.Count() > horarios.Count()) { resultado.AgregarMensaje("No puede cargar precios para dias en los que no se atiende al publico."); }
            //    else if (precios.Count() < horarios.Count()) { resultado.AgregarMensaje("Debe cargar precios para todos los dias de atencion."); }
            //}
            //else
            //{
            //    foreach (var precio in precios)
            //    {
            //        foreach (var horario in horarios)
            //        {
            //            if (precio == horario)
            //            {
            //                contador++;
            //                break;
            //            }
            //        }
            //    }
            //    if (contador != precios.Count())
            //    {
            //        resultado.AgregarMensaje("No puede cargar precios para dias en los que no se atiende al publico.");
            //        resultado.AgregarMensaje("Debe cargar precios para todos los dias de atencion.");
            //    }
            //}
        }
        /// <summary>
        /// Valida que se hayan ingresado los precios para todos los tipos de vehiculos aceptados y viceversa
        /// </summary>
        /// <param name="playa">playa cuyos datos se estan validando</param>
        /// <param name="resultado">Resultado</param>
        //private void ValidarTiposDeVehiculos(PlayaDeEstacionamiento playa, Resultado resultado)
        //{
        //    var servicios = playa.Servicios.Select(p => p.TipoVehiculoId).Distinct();
        //    var precios = playa.Precios.Select(h => h.TipoVehiculoId).Distinct();
        //    var contador = 0;

        //    if (servicios.Count() != precios.Count())
        //    {
        //        if (servicios.Count() > precios.Count()) { resultado.AgregarMensaje("Debe cargar precios para todos los tipos de vehiculos aceptados."); }
        //        else if (servicios.Count() < precios.Count()) { resultado.AgregarMensaje("Se cargaron precios para vehiculos no aceptados en la playa."); }
        //    }
        //    else
        //    {
        //        foreach (var servicio in servicios)
        //        {
        //            foreach (var precio in precios)
        //            {
        //                if (precio == servicio)
        //                {
        //                    contador++;
        //                    break;
        //                }
        //            }
        //        }
        //        if (contador != precios.Count())
        //        {
        //            resultado.AgregarMensaje("Debe cargar precios para todos los tipos de vehiculos aceptados.");
        //            resultado.AgregarMensaje("Se cargaron precios para vehiculos no aceptados en la playa.");
        //        }
        //    }
        //}
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
            //ValidarTiposDeVehiculos(playa, resultado);
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

            return playa;
        }
        /// <summary>
        /// Busca playas que coincidan con el nombre pasado por parametro
        /// </summary>
        /// <param name="nombre">Nombre de la playa a buscar</param>
        /// <returns>Lista de playas que coinciden con los parametros de busqueda</returns>
        public IList<PlayaDeEstacionamiento> BuscarPlayaPorNombre(string ciudad, string nombre)
        {
            var lista = playaDao.FindWhere(m => m.Direcciones.Any(d => d.Ciudad.Equals(ciudad, StringComparison.OrdinalIgnoreCase))
                && m.Nombre.ToUpper().Contains(nombre.ToUpper()) && !m.FechaBaja.HasValue);

            return lista;
        }

        public string BuscarPlayasPorCiudadJSON(string ciudad)
        {
            return JsonConvert.SerializeObject(BuscarPlayasPorCiudad(ciudad));
        }
        /// <summary>
        /// Carga las direcciones, precios, horarios y servicios de una playa.
        /// </summary>
        /// <param name="playa">playa a la que se le van a cargar los datos.</param>
        private void CargarPlaya(PlayaDeEstacionamiento playa)
        {
            //playa.Direcciones = BuscarDireccionesPorPlaya(playa.Id);
            ////playa.Precios = BuscarPreciosPorPlaya(playa.Id);
            //playa.Horario = BuscarHorariosPorPlaya(playa.Id);
            //playa.Servicios = BuscarServiciosPorPlaya(playa.Id);
            //playa.TipoPlaya = BuscarTipoPlayas().Where(t => t.Id == playa.TipoPlayaId).First();
        }
        /// <summary>
        /// Busca todos los tipos de playas
        /// </summary>
        /// <returns>lista de tipos de playa</returns>
        public IList<TipoPlaya> BuscarTipoPlayas()
        {
            return tipoPlayaDao.FindAll();
        }

        public IList<Tiempo> BuscarTiemposDeAtencion()
        {
            return tiempoDao.FindAll();
        }

        public string BuscarTiemposDeAtencionJSON()
        {
            return JsonConvert.SerializeObject(BuscarTiemposDeAtencion());
        }
        /// <summary>
        /// Busca todos los tipos de vehiculos
        /// </summary>
        /// <returns></returns>
        public IList<TipoVehiculo> BuscarTipoVehiculos()
        {
            return tipoVehiculoDao.FindAll();
        }
        /// <summary>
        /// busca todos los dias de atencion
        /// </summary>
        /// <returns></returns>
        public IList<DiaAtencion> BuscarDiasDeAtencion()
        {
            return diaAtencionDao.FindAll();
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
        //public IList<Precio> BuscarPreciosPorPlaya(int idPlaya)
        //{
        //    var lista =precioDao.FindWhere(d => d.PlayaDeEstacionamientoId == idPlaya);
        //    foreach (var precio in lista)
        //    {
        //        precio.TipoVehiculo = tipoVehiculoDao.FindWhere(t => t.Id == precio.TipoVehiculoId).First();
        //        precio.Tiempo = tiempoDao.FindWhere(t => t.Id == precio.TiempoId).First();
        //    }
        //    return lista;
        //}
        /// <summary>
        /// Busca los horarios de una playa
        /// </summary>
        /// <param name="idPlaya">Id de la playa de la cual se es buscando los horarios</param>
        /// <returns></returns>
        public Horario BuscarHorariosPorPlaya(int idPlaya)
        {
            var horario = horarioDao.FindWhere(d => d.PlayaDeEstacionamientoId == idPlaya).First();

            horario.DiaAtencion = diaAtencionDao.FindWhere(d => d.Id == horario.DiaAtencionId).First();

            return horario;
        }

        /// <summary>
        /// Busca las playas de acuerdo a la ciudad 
        /// </summary>
        /// <param name="ciudad">ciudad donde se ubica la playa</param>
        /// <returns>lista de playas de esa ciudad</returns>
        public IList<PlayaDeEstacionamiento> BuscarPlayasPorCiudad(string ciudad)
        {
            
            var lista = playaDao.FindWhere(p => p.Direcciones.Any(d => d.Ciudad.Equals(ciudad, StringComparison.OrdinalIgnoreCase)) && !p.FechaBaja.HasValue);
           
            return lista;
        }

        public IList<PlayaDeEstacionamiento> BuscarPlayasPorFiltro(string ciudad, int tipoPlaya, int tipoVehiculo, int diasAtencion, decimal precioDesde, decimal precioHasta,
             int horaDesde, int horaHasta)
        {

            Func<PlayaDeEstacionamiento, bool> consulta = p => !p.FechaBaja.HasValue;

            if (!string.IsNullOrEmpty(ciudad))
            {
                consulta.And(p => p.Direcciones.Any(d => d.Ciudad.Equals(ciudad, StringComparison.OrdinalIgnoreCase)));
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
                    consulta = consulta.And(p => p.Horario.DiaAtencionId == diasAtencion);
                }
                else consulta = p => p.Horario.DiaAtencionId == diasAtencion;
            }

            //if (precioDesde != 0)
            //{
            //    if (consulta != null)
            //    {
            //        consulta = consulta.And(p => p.Precios.Any(prec => prec.Monto >= precioDesde));
            //    }
            //    else consulta = p => p.Precios.Any(prec => prec.Monto >= precioDesde);
            //}

            //if (precioHasta != 0)
            //{
            //    if (consulta != null)
            //    {
            //        consulta = consulta.And(p => p.Precios.Any(prec => prec.Monto <= precioHasta));
            //    }
            //    else consulta = p => p.Precios.Any(prec => prec.Monto <= precioHasta);

            //    //lista = (IList<PlayaDeEstacionamiento>)lista.Where(p => p.Precios.Any(prec => prec.Monto <= precioHasta));

            //}

            if (horaDesde != 0)
            {
                if (consulta != null)
                {
                    consulta = consulta.And(p => int.Parse(p.Horario.HoraDesde.Substring(0, 2)) <= horaDesde);
                }
                else consulta = p => int.Parse(p.Horario.HoraDesde.Substring(0, 2)) <= horaDesde;
            }

            if (horaHasta != 0)
            {
                if (consulta != null)
                {
                    consulta = consulta.And(p => int.Parse(p.Horario.HoraHasta.Substring(0, 2)) >= horaHasta);
                }
                else consulta = p => int.Parse(p.Horario.HoraHasta.Substring(0, 2)) >= horaHasta;
            }

            var listaPlayas = playaDao.FindWhere(consulta);

            return listaPlayas;
        }

        /// <summary>
        /// Actualiza el tipo de la playa
        /// </summary>
        /// <param name="idPlaya">id de la playa a modificar</param>
        /// <param name="idTipoPlaya">id del nuevo tipo de la playa</param>
        /// <returns>Objeto resultado configurado de acuerdo a como se realizo la operacion</returns>
        public Resultado ActualizarTipoPlaya(int idPlaya, int idTipoPlaya)
        {
            Resultado resultado = new Resultado();

            try
            {
                PlayaDeEstacionamiento playa = playaDao.FindById(idPlaya);
                playa.TipoPlayaId = idTipoPlaya;
                playaDao.Update(playa);
            }
            catch (Exception)
            {
                resultado.AgregarMensaje("Se ha producido un error en la Base de Datos");
            }

            return resultado;
        }

        /// <summary>
        /// Actualiza el Nombre y el Email de la playa
        /// </summary>
        /// <param name="idPlaya">id de la playa a modificar</param>
        /// <param name="nombrePlaya">nuevo nombre de la playa</param>
        /// <param name="emailPlaya">nuevo email de la playa</param>
        /// <returns>Objeto resultado configurado de acuerdo a como se realizo la operacion</returns>
        public Resultado ActualizarNombreEmailPlaya(int idPlaya, string nombrePlaya, string emailPlaya)
        {
            Resultado resultado = new Resultado();

            try
            {
                PlayaDeEstacionamiento playa = playaDao.FindById(idPlaya);
                playa.Nombre=nombrePlaya;
                playa.Mail = emailPlaya;
                playaDao.Update(playa);
            }
            catch (Exception)
            {
                resultado.AgregarMensaje("Se ha producido un error en la Base de Datos");
            }

            return resultado;
        }

        /// <summary>
        /// Actualiza el horario de la playa
        /// </summary>
        /// <param name="idPlaya">id de la playa a modificar</param>
        /// <param name="idDiaAtencion">id del nuevo dia de atencion</param>
        /// <param name="horaDesde">nueva hora de apertura</param>
        /// <param name="horaHasta">nueva hora de cierre</param>
        /// <returns>Objeto resultado configurado de acuerdo a como se realizo la operacion</returns>
        public Resultado ActualizarHorarioPlaya(int idPlaya, int idDiaAtencion, string horaDesde, string horaHasta)
        {
            Resultado resultado = new Resultado();

            try
            {
                PlayaDeEstacionamiento playa = playaDao.FindById(idPlaya);

                Horario horario = playa.Horario;
                horario.DiaAtencionId = idDiaAtencion;
                horario.HoraDesde = horaDesde;
                horario.HoraHasta = horaHasta;

                playa.Horario = horario;
                playaDao.Update(playa);
            }
            catch (Exception)
            {
                resultado.AgregarMensaje("Se ha producido un error en la Base de Datos");
            }

            return resultado;
        }
    }
}
