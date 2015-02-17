using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using System.Data.SqlClient;

namespace Datos
{
    public class RepositorioEstadisticaConsultas : Repositorio<EstadisticaConsultas>, IRepositorioEstadisticaConsultas
    {
        public IList<EstadisticaPorTipoPlayaDto> GetConsultasTipoPlayaByCiudad(int idCiudad)
        {
            return GetConsultasTipoPlayaByCiudad(idCiudad, null, null);
        }

        public IList<EstadisticaPorTipoPlayaDto> GetConsultasTipoPlayaByCiudad(int idCiudad, DateTime? desde, DateTime? hasta)
        {
            IList<EstadisticaPorTipoPlayaDto> lista = new List<EstadisticaPorTipoPlayaDto>();
            SqlConnection sqlConnection1 = new SqlConnection("Data Source=SQL5004.Smarterasp.net;Initial Catalog=DB_9B3453_Geoparking;User Id=DB_9B3453_Geoparking_admin;Password=geoparking");
            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader;

            cmd.CommandText = "spGetCantidadConsultasPorTipoPlaya";
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Connection = sqlConnection1;
           
            sqlConnection1.Open();

            reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    lista.Add(new EstadisticaPorTipoPlayaDto { Fecha = reader.GetInt32(0), Nombre = reader.GetString(1), Cantidad = reader.GetInt32(2) });
                }
            }

            sqlConnection1.Close();
            return lista;

        }


        public IList<EstadisticaConsultasDto> GetConsultas(string ciudad, int usuarioId, int buscarPor, DateTime? desde, DateTime? hasta)
        {
            IList<EstadisticaConsultasDto> lista = new List<EstadisticaConsultasDto>();
            SqlConnection sqlConnection1 = new SqlConnection("Data Source=SQL5004.Smarterasp.net;Initial Catalog=DB_9B3453_Geoparking;User Id=DB_9B3453_Geoparking_admin;Password=geoparking");
            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader;

            cmd.CommandText = "spGetConsultas";
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
                    var text = string.Format("POINT({0} {1})", reader.GetDouble(7).ToString().Replace(',', '.'), reader.GetDouble(8).ToString().Replace(',', '.'));
                    var srid = 4326;

                    lista.Add(new EstadisticaConsultasDto
                    {
                        Cantidad = reader.GetInt32(0),
                        PlayaId = buscarPor == 1 ? reader.GetInt32(1) : reader.GetInt32(11),
                        PlayaNombre = buscarPor == 1 ? reader.GetString(2) : reader.GetString(12),
                        ZonaId = buscarPor == 2 ? reader.GetInt32(1) : 0,
                        ZonaNombre = buscarPor == 2 ? reader.GetString(2) : "",
                        TipoPlayaId = reader.GetInt32(3),
                        TipoPlayaNombre = reader.GetString(4),
                        TipoVehiculoId = reader.GetInt32(5),
                        TipoVehiculoNombre = reader.GetString(6),
                        Posicion = System.Data.Entity.Spatial.DbGeography.PointFromText(text, srid),
                        Ano = reader.GetInt32(9),
                        Mes = reader.GetInt32(10)
                    });
                }
            }

            sqlConnection1.Close();
            return lista;

        }

        public IList<EstadisticaPorTipoVehiculoDto> GetConsultasTipoVehiculoByCiudad(int idCiudad)
        {
            return GetConsultasTipoVehiculoByCiudad(idCiudad, null, null);
        }

        public IList<EstadisticaPorTipoVehiculoDto> GetConsultasTipoVehiculoByCiudad(int idCiudad, DateTime? desde, DateTime? hasta)
        {

            IList<EstadisticaPorTipoVehiculoDto> lista = new List<EstadisticaPorTipoVehiculoDto>();
            SqlConnection sqlConnection1 = new SqlConnection("Data Source=SQL5004.Smarterasp.net;Initial Catalog=DB_9B3453_Geoparking;User Id=DB_9B3453_Geoparking_admin;Password=geoparking");
            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader;

            cmd.CommandText = "spGetCantidadConsultasPorTipoVehiculo";
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Connection = sqlConnection1;

            sqlConnection1.Open();

            reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    lista.Add(new EstadisticaPorTipoVehiculoDto { Fecha = reader.GetInt32(0), Nombre = reader.GetString(1), Cantidad = reader.GetInt32(2) });
                }
            }

            sqlConnection1.Close();
            return lista;

            //using (var contexto = new ContextoBD())
            //{
            //    System.Data.SqlClient.SqlParameter fechaDesde, fechaHasta;

            //    var ciudad = new System.Data.SqlClient.SqlParameter("ciudad", idCiudad);
            //    if (desde.HasValue) fechaDesde = new System.Data.SqlClient.SqlParameter("fechaDesde", desde.Value);
            //    else fechaDesde = new System.Data.SqlClient.SqlParameter("fechaDesde", DBNull.Value);

            //    if (hasta.HasValue) fechaHasta = new System.Data.SqlClient.SqlParameter("fechaHasta", hasta.Value);
            //    else fechaHasta = new System.Data.SqlClient.SqlParameter("fechaHasta", DBNull.Value);

            //    return contexto.Database.SqlQuery<EstadisticaPorTipoVehiculoDto>("execute spGetCantidadConsultasPorTipoVehiculo @ciudad, @fechaDesde, @fechaHasta", ciudad, fechaDesde, fechaHasta).ToList();
            //}
        }

        public IList<EstadisticaDensidadDto> GetConsultasByCiudad(int idCiudad, DateTime? desde, DateTime? hasta)
        {
            using (var contexto = new ContextoBD())
            {
                System.Data.SqlClient.SqlParameter fechaDesde, fechaHasta;

                var ciudad = new System.Data.SqlClient.SqlParameter("ciudad", idCiudad);
                if (desde.HasValue) fechaDesde = new System.Data.SqlClient.SqlParameter("fechaDesde", desde.Value);
                else fechaDesde = new System.Data.SqlClient.SqlParameter("fechaDesde", DBNull.Value);

                if (hasta.HasValue) fechaHasta = new System.Data.SqlClient.SqlParameter("fechaHasta", hasta.Value);
                else fechaHasta = new System.Data.SqlClient.SqlParameter("fechaHasta", DBNull.Value);

                return contexto.Database.SqlQuery<EstadisticaDensidadDto>("execute spGetEstadisticasByFilters @ciudad, @fechaDesde, @fechaHasta", ciudad, fechaDesde, fechaHasta).ToList();
            }
        }


        public IList<EstadisticaDensidadDto> GetConsultasByCiudad(int idCiudad)
        {
            return GetConsultasByCiudad(idCiudad, null, null);
        }
    }

}
