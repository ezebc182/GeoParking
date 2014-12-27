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
    public class GestorServicio
    {
        IRepositorioTipoVehiculo tipoVehiculoDao;
        IRepositorioServicio servicioDao;

        public GestorServicio()
        {
            tipoVehiculoDao = new RepositorioTipoVehiculo();
            servicioDao = new RepositorioServicio();
        }

        public GestorServicio(IRepositorioTipoVehiculo tipoVehiculoDao,
        IRepositorioServicio servicioDao)
        {
            this.servicioDao = servicioDao;
            this.tipoVehiculoDao = tipoVehiculoDao;
        }

        /// <summary>
        /// Busca un servicio por su id
        /// </summary>
        /// <param name="idServicio"></param>
        /// <returns></returns>
        public Servicio BuscarServicioPorId(int idServicio)
        {
            return servicioDao.FindById(idServicio);
        }

        /// <summary>
        /// Busca un tipo de vehiculo por su id
        /// </summary>
        /// <param name="id">id del tipo de vehiculo</param>
        /// <returns>tipo de vehiculo segun su id</returns>
        public TipoVehiculo BuscarTipoVehiculoPorId(int id)
        {
            return tipoVehiculoDao.FindById(id);
        }
        /// <summary>
        /// Busca todos los tipos de vehiculos
        /// </summary>
        /// <returns>lista de tipos de vehiculos</returns>
        public IList<TipoVehiculo> BuscarTipoVehiculos()
        {
            return tipoVehiculoDao.FindAll();
        }

        /// <summary>
        /// Cancela y da de baja el servicio de la playa de estacionamiento.
        /// </summary>
        /// <param name="idPlaya">id de la playa</param>
        /// <param name="idTipoVechiculo">id de tipo de vehiculo</param>
        /// <returns>'True' si la operacion se realizo correctamente</returns>
        public Resultado CancelarServicioPlaya(int idPlaya, int idTipoVechiculo)
        {
            Resultado resultado = new Resultado();

            try
            {
                Servicio servicioRecuperado = servicioDao.FindWhere(s => s.PlayaDeEstacionamientoId == idPlaya && s.TipoVehiculoId == idTipoVechiculo).First();

                servicioRecuperado.FechaBaja = DateTime.Now;

                servicioDao.Update(servicioRecuperado);
            }
            catch (Exception)
            {
                resultado.AgregarMensaje("Se ha producido un error de base de datos.");
            }            

            return resultado;
        }

        /// <summary>
        /// Registro de un nuevo servicio
        /// </summary>
        /// <param name="idPlaya">id de la playa</param>
        /// <param name="idTipoVechiculo">id del tipo de vehiculo</param>
        /// <param name="capacidad">capacidad (lugares para el tipo de vehiculo)</param>
        /// <param name="x1">precio por hora</param>
        /// <param name="x6">precio por 6 horas</param>
        /// <param name="x12">precio por 12 horas</param>
        /// <param name="x24">precio por 24 horas</param>
        /// <param name="abono">precio por mes</param>
        /// <returns>'True' si la operacion se realizo correctamente</returns>
        public Resultado RegistrarServicioPlaya(int idPlaya, int idTipoVechiculo, int capacidad, double x1, double x6, double x12, double x24, double abono)
        {
            Resultado resultado = new Resultado();

            try
            {

                Servicio servicio = new Servicio();
                servicio.PlayaDeEstacionamientoId = idPlaya;
                servicio.TipoVehiculoId = idTipoVechiculo;
                
                //capacidad
                Capacidad cap = new Capacidad();
                cap.Cantidad=capacidad;
                servicio.Capacidad = cap;

                //precios
                List<Precio> precios = new List<Precio>();

                //por hora
                if (x1 != 0)
                {
                    Precio p1 = new Precio();
                    p1.TiempoId = 1;
                    p1.Monto = Decimal.Parse(x1.ToString());

                    precios.Add(p1);
                }

                //por 6 horas
                if (x6 != 0)
                {
                    Precio p2 = new Precio();
                    p2.TiempoId = 2;
                    p2.Monto = Decimal.Parse(x6.ToString());

                    precios.Add(p2);
                }

                //por 12 horas
                if (x12 != 0)
                {
                    Precio p3 = new Precio();
                    p3.TiempoId = 3;
                    p3.Monto = Decimal.Parse(x12.ToString());

                    precios.Add(p3);
                }

                //por 24 horas
                if (x24 != 0)
                {
                    Precio p4 = new Precio();
                    p4.TiempoId = 1;
                    p4.Monto = Decimal.Parse(x24.ToString());

                    precios.Add(p4);
                }

                //abono mensual
                if (abono != 0)
                {
                    Precio p5 = new Precio();
                    p5.TiempoId = 1;
                    p5.Monto = Decimal.Parse(abono.ToString());

                    precios.Add(p5);
                }

                //creacion del servicio
                servicioDao.Create(servicio);
            }
            catch (Exception)
            {
                resultado.AgregarMensaje("Se ha producido un error de base de datos.");
            }

            return resultado;
        }
    }
}
