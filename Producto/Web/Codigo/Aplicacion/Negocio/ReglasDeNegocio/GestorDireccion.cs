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

        public GestorDireccion(IRepositorioDireccion direccionDao,
        IRepositorioCiudad ciudadDao,
        IRepositorioDepartamento departamentoDao,
        IRepositorioProvincia provinciaDao)
        {
            this.direccionDao = direccionDao;
            this.ciudadDao = ciudadDao;
            this.departamentoDao = departamentoDao;
            this.provinciaDao = provinciaDao;
        }

        /// <summary>
        /// Carga la ciudad, departamento y provincia de una direccion dada
        /// </summary>
        /// <param name="direccion"></param>
        private void CargarDireccion(Direccion direccion)
        {
            if (direccion.Ciudad == null) direccion.Ciudad = BuscarCiudadPorId(direccion.CiudadId);
            if (direccion.Departamento == null) direccion.Departamento = BuscarDepartamentoPorCiudadId(direccion.CiudadId);
            if (direccion.Provincia == null) direccion.Provincia = BuscarProvinciaPorDepartamentoId(direccion.Departamento.Id);
        }
        /// <summary>
        /// Busca una direccion por su Id
        /// </summary>
        /// <param name="idDireccion"></param>
        /// <returns></returns>
        public Direccion BuscarDireccionPorId(int idDireccion)
        {
            var direccion = direccionDao.FindById(idDireccion);
            CargarDireccion(direccion);
            return direccion;            
        }
        /// <summary>
        /// Busca todas las direcciones de una playa
        /// </summary>
        /// <param name="idPlaya"></param>
        /// <returns></returns>
        public IList<Direccion> BuscarDireccionesPorPlaya(int idPlaya)
        {
            var direcciones = direccionDao.FindWhere(d => d.PlayaDeEstacionamientoId == idPlaya);
            foreach (var direccion in direcciones)
            {
                CargarDireccion(direccion);
            }
            return direcciones;
        }
        /// <summary>
        /// Busca una ciudad por su id
        /// </summary>
        /// <param name="IdCiudadSeleccionada"></param>
        /// <returns></returns>
        public Ciudad BuscarCiudadPorId(int IdCiudadSeleccionada)
        {
            return ciudadDao.FindById(IdCiudadSeleccionada);
        }
        /// <summary>
        /// Busca el departamento de una ciudad por su id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Departamento BuscarDepartamentoPorCiudadId(int id)
        {
            return BuscarDepartamentoPorId(BuscarCiudadPorId(id).DepartamentoId);
        }
        /// <summary>
        /// Busca un departamento por su id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Departamento BuscarDepartamentoPorId(int id)
        {
            return departamentoDao.FindById(id);
        }
        /// <summary>
        /// Busca la provincia de un departamento por su id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Provincia BuscarProvinciaPorDepartamentoId(int id)
        {
            return BuscarProvinciaPorId(BuscarDepartamentoPorId(id).ProvinciaId);
        }
        /// <summary>
        /// Busca una provincia 
        /// </summary>
        /// <param name="id">Id de la provincia</param>
        /// <returns></returns>
        public Provincia BuscarProvinciaPorId(int id)
        {
            return provinciaDao.FindById(id);
        }
        /// <summary>
        /// Busca todas las provincias
        /// </summary>
        /// <returns></returns>
        public IList<Provincia> BuscarProvincias()
        {
            return provinciaDao.FindAll();
        }
        /// <summary>
        /// Busca todos los departamentos correspondiente a una provincia
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IList<Departamento> BuscarDepartamentosPorProvinciaId(int id)
        {
            return departamentoDao.FindWhere(d => d.ProvinciaId == id);
        }
        /// <summary>
        /// Busca las ciudades correspondientes a un departamento
        /// </summary>
        /// <param name="id">Id del departamento</param>
        /// <returns></returns>
        public object BuscarCiudadesPorDepartamentoId(int id)
        {
            return ciudadDao.FindWhere(c => c.DepartamentoId == id);
        }

        /// <summary>
        /// Busca las ciudades por un prefijo, es decir que el nombre de la 
        /// ciudad comienze con...
        /// </summary>
        /// <param name="prefijoNombre">string inicio del nombre</param>
        /// <returns>Lista de ciudades que comienzan con...</returns>
        public IList<Ciudad> BuscarCiudadesPorNombre(string prefijoNombre)
        {
            return ciudadDao.FindWhere(c => c.Nombre.StartsWith(prefijoNombre));
        }

    }
}
