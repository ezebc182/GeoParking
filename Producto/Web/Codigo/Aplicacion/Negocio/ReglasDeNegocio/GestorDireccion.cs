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
    public class GestorDireccion
    {
        IRepositorioDireccion direccionDao;
        IRepositorioCiudad ciudadDao;
        IRepositorioDepartamento departamentoDao;
        IRepositorioProvincia provinciaDao;

        public GestorDireccion()
        {
            direccionDao = new RepositorioDireccion();
            ciudadDao = new RepositorioCiudad();
            departamentoDao = new RepositorioDepartamento();
            provinciaDao = new RepositorioProvincia();
        }

        public GestorDireccion(IRepositorioDireccion repositorioDireccion)
        {
            direccionDao = repositorioDireccion;
        }


        public Resultado Registrarireccion(Direccion direccion)
        {
            var resultado = ValidarRegistracion(direccion);

            if (resultado.Ok)
            {
                direccionDao.Create(direccion);
            }

            return resultado;
        }

        private Resultado ValidarRegistracion(Direccion direccion)
        {
            var resultado = new Resultado();



            return resultado;
        }

        public Resultado ActualizarDireccion(Direccion direccion)
        {
            var resultado = ValidarActualizacion();

            if (resultado.Ok)
            {
                direccionDao.Update(direccion);
            }
            return resultado;
        }


        private Resultado ValidarActualizacion()
        {
            var resultado = new Resultado();

            //Agregar validaciones

            return resultado;
        }

        public Resultado EliminarDireccion(int idDireccion)
        {
            var resultado = ValidarEliminacion();

            if (resultado.Ok)
            {
                direccionDao.Delete(m => m.Id == idDireccion);
            }

            return resultado;
        }

        private Resultado ValidarEliminacion()
        {
            var resultado = new Resultado();

            //Agregar validaciones

            return resultado;
        }

        private void CargarDireccion(Direccion direccion)
        {
            direccion.Ciudad = GetCiudadById(direccion.CiudadId);
            direccion.Departamento = BuscarDepartamentoPorCiudadId(direccion.CiudadId);
            direccion.Provincia = BuscarProvinciaPorDepartamentoId(direccion.Departamento.Id);
        }

        public Direccion BuscarDireccionPorId(int idDireccion)
        {
            var direccion = direccionDao.FindById(idDireccion);
            CargarDireccion(direccion);
            return direccion;            
        }
        public IList<Direccion> BuscarDireccionesPorPlaya(int idPlaya)
        {
            var direcciones = direccionDao.FindWhere(d => d.PlayaDeEstacionamientoId == idPlaya);
            foreach (var direccion in direcciones)
            {
                CargarDireccion(direccion);
            }
            return direcciones;
        }

        public Ciudad GetCiudadById(int IdCiudadSeleccionada)
        {
            return ciudadDao.FindById(IdCiudadSeleccionada);
        }

        public Departamento BuscarDepartamentoPorCiudadId(int id)
        {
            return BuscarDepartamentoPorId(GetCiudadById(id).DepartamentoId);
        }
        public Departamento BuscarDepartamentoPorId(int id)
        {
            return departamentoDao.FindById(id);
        }
        public Provincia BuscarProvinciaPorDepartamentoId(int id)
        {
            return BuscarProvinciaPorId(BuscarDepartamentoPorId(id).ProvinciaId);
        }
        public Provincia BuscarProvinciaPorId(int id)
        {
            return provinciaDao.FindById(id);
        }
        public IList<Provincia> BuscarProvincias()
        {
            return provinciaDao.FindAll();
        }

        public IList<Departamento> BuscarDepartamentosPorProvinciaId(int id)
        {
            return departamentoDao.FindWhere(d => d.ProvinciaId == id);
        }

        public object BuscarCiudadesPorDepartamentoId(int id)
        {
            return ciudadDao.FindWhere(c => c.DepartamentoId == id);
        }
    }
}
