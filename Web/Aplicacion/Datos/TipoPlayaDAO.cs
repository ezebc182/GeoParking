using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Entidades;

namespace Datos
{
    class TipoPlayaDAO: DbContext
    {
        public TipoPlayaDAO() : base("BD_Geoparking") { }

        /*contexto para las entidades PLAYAS DE ESTACIONAMIENTO y al mismo tiempo permite obtener
         acceso a todas las entidades PlayasEstacionamiento de la BD*/
        public DbSet<TipoPlaya> tiposPlayas { get; set; }

        /*busca playa por id*/
        public TipoPlaya buscarTipoPlayaPorId(int id)
        {
            //retorno la playa con el id
            return tiposPlayas.Find(id);
        }

        /*busca playa por nombre*/
        public List<TipoPlaya> buscarTipoPlayaPorNombre(string nombre)
        {
            //lista de playas de estacionamiento a devolver
            List<TipoPlaya> tipos=new List<TipoPlaya>();
            
            //lista de playas existente con el nombre a buscar
            var list = tiposPlayas.Where(m => m.nombre==nombre);
            
            //carga de las playas a la lista
            foreach (TipoPlaya tipoPlaya in list)
                tipos.Add(tipoPlaya);
            
            //retornar la lista
            return tipos;
        }

        /*registrar una nueva playa de estacionamiento*/
        public void registrarTipoPlaya(TipoPlaya tp)
        {
            //agrego la playa a la BD
            tiposPlayas.Add(tp);           
            //guardo los cambios
            SaveChanges();
        }

        /*actualizar la playa*/
        public void actualizarTipoPlaya(TipoPlaya tp)
        {
            Entry(tp);
            SaveChanges();
        }

        /*elimina playa por id*/
        public void eliminarTipoPlaya(int id)
        {
            //elimino la playa con el id
            tiposPlayas.Remove(tiposPlayas.Find(id));
            //guardo los cambios
            SaveChanges();
        }       
    
    }
}
