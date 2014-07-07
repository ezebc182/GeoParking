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
    public class GestorPrecio
    {
        IRepositorioDiaAtencion diaAtencionDao;
        IRepositorioTiempo tiempoDao;
        IRepositorioTipoVehiculo tipoVehiculoDao;
        IRepositorioPrecio precioDao;

        public GestorPrecio()
        {
            diaAtencionDao = new RepositorioDiaAtencion();
            tiempoDao = new RepositorioTiempo();
            tipoVehiculoDao = new RepositorioTipoVehiculo();
            precioDao = new RepositorioPrecio();
        }

        public GestorPrecio(IRepositorioPrecio repositorioPrecio)
        {
            precioDao = repositorioPrecio;
        }


        public Resultado RegistrarPrecio(Precio precio)
        {
            var resultado = ValidarRegistracion(precio);

            if (resultado.Ok)
            {
                precioDao.Create(precio);
            }

            return resultado;
        }

        private Resultado ValidarRegistracion(Precio precio)
        {
            var resultado = new Resultado();



            return resultado;
        }

        public Resultado ActualizarPrecio(Precio precio)
        {
            var resultado = ValidarActualizacion();

            if (resultado.Ok)
            {
                precioDao.Update(precio);
            }
            return resultado;
        }


        private Resultado ValidarActualizacion()
        {
            var resultado = new Resultado();

            //Agregar validaciones

            return resultado;
        }

        public Resultado EliminarPrecio(int idPrecio)
        {
            var resultado = ValidarEliminacion();

            if (resultado.Ok)
            {
                precioDao.Delete(m => m.Id == idPrecio);
            }

            return resultado;
        }

        private Resultado ValidarEliminacion()
        {
            var resultado = new Resultado();

            //Agregar validaciones

            return resultado;
        }


        public Precio BuscarPrecioPorId(int idPrecio)
        {
            return precioDao.FindById(idPrecio);
        }

        public DiaAtencion GetDiaAtencionById(int IdDiaAtencionSeleccionado)
        {
            return diaAtencionDao.FindById(IdDiaAtencionSeleccionado);
        }

        public TipoVehiculo BuscarTipoVehiculoPorId(int id)
        {
            return tipoVehiculoDao.FindById(id);
        }

        public Tiempo BuscarTiempoPorId(int id)
        {
            return tiempoDao.FindById(id);
        }

        public IList<Tiempo> BuscarTiempos()
        {
            return tiempoDao.FindAll();
        }

        public IList<TipoVehiculo> BuscarTipoVehiculos()
        {
            return tipoVehiculoDao.FindAll();
        }

        public IList<DiaAtencion> BuscarDiasDeAtencion()
        {
            return diaAtencionDao.FindAll();
        }
    }
}
