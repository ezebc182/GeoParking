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

        public GestorDisponibilidad()
        {
            disponibilidadPlayas = new RepositorioDisponibilidadPlayas();
            historialDisponibilidadPlayas = new RepositorioHistorialDisponibilidadPlayas();
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
            DisponibilidadPlayas registroDisponibilidad = new DisponibilidadPlayas();
            registroDisponibilidad = disponibilidadPlayas.FindWhere(d => d.PlayaDeEstacionamientoId == playa && d.TipoVehiculoId == tipoVehiculo).First();
            //2° verificamos el evento
            if(evento==1) //ingreso
            {
                registroDisponibilidad.Disponibilidad=registroDisponibilidad.Disponibilidad+1;
            }
            else //egreso
            {
                registroDisponibilidad.Disponibilidad=registroDisponibilidad.Disponibilidad-1;
            }

            try 
	        {	        
		         //3° actualizamos el registro
                disponibilidadPlayas.Update(registroDisponibilidad);
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
            return disponibilidadPlayas.FindWhere(d => d.PlayaDeEstacionamientoId == playa && d.TipoVehiculoId == tipoVehiculo).First().Disponibilidad; 
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
            foreach (var item in playas)
            {
                DisponibilidadPlayas registroDisponibilidad = new DisponibilidadPlayas();
                registroDisponibilidad = disponibilidadPlayas.FindWhere(d => d.PlayaDeEstacionamientoId == item && d.TipoVehiculoId == tipoVehiculo).First();
                disponibilidades.Add(registroDisponibilidad);
            }

            //retorno una lista de disponibilidades oredenadas de mayor a menor
            return OrdenarPorDisponibilidad(disponibilidades);
        }
        public List<DisponibilidadPlayas> GetDisponibilidadDePlayasPorTipoVehiculo(string idPlayas, int tipoVehiculo)
        {
            return disponibilidadPlayas.GetDisponibilidadDePlayasPorTipoVehiculo(idPlayas, tipoVehiculo);
        }

        /// <summary>
        /// Retorna una lista de regsitros de disponibilidad ordenados de mayor a menor
        /// </summary>
        /// <param name="disponibilidades">listas de disponibilidades de playas</param>
        /// <returns></returns>
        public List<DisponibilidadPlayas> OrdenarPorDisponibilidad( List<DisponibilidadPlayas> disponibilidades)
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
