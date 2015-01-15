using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using System.Data.SqlClient;

namespace Datos
{
    public class RepositorioPrecio : Repositorio<Precio>, IRepositorioPrecio
    {
        public override IList<Precio> FindWhere(Func<Precio, bool> predicate)
        {
            var lista = DbSet
                .Include("Servicio")
                .Where(predicate);

            return lista.ToList();
        }

        //spGetPreciosDePlayasPorTipoVehiculoEIdPlayas
        public IList<Precio> GetPreciosDePlayasPorTipoVehiculoEIdPlayas(string idsPlayas, int tipoVehiculo)
        {
            using (var context = new ContextoBD())
            {
                var idsPlayasParameter = new SqlParameter("@ListaIds", idsPlayas);
                var tipoVehiculoParameter = new SqlParameter("@TipoVehiculoId", tipoVehiculo);

                var result = context.Database
                    .SqlQuery<Precio>("spGetPreciosDePlayasPorTipoVehiculoEIdPlayas @ListaIds , @TipoVehiculoId", idsPlayasParameter, tipoVehiculoParameter)
                    .ToList();
                return result;
            }
        }
    }

}
