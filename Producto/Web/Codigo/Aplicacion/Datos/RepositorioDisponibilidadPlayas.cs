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

        public IList<EstadisticaDisponibilidadDto> GetDisponibilidades(int ciudad, int usuarioId, int buscarPor, DateTime? desde, DateTime? hasta)
        {
            IList<EstadisticaDisponibilidadDto> lista = new List<EstadisticaDisponibilidadDto>();
            SqlConnection sqlConnection1 = new SqlConnection("Data Source=SQL5004.Smarterasp.net;Initial Catalog=DB_9B3453_Geoparking;User Id=DB_9B3453_Geoparking_admin;Password=geoparking");
            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader;

            cmd.CommandText = "spGetDisponibilidades";
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Connection = sqlConnection1;
            cmd.Parameters.AddWithValue("ciudad", ciudad);
            cmd.Parameters.AddWithValue("usuario", usuarioId);
            cmd.Parameters.AddWithValue("buscarPor", buscarPor);
            cmd.Parameters.AddWithValue("desde", desde);
            cmd.Parameters.AddWithValue("hasta", hasta);
            sqlConnection1.Open();

            reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    //para leer geography
                    var text = string.Format("POINT({0:R} {1:R})", reader.GetFloat(4), reader.GetFloat(5));
                    var srid = 4326;

                    lista.Add(new EstadisticaDisponibilidadDto
                    {
                        Ocupacion = reader.GetDouble(0),
                        PlayaId = buscarPor == 1 ? reader.GetInt32(1) : 0,
                        ZonaId = buscarPor == 2 ? reader.GetInt32(1) : 0,
                        TipoPlayaId = reader.GetInt32(2),
                        TipoVehiculoId = reader.GetInt32(3),
                        Posicion = System.Data.Entity.Spatial.DbGeography.PointFromText(text, srid)
                    });
                }
            }

            sqlConnection1.Close();
            return lista;

        }
    }
    
}
