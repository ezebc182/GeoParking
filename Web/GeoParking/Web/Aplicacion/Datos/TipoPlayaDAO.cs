using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;

namespace Datos
{
    class TipoPlayaDAO
    {
        ContextoBD contexto = new ContextoBD();

        /// <summary>
        /// Busca tipo de playa por ID
        /// </summary>
        /// <param name="id">ID del tipo de playa</param>
        /// <returns>Objeto TipoPlaya</returns>
        public TipoPlaya buscarTipoPlayaPorId(int id)
        {
            //retorno la playa con el id
            return contexto.buscarTipoPlayaPorId(id);
        }

        /// <summary>
        /// Buscar tipo de playa por nombre
        /// </summary>
        /// <param name="nombre">el nombre del tipo de playa</param>
        /// <returns>Lsita de objetos Tipolaya</returns>
        public List<TipoPlaya> buscarTipoPlayaPorNombre(string nombre)
        {
            //retornar la lista
            return contexto.buscarTipoPlayaPorNombre(nombre);
        }

        /// <summary>
        /// Registra nuevo tipo de playa
        /// </summary>
        /// <param name="tp">Objeto tipo de playa</param>
        public void registrarTipoPlaya(TipoPlaya tp)
        {
            //registra un tipo de playa
            contexto.registrarTipoPlaya(tp);
        }

        /// <summary>
        /// Actualiza un tipo de playa
        /// </summary>
        /// <param name="tp">Objeto TipoPlaya</param>
        public void actualizarTipoPlaya(TipoPlaya tp)
        {
            //actualizar un tipo de playa
            contexto.actualizarTipoPlaya(tp);
        }

        /// <summary>
        /// Elimina un tipo de playa por ID
        /// </summary>
        /// <param name="id">ID del tipo de playa</param>
        public void eliminarTipoPlaya(int id)
        {
            //eliminar un tipo de playa
            contexto.eliminarTipoPlaya(id);
        }       

    }
}
