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
            //using (var contexto = new ContextoBD())
            //{
            //    System.Data.SqlClient.SqlParameter fechaDesde, fechaHasta;

            //    var ciudad = new System.Data.SqlClient.SqlParameter("ciudad", idCiudad);
            //    if(desde.HasValue)  fechaDesde = new System.Data.SqlClient.SqlParameter("fechaDesde", desde.Value);
            //    else  fechaDesde = new System.Data.SqlClient.SqlParameter("fechaDesde", DBNull.Value);

            //    if(hasta.HasValue) fechaHasta = new System.Data.SqlClient.SqlParameter("fechaHasta", hasta.Value);
            //    else fechaHasta = new System.Data.SqlClient.SqlParameter("fechaHasta", DBNull.Value);

            //    return contexto.Database.SqlQuery<EstadisticaPorTipoPlayaDto>("execute spGetCantidadConsultasPorTipoPlaya @ciudad, @fechaDesde, @fechaHasta", ciudad, fechaDesde, fechaHasta).ToList();
            //}
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
