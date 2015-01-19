using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;
using Entidades;
using ReglasDeNegocio.Util;

namespace ReglasDeNegocio
{
    public class GestorDisponibilidad
    {
        IRepositorioDisponibilidadPlayas disponibilidadPlayas;
        IRepositorioHistorialDisponibilidadPlayas historialDisponibilidadPlayas;
        IRepositorioServicio servicioDAO;

        public GestorDisponibilidad()
        {
            disponibilidadPlayas = new RepositorioDisponibilidadPlayas();
            historialDisponibilidadPlayas = new RepositorioHistorialDisponibilidadPlayas();
            servicioDAO = new RepositorioServicio();
        }

        /// <summary>
        /// Actualiza la disponibilidad de la playa y ademas se registra dicho movimiento
        /// en el historial de las disponibilidades de las playas de estacionamiento
        /// </summary>
        /// <param name="playa">playa de estacionamiento</param>
        /// <param name="tipoVehiculo">tipo de vehiculo que ingreso o salio</param>
        /// <param name="evento">ingreso o egreso de vehiculo</param>
        /// <param name="fechaHora">fecha y hora</param>
        /// <param name="dia">dia(L,M,MM,J,V,S,D)</param>
        public Resultado ActualizarDisponibilidadPlaya(int playa, int tipoVehiculo, int evento, DateTime fechaHora, int dia)
        {
            Resultado resultado = new Resultado();

            //creamos el nuevo registro para el historial
            HistorialDisponibilidadPlayas registroHistorial = new HistorialDisponibilidadPlayas();
            registroHistorial.PlayaDeEstacionamietoId = playa;
            registroHistorial.TipoVehiculoId = tipoVehiculo;
            registroHistorial.EventoId = evento;
            registroHistorial.FechaHora = fechaHora;
            registroHistorial.Dia = dia;

            //lo insertamos en la BD
            historialDisponibilidadPlayas.Create(registroHistorial);

            //ahora actualizamos la disponibilidad
            //1° recuperamos el resgistro de la BD a actualizar
            //DisponibilidadPlayas registroDisponibilidad = new DisponibilidadPlayas();
            //registroDisponibilidad = disponibilidadPlayas.FindWhere(d => d.Servicio.PlayaDeEstacionamientoId == playa && d.Servicio.TipoVehiculoId == tipoVehiculo).First();

            Servicio servicio = servicioDAO.FindWhere(s => s.PlayaDeEstacionamientoId == playa && s.TipoVehiculoId == tipoVehiculo).First();

            //2° verificamos el evento
            if (evento == 1) //ingreso
            {
                servicio.DisponibilidadPlayas.Disponibilidad = servicio.DisponibilidadPlayas.Disponibilidad - 1;
            }
            else //egreso
            {
                servicio.DisponibilidadPlayas.Disponibilidad = servicio.DisponibilidadPlayas.Disponibilidad + 1;
            }

            try
            {
                //3° actualizamos el registro
                //servicioDao.Update(registroDisponibilidad);
                servicioDAO.Update(servicio);
            }
            catch (Exception)
            {
                resultado.AgregarMensaje("Se ha producido un error de base de datos.");
            }

            return resultado;

        }


        public Resultado ActualizarDisponibilidadGeneralPlaya(int playa, int tipoVehiculo, int disponibilidad, int evento, DateTime fechaHora, int dia)
        {
            Resultado resultado = new Resultado();

            //creamos el nuevo registro para el historial
            HistorialDisponibilidadPlayas registroHistorial = new HistorialDisponibilidadPlayas();
            registroHistorial.PlayaDeEstacionamietoId = playa;
            registroHistorial.TipoVehiculoId = tipoVehiculo;
            registroHistorial.EventoId = evento;
            registroHistorial.FechaHora = fechaHora;
            registroHistorial.Dia = dia;

            //lo insertamos en la BD
            historialDisponibilidadPlayas.Create(registroHistorial);

            //ahora actualizamos la disponibilidad
            //1° recuperamos el resgistro de la BD a actualizar
            //DisponibilidadPlayas registroDisponibilidad = new DisponibilidadPlayas();
            //registroDisponibilidad = disponibilidadPlayas.FindWhere(d => d.Servicio.PlayaDeEstacionamientoId == playa && d.Servicio.TipoVehiculoId == tipoVehiculo).First();

            Servicio servicio = servicioDAO.FindWhere(s => s.PlayaDeEstacionamientoId == playa && s.TipoVehiculoId == tipoVehiculo).First();

            servicio.DisponibilidadPlayas.Disponibilidad = disponibilidad;

            //registroDisponibilidad.Disponibilidad = disponibilidad;

            try
            {
                //3° actualizamos el registro
                //disponibilidadPlayas.Update(registroDisponibilidad);
                servicioDAO.Update(servicio);
            }
            catch (Exception)
            {
                resultado.AgregarMensaje("Se ha producido un error de base de datos.");
            }

            return resultado;

        }


