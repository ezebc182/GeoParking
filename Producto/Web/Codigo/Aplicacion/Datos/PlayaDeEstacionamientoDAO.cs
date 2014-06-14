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
        /// <param name="idPlaya">es el ID de la playa</param>
        /// <returns>un objeto de Playa de Estacionamiento</returns>
        public PlayaDeEstacionamiento buscarPlayaPorId(int idPlaya)
        {
            //retorna la playa
            return contexto.buscarPlayaPorId(idPlaya);
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
        /// <param name="playa">objeto Playa de Estacionamiento</param>
        public void registrarPlaya(PlayaDeEstacionamiento playa)
        {
            //registra la playa
            contexto.registrarPlaya(playa);
        }

        /// <summary>
        /// actualiza una playa de estacionamiento
        /// </summary>
        /// <param name="playa">objeto Playa de Estacionamiento</param>
        public void actualizarPlaya(PlayaDeEstacionamiento playa)
        {
            //actualiza la playa
            contexto.actualizarPlaya(playa);
        }

        /// <summary>
        /// elimina una playa de estacionamiento
        /// </summary>
        /// <param name="idPlaya">es el ID de la playa</param>
        public void eliminarPlaya(int idPlaya)
        {
            //elimina la playa
            contexto.eliminarPlaya(idPlaya);
        }        
    }
}
