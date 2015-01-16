using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using System.Data.SqlClient;

namespace Datos
{
    public class RepositorioDisponibilidadPlayas : Repositorio<DisponibilidadPlayas>, IRepositorioDisponibilidadPlayas
    {
        public List<ConsultaDisponibilidad> GetDisponibilidadDePlayasPorTipoVehiculo(string idPlayas, int tipoVehiculo)
        {
            using (var context = new ContextoBD())
            {
                var idsPlayasParameter = new SqlParameter("@ListaIds", idPlayas);
                var tipoVehiculoParameter = new SqlParameter("@TipoVehiculoId", tipoVehiculo);

                var result = context.Database
                    .SqlQuery<ConsultaDisponibilidad>("spObtenerDisponibilidadPlayasPorTipoVehiculo @ListaIds , @TipoVehiculoId", idsPlayasParameter, tipoVehiculoParameter)
                    .ToList();
                return result;
            }
        }

        public override IList<DisponibilidadPlayas> FindWhere(Func<DisponibilidadPlayas, bool> predicate)
        {
            var lista = DbSet
                .Include("Servicio")
                .Where(predicate);

            return lista.ToList();
        }
    }
    
}
