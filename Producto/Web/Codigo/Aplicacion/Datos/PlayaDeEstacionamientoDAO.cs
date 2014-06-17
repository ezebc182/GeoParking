using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;

namespace Datos
{
    public class PlayaDeEstacionamientoDAO
    {
        ContextoBD contexto;

        /// <summary>
        /// Constructor
        /// </summary>
        public PlayaDeEstacionamientoDAO()
        {
            contexto = ContextoBD.getInstace();
        }

        /// <summary>
        /// Buscar las playas de estacionamiento vigentes
        /// </summary>
        /// <returns>Listado de Playas vigentes</returns>
        public List<PlayaDeEstacionamiento> buscarPlayas()
        {
            //lista de las playas a retornar
            List<PlayaDeEstacionamiento> ListaPlayasEstacionamientos = new List<PlayaDeEstacionamiento>();

            //lista de playas existente con el nombre a buscar
            var list = contexto.playas.Where(m => m.FechaBaja == null);

            //carga de las playas a la lista
            foreach (PlayaDeEstacionamiento playa in list)
                ListaPlayasEstacionamientos.Add(playa);

            //retorna la lista
            return ListaPlayasEstacionamientos;
        }

        /// <summary>
        /// busca playa de estacionamiento por el ID
        /// </summary>
        /// <param name="idPlaya">es el ID de la playa</param>
        /// <returns>un objeto de Playa de Estacionamiento</returns>
        public PlayaDeEstacionamiento buscarPlayaPorId(int idPlaya)
        {
            //retorna la playa
            //lista de las playas a retornar
            PlayaDeEstacionamiento playa = new PlayaDeEstacionamiento();

            //lista de playas existente con el nombre a buscar
            var list = contexto.playas.Where(m => m.Id=idPlaya && m.FechaBaja == null);

            //carga de las playas a la lista
            foreach (PlayaDeEstacionamiento item in list)
                playa=item;

            //retorna la lista
            return playa;
        }

        /// <summary>
        /// busca playas filtradas por nombre
        /// </summary>
        /// <param name="nombre">es un string nombre de la playa</param>
        /// <returns>lista de objetos Playa de Estacionamiento</returns>
        public List<PlayaDeEstacionamiento> buscarPlayaPorNombre(string nombre)
        {
            //lista de las playas a retornar
            List<PlayaDeEstacionamiento> ListaPlayasEstacionamientos = new List<PlayaDeEstacionamiento>();

            //lista de playas existente con el nombre a buscar
            var list = contexto.playas.Where(m => m.Nombre.Contains(nombre) && m.FechaBaja==null);

            //carga de las playas a la lista
            foreach (PlayaDeEstacionamiento playa in list)
                ListaPlayasEstacionamientos.Add(playa);

            //retorna la lista
            return ListaPlayasEstacionamientos;
        }

        /// <summary>
        /// registra una playa de estacionamiento
        /// </summary>
        /// <param name="playa">objeto Playa de Estacionamiento</param>
        public void registrarPlaya(PlayaDeEstacionamiento playa)
        {
            //registra la playa
            contexto.playas.Add(playa);
            contexto.SaveChanges();
        }

        /// <summary>
        /// actualiza una playa de estacionamiento
        /// </summary>
        /// <param name="playa">objeto Playa de Estacionamiento</param>
        public void actualizarPlaya(PlayaDeEstacionamiento playa)
        {
            //actualiza la playa
            contexto.Entry(playa);
            contexto.SaveChanges();
        }

        /// <summary>
        /// elimina una playa de estacionamiento
        /// </summary>
        /// <param name="idPlaya">es el ID de la playa</param>
        public void eliminarPlaya(int idPlaya)
        {
            //eliminar una playa(Actualiza fecha baja) 
            PlayaDeEstacionamiento playa = buscarPlayaPorId(idPlaya);
            playa.FechaBaja = DateTime.Now;
            actualizarPlaya(playa); 
        }        
    }
}
