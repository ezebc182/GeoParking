using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using System.Data.SqlClient;

namespace Datos
{
    public class RepositorioDireccion : Repositorio<Direccion>, IRepositorioDireccion
    {
        public IList<Direccion> GetDireccionesDePlayasPorCiudadYTipoVehiculo(string ciudad, int tipoVehiculoId)
        {
            using (var context = new ContextoBD())
            {
                var ciudadParameter = new SqlParameter("@Ciudad", ciudad);
                var tipoVehiculoParameter = new SqlParameter("@TipoVehiculoId", tipoVehiculoId);

                var result = context.Database
                    .SqlQuery<Direccion>("spObtenerUbicacionesDePlayasPorCiudadYTipoVehiculo @Ciudad , @TipoVehiculoId", ciudadParameter, tipoVehiculoParameter)
                    .ToList();
                return result;
            }
        }
        public IList<Direccion> GetDireccionesPorDistanciaYTipoVehiculo(string latitud, string longitud, int tipoVehiculo)
        {
            //string punto = String.Format("POINT({0} {1})", latitud, longitud);
            //DbGeography posicion = DbGeography.PointFromText(punto,4326);

            using (var context = new ContextoBD())
            {
                var latitudParameter = new SqlParameter("@latitud", float.Parse(latitud));
                var longitudParameter = new SqlParameter("@longitud", float.Parse(longitud));
                var tipoVehiculoParameter = new SqlParameter("@TipoVehiculoId", tipoVehiculo);
                var result = context.Database
                    .SqlQuery<Direccion>("spObtenerUbicacionPorUbicacion @latitud, @longitud , @TipoVehiculoId", latitudParameter, longitudParameter, tipoVehiculoParameter)
                    .ToList();
                return result;
            }
        }
        public override IList<Direccion> FindWhere(Func<Direccion, bool> predicate)
        {
            var lista = DbSet
                .Include("Servicio")
                .Where(predicate);

            return lista.ToList();
        }
    }
    
}
