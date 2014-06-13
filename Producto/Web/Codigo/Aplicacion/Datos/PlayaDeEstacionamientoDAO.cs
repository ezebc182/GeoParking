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
        /// busca playa de estacionamiento por el ID
        /// </summary>
        /// <param name="id">es el ID de la playa</param>
        /// <returns>un objeto de Playa de Estacionamiento</returns>
        public PlayaDeEstacionamiento buscarPlayaPorId(int id)
        {
            //retorna la playa
            return contexto.buscarPlayaPorId(id);
        }

        /// <summary>
        /// busca playas filtradas por nombre
        /// </summary>
        /// <param name="nombre">es un string nombre de la playa</param>
        /// <returns>lista de objetos Playa de Estacionamiento</returns>
        public List<PlayaDeEstacionamiento> buscarPlayaPorNombre(string nombre)
        {
            //retorna la lista
            return contexto.buscarPlayaPorNombre(nombre);
        }

        /// <summary>
        /// registra una playa de estacionamiento
        /// </summary>
        /// <param name="p">objeto Playa de Estacionamiento</param>
        public void registrarPlaya(PlayaDeEstacionamiento p)
        {
            //registra la playa
            contexto.registrarPlaya(p);
        }

        /// <summary>
        /// actualiza una playa de estacionamiento
        /// </summary>
        /// <param name="p">objeto Playa de Estacionamiento</param>
        public void actualizarPlaya(PlayaDeEstacionamiento p)
        {
            //actualiza la playa
            contexto.actualizarPlaya(p);
        }

        /// <summary>
        /// elimina una playa de estacionamiento
        /// </summary>
        /// <param name="id">es el ID de la playa</param>
        public void eliminarPlaya(int id)
        {
            //elimina la playa
            contexto.eliminarPlaya(id);
        }        
    }
}