        /// <summary>
        /// retorna la disponibilidad de una playa de estacionamiento
        /// y de acuerdo al tipo vehiculo del que quiera saber la disponibilidad
        /// de lugares
        /// </summary>
        /// <param name="playa">playa de estacionamiento</param>
        /// <param name="tipoVehiculo">tipo vehiculo</param>
        /// <returns></returns>
        public int GetDisponibilidadPlayaPorTipoVehiculo(int playa, int tipoVehiculo)
        {
            var servicio = GetServicioPorPlayaYTipoVehiculo(playa, tipoVehiculo);
            return disponibilidadPlayas.FindWhere(d => d.ServicioId == servicio.Id).First().Disponibilidad;
        }
        /// <summary>
        /// retorna el servicio asociado a la playa y tipovehiculo pasados por parametro
        /// </summary>
        /// <param name="playa"></param>
        /// <param name="tipoVehiculo"></param>
        /// <returns></returns>
        public Servicio GetServicioPorPlayaYTipoVehiculo(int playa, int tipoVehiculo)
        {
            return servicioDAO.FindWhere(s => s.PlayaDeEstacionamientoId == playa && s.TipoVehiculoId == tipoVehiculo).FirstOrDefault();
        }

        /// <summary>
        /// retorna los servicios asociados a las playas y tipovehiculo pasados por parametro
        /// </summary>
        /// <param name="playa"></param>
        /// <param name="tipoVehiculo"></param>
        /// <returns></returns>
        public IList<Servicio> GetServiciosPorPlayasYTipoVehiculo(int[] playas, int tipoVehiculo)
        {
            return servicioDAO.FindWhere(s => playas.Any(x => x == s.PlayaDeEstacionamientoId) && s.TipoVehiculoId == tipoVehiculo).ToList();
        }

        /// <summary>
        /// retorna las disponibilidades de una lista de playas de 
        /// acuerdo al tipo de vehiculo
        /// </summary>
        /// <param name="playas">lista de ID de playas</param>
        /// <param name="tipoVehiculo">tipo de vehiculo</param>
        /// <returns></returns>
        public List<DisponibilidadPlayas> GetDisponibilidadPlayasPorTipoVehiculo(int[] playas, int tipoVehiculo)
        {
            List<DisponibilidadPlayas> disponibilidades = new List<DisponibilidadPlayas>();

            //recupero las disponibilidades de cada playa
            //foreach (var item in playas)
            //{

            //    var servicio = GetServicioPorPlayaYTipoVehiculo(item, tipoVehiculo);
            //    DisponibilidadPlayas registroDisponibilidad = new DisponibilidadPlayas();
            //    registroDisponibilidad = disponibilidadPlayas.FindWhere(d => d.Servicio.Id == servicio.Id).First();
            //    disponibilidades.Add(registroDisponibilidad);
            //}

            var servicios = GetServiciosPorPlayasYTipoVehiculo(playas, tipoVehiculo);
            var lista = disponibilidadPlayas.FindWhere(d => servicios.Select(s => s.Id).Where(x => x == d.ServicioId).Count() > 0).ToList();
            //retorno una lista de disponibilidades oredenadas de mayor a menor
            return OrdenarPorDisponibilidad(lista);
        }
        public List<ConsultaDisponibilidad> GetDisponibilidadDePlayasPorTipoVehiculo(string idPlayas, int tipoVehiculo)
        {
            return disponibilidadPlayas.GetDisponibilidadDePlayasPorTipoVehiculo(idPlayas, tipoVehiculo);
        }

        /// <summary>
        /// Retorna una lista de regsitros de disponibilidad ordenados de mayor a menor
        /// </summary>
        /// <param name="disponibilidades">listas de disponibilidades de playas</param>
        /// <returns></returns>
        public List<DisponibilidadPlayas> OrdenarPorDisponibilidad(List<DisponibilidadPlayas> disponibilidades)
        {
            List<DisponibilidadPlayas> lista = disponibilidades;
            DisponibilidadPlayas t;

            for (int a = 1; a < lista.Count; a++)
            {
                for (int b = lista.Count - 1; b >= a; b--)
                {
                    if (lista[b - 1].Disponibilidad > lista[b].Disponibilidad)
                    {
                        t = lista[b - 1];
                        lista[b - 1] = lista[b];
                        lista[b] = t;
                    }
                }
            }

            lista.Reverse();

            return lista;

        }

    }
}
