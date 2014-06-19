using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Entidades;

namespace Datos
{
    class ContextoBD: DbContext
    {
        //instancia del singleton        
        private static ContextoBD instancia = null;

        /// <summary>
        /// Crea o retorna el contexto de la BD
        /// </summary>
        /// <returns></returns>
        public static ContextoBD getInstace()
        {
            if (instancia == null)
                instancia = new ContextoBD();

            return instancia;
        }

        /// <summary>
        /// Crea el contexto con la BD, con el name "BD_Geoparking" en el webConfig 
        /// </summary>
        public ContextoBD() : base("BD_Geoparking") { }

        /// <summary>
        /// Conexto(DataSet) para cada objeto en la BD
        /// </summary>
        public DbSet<PlayaDeEstacionamiento> playas { get; set; }
        public DbSet<TipoPlaya> tiposPlayas{ get; set; }
       
    }
}
