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

        public IList<EstadisticaDisponibilidadDto> GetDisponibilidades(string ciudad, int usuarioId, int buscarPor, DateTime? desde, DateTime? hasta)
        {
            IList<EstadisticaDisponibilidadDto> lista = new List<EstadisticaDisponibilidadDto>();
            SqlConnection sqlConnection1 = new SqlConnection("Data Source=SQL5004.Smarterasp.net;Initial Catalog=DB_9B3453_Geoparking;User Id=DB_9B3453_Geoparking_admin;Password=geoparking");
            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader;

            cmd.CommandText = "spGetDisponibilidades";
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Connection = sqlConnection1;
            cmd.Parameters.AddWithValue("ciudad", ciudad);
            cmd.Parameters.AddWithValue("usuarioId", usuarioId);
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
                    var text = string.Format("POINT({0:R} {1:R})", reader.GetDouble(7).ToString().Replace(',', '.'), reader.GetDouble(8).ToString().Replace(',', '.'));
                    var srid = 4326;

                    lista.Add(new EstadisticaDisponibilidadDto
                    {
                        Cantidad = reader.GetInt32(0),
                        PlayaId = buscarPor == 2 ? reader.GetInt32(11) : reader.GetInt32(1),
                        PlayaNombre = buscarPor == 2 ? reader.GetString(12) : reader.GetString(2),
                        ZonaId = buscarPor == 2 ? reader.GetInt32(1) : 0,
                        ZonaNombre = buscarPor == 2 ? reader.GetString(2) : "",
                        TipoPlayaId = reader.GetInt32(3),
                        TipoPlayaNombre = reader.GetString(4),
                        TipoVehiculoId = reader.GetInt32(5),
                        TipoVehiculoNombre = reader.GetString(6),
                        Posicion = System.Data.Entity.Spatial.DbGeography.PointFromText(text, srid),
                        Ano = buscarPor != 3 ? reader.GetInt32(9) : 0,
                        Mes = buscarPor != 3 ? reader.GetInt32(10) : 0,
                        Tiempo = buscarPor == 1?  reader.GetTimeSpan(11).ToString() : buscarPor == 2?  reader.GetTimeSpan(13).ToString() : reader.GetString(9)
                    });
                }
            }

            sqlConnection1.Close();
            return lista;

        }
    }
    
}
