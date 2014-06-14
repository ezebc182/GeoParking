using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;

namespace Datos
{
    public class TipoPlayaDAO
    {
        ContextoBD contexto;

        /// <summary>
        /// Constructor
        /// </summary>
        public TipoPlayaDAO()
        {
            contexto = ContextoBD.getInstace();
        }

        /// <summary>
        /// Busca todos los tipos de playa
        /// </summary>
        /// <returns></returns>
        public List<TipoPlaya> buscarTiposPlayas()
        {
            return contexto.buscarTiposPlayas();
        }

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
        /// <param name="tipoPlaya">Objeto tipo de playa</param>
        public void registrarTipoPlaya(TipoPlaya tipoPlaya)
        {
            //registra un tipo de playa
            contexto.registrarTipoPlaya(tipoPlaya);
        }

        /// <summary>
        /// Actualiza un tipo de playa
        /// </summary>
        /// <param name="tipoPlaya">Objeto TipoPlaya</param>
        public void actualizarTipoPlaya(TipoPlaya tipoPlaya)
        {
            //actualizar un tipo de playa
            contexto.actualizarTipoPlaya(tipoPlaya);
        }

        /// <summary>
        /// Elimina un tipo de playa por ID
        /// </summary>
        /// <param name="idTipoPlaya">ID del tipo de playa</param>
        public void eliminarTipoPlaya(int idTipoPlaya)
        {
            //eliminar un tipo de playa
            contexto.eliminarTipoPlaya(idTipoPlaya);
        }       

    }
}
