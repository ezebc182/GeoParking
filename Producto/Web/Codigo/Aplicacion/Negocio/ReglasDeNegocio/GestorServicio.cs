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

        public GestorServicio(IRepositorioServicio repositorioServicio)
        {
            servicioDao = repositorioServicio;
        }


        public Resultado RegistrarServicio(Servicio servicio)
        {
            var resultado = ValidarRegistracion(servicio);

            if (resultado.Ok)
            {
                servicioDao.Create(servicio);
            }

            return resultado;
        }

        private Resultado ValidarRegistracion(Servicio servicio)
        {
            var resultado = new Resultado();



            return resultado;
        }

        public Resultado ActualizarServicio(Servicio servicio)
        {
            var resultado = ValidarActualizacion();

            if (resultado.Ok)
            {
                servicioDao.Update(servicio);
            }
            return resultado;
        }


        private Resultado ValidarActualizacion()
        {
            var resultado = new Resultado();

            //Agregar validaciones

            return resultado;
        }

        public Resultado EliminarServicio(int idServicio)
        {
            var resultado = ValidarEliminacion();

            if (resultado.Ok)
            {
                servicioDao.Delete(m => m.Id == idServicio);
            }

            return resultado;
        }

        private Resultado ValidarEliminacion()
        {
            var resultado = new Resultado();

            //Agregar validaciones

            return resultado;
        }


        public Servicio BuscarServicioPorId(int idServicio)
        {
            return servicioDao.FindById(idServicio);
        }

       
        public TipoVehiculo BuscarTipoVehiculoPorId(int id)
        {
            return tipoVehiculoDao.FindById(id);
        }

        public IList<TipoVehiculo> BuscarTipoVehiculos()
        {
            return tipoVehiculoDao.FindAll();
        }

    }
}
