using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Spatial;
using System.Data.SqlTypes;
using Microsoft.SqlServer.Types;

namespace Entidades.util
{
    public static class DbGeographyHelper
    {
        
        // 4326 is most common coordinate system used by GPS/Maps
        // 4326 format puts LONGITUDE first then LATITUDE
        private static int _coordinateSystem = 4326;

        public static DbGeography CreatePolygon(string wktString)
        {
            var sqlGeography =
            SqlGeography.STGeomFromText(new SqlChars(wktString.Replace(',', '.')), _coordinateSystem)
            .MakeValid();

            var invertedSqlGeography = sqlGeography.ReorientObject();
            if (sqlGeography.STArea() > invertedSqlGeography.STArea())
            {
                sqlGeography = invertedSqlGeography;
            }

            return DbSpatialServices.Default.GeographyFromProviderValue(sqlGeography);
        }

    }
}
