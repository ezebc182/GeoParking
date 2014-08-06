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
    }
}
