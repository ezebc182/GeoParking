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

        /// <summary>
        /// Constructor 
        /// </summary>
        public GestorBusquedaPlayas()
        {
            gestorDireccion = new GestorDireccion();
            gestorPlaya = new GestorPlaya();
            gestorServicio = new GestorServicio();
            gestorHorario = new GestorHorario();            
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
        /// busca playas por id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public PlayaDeEstacionamiento buscarPlayaPorId(int id)
        {
            return gestorPlaya.BuscarPlayaPorId(id);
        }

        /// <summary>
        /// buscas las playas de determinada ciudad
        /// </summary>
        /// <param name="ciudad">ciudad donde se ubican las playas</param>
        /// <returns>listado de playas ubicadas en esa ciudad</returns>
        public IList<PlayaDeEstacionamiento> buscarPlayasPorFiltro(string ciudad, int[] tipoPlaya, int[] tipoVehiculo, int[] diasAtencion,decimal precioHasta,
             int horaDesde, int horaHasta)
        {
            IList<PlayaDeEstacionamiento> playas = new List<PlayaDeEstacionamiento>();
            playas = gestorPlaya.BuscarPlayasPorFiltro(ciudad, tipoPlaya, tipoVehiculo, diasAtencion, precioHasta, horaDesde, horaHasta);
            return playas;
        }

        /// <summary>
        /// Busca los tipos de playa
        /// </summary>
        /// <returns>Tipos de playas</returns>
        public IList<TipoPlaya> BuscarTipoPlayas()
        {
            return gestorPlaya.BuscarTipoPlayas();
        }

        /// <summary>
        /// Busca los tipos de vehiculos
        /// </summary>
        /// <returns>Tipos de vehiculos</returns>
        public IList<TipoVehiculo> BuscarTipoVehiculos()
        {
            return gestorServicio.BuscarTipoVehiculos();
        }

        /// <summary>
        /// Busca los dias de atencion
        /// </summary>
        /// <returns>Dias de atencion</returns>
        public IList<DiaAtencion> BuscarDiasDeAtencion()
        {
            return gestorHorario.BuscarDiasDeAtencion();
        }
    }
}
