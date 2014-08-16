using Datos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReglasDeNegocio
{
    public class GestorBusquedaPlayas
    {
        GestorDireccion gestorDireccion;
        GestorPlaya gestorPlaya;
        GestorServicio gestorServicio;
        GestorHorario gestorHorario;
        IRepositorioPlayaDeEstacionamiento playaDao;
        IRepositorioTipoDePlaya tipoPlayaDao;
        IRepositorioDiaAtencion diaAtencionDao;
        IRepositorioTipoVehiculo tipoVehiculoDao;
        IRepositorioHorario horarioDao;
        IRepositorioServicio servicioDao;
        IRepositorioPrecio precioDao;

        /// <summary>
        /// Constructor 
        /// </summary>
        public GestorBusquedaPlayas()
        {
            gestorDireccion = new GestorDireccion();
            gestorPlaya = new GestorPlaya();
            gestorServicio = new GestorServicio();
            gestorHorario = new GestorHorario();
            tipoVehiculoDao = new RepositorioTipoVehiculo();
            playaDao = new RepositorioPlayaDeEstacionamiento();
            tipoPlayaDao = new RepositorioTipoDePlaya();
            diaAtencionDao = new RepositorioDiaAtencion();
            horarioDao = new RepositorioHorario();
            servicioDao = new RepositorioServicio();
            precioDao = new RepositorioPrecio();
        }

        /// <summary>
        /// Busca ciudades por nombre de acuerdo a un prefijo
        /// </summary>
        /// <param name="pre">prefijo del ombre de la ciudad</param>
        /// <returns>Lista de nombres de ciudades de comienzan con...</returns>
        public List<String> GetNombreCiudades(string pre)
        {
            //lista de nombres de ciudades a devolver
            List<string> nombreCiudades = new List<string>();

            //busco los objeto ciudad, si el nombre comienza con el valor de "pre"
            IList<Ciudad> ciudades = gestorDireccion.BuscarCiudadesPorNombre(pre);

            //recorro las ciudades y solo obtengo su nombre
            foreach (var ciudad in ciudades)
            {
                nombreCiudades.Add(ciudad.Nombre);
            }

            //retorno la lista de nombres
            return nombreCiudades;
        }

        /// <summary>
        /// buscas las playas de determinada ciudad
        /// </summary>
        /// <param name="ciudad">ciudad donde se ubican las playas</param>
        /// <returns>listado de playas ubicadas en esa ciudad</returns>
        public IList<PlayaDeEstacionamiento> buscarPlayasPorCiudad(string ciudad)
        {
            IList<PlayaDeEstacionamiento> playas = new List<PlayaDeEstacionamiento>();

            playas = gestorPlaya.BuscarPlayasPorCiudad(ciudad);

            return playas;
        }

        /// <summary>
        /// buscas las playas de determinada ciudad
        /// </summary>
        /// <param name="ciudad">ciudad donde se ubican las playas</param>
        /// <returns>listado de playas ubicadas en esa ciudad</returns>
        public IList<PlayaDeEstacionamiento> buscarPlayasPorFiltro(string ciudad, int tipoPlaya, int tipoVehiculo, int diasAtencion, decimal precioDesde, decimal precioHasta,
             int horaDesde, int horaHasta)
        {
            IList<PlayaDeEstacionamiento> playas = new List<PlayaDeEstacionamiento>();

            playas = gestorPlaya.BuscarPlayasPorFiltro(ciudad, tipoPlaya, tipoVehiculo, diasAtencion, precioDesde, precioHasta, horaDesde, horaHasta);

            return playas;
        }

        public IList<TipoPlaya> BuscarTipoPlayas()
        {
            return gestorPlaya.BuscarTipoPlayas();
        }

        public IList<TipoVehiculo> BuscarTipoVehiculos()
        {
            return gestorServicio.BuscarTipoVehiculos();
        }

        public IList<DiaAtencion> BuscarDiasDeAtencion()
        {
            return gestorHorario.BuscarDiasDeAtencion();
        }
    }
}
