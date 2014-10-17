using Datos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReglasDeNegocio
{
    public class GestorTiposVehiculo
    {
        IRepositorioTipoVehiculo tipoVehiculoDao;

        public GestorTiposVehiculo()
        {
            tipoVehiculoDao = new RepositorioTipoVehiculo();
        }

        public GestorTiposVehiculo(IRepositorioTipoVehiculo tipoVehiculoDao)
        {
            this.tipoVehiculoDao = tipoVehiculoDao;
        }

        public IList<TipoVehiculo> ObtenerTiposDeVehiculo()
        {
            return tipoVehiculoDao.FindAll();
        }
    }
}
