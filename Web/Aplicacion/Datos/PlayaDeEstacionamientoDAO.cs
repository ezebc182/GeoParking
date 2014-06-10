using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Entidades;

namespace Datos
{
    class PlayaDeEstacionamientoDAO : DbContext
    {
        /// <summary>
        /// construye el contexto de la BD para los objetos PlayaDeEstacionamiento
        /// </summary>
        public PlayaDeEstacionamientoDAO() : base("BD_Geoparking") { }
        
        /// <summary>
        /// dataSet de las playas de estacionamiento en la BD, permite
        /// obtener una lista de todas las playas
        /// </summary>
        public DbSet<PlayaDeEstacionamiento> playas { get; set; }

        /// <summary>
        /// busca playa de estacionamiento por el id
        /// </summary>
        /// <param name="id">es el id de la playa</param>
        /// <returns>un objeto de Playa de Estacionamiento</returns>
        public PlayaDeEstacionamiento buscarPlayaPorId(int id)
        {
            //retorna la playa
            return playas.Find(id);
        }

        /// <summary>
        /// busca playas filtradas por nombre
        /// </summary>
        /// <param name="nombre">es un string nombre de la playa</param>
        /// <returns>lista de objetos Playa de Estacionamiento</returns>
        public List<PlayaDeEstacionamiento> buscarPlayaPorNombre(string nombre)
        {
            //lista de las playas a retornar
            List<PlayaDeEstacionamiento> playasEstacionamientos=new List<PlayaDeEstacionamiento>();
            
            //lista de playas existente con el nombre a buscar
            var list = playas.Where(m => m.nombre==nombre);
            
            //carga de las playas a la lista
            foreach (PlayaDeEstacionamiento playa in list)
                playasEstacionamientos.Add(playa);
            
            //retorna la lista
            return playasEstacionamientos;
        }
        
        /// <summary>
        /// registra una playa de estacionamiento
        /// </summary>
        /// <param name="p">objeto Playa de Estacionamiento</param>
        public void registrarPlaya(PlayaDeEstacionamiento p)
        {
            //agrega la playa a la BD
            playas.Add(p);           
            //guarda los cambios
            SaveChanges();
        }

        /// <summary>
        /// actualiza una playa de estacionamiento
        /// </summary>
        /// <param name="p">objeto Playa de Estacionamiento</param>
        public void actualizarPlaya(PlayaDeEstacionamiento p)
        {
            Entry(p);
            SaveChanges();
        }

        /// <summary>
        /// elimina una playa de estacionamiento
        /// </summary>
        /// <param name="id">es el id de la playa</param>
        public void eliminarPlaya(int id)
        {
            //elimina la playa 
            playas.Remove(playas.Find(id));
            //guarda los cambios
            SaveChanges();
        }        
        
    }//end PlayaDeEstacionamiento
}
