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
        /// Buscar los tipoPlayas de estacionamiento vigentes
        /// </summary>
        /// <returns>Listado de TiposPlayas vigentes</returns>
        public List<TipoPlaya> buscarTiposPlayas()
        {
            //lista de las playas a retornar
            List<TipoPlaya> ListaTiposPlayasEstacionamientos = new List<TipoPlaya>();

            //lista de playas existente con el nombre a buscar
            var list = contexto.tiposPlayas.Where(m => m.FechaBaja == null);

            //carga de las playas a la lista
            foreach (TipoPlaya tipo in list)
                ListaTiposPlayasEstacionamientos.Add(tipo);

            //retorna la lista
            return ListaTiposPlayasEstacionamientos;
        }

        /// <summary>
        /// Busca tipo de playa por ID
        /// </summary>
        /// <param name="idTipoPlaya">ID del tipo de playa</param>
        /// <returns>Objeto TipoPlaya</returns>
        public TipoPlaya buscarTipoPlayaPorId(int idTipoPlaya)
        {
            //retorno la playa con el id
            TipoPlaya tipoPlaya = new TipoPlaya();

            //lista de playas existente con el nombre a buscar
            var list = contexto.tiposPlayas.Where(m => m.Id==idTipoPlaya && m.FechaBaja == null);

            //carga de las playas a la lista
            foreach (TipoPlaya tipo in list)
                tipoPlaya=tipo;

            //retorna la lista
            return tipoPlaya;
        }

        /// <summary>
        /// Buscar tipo de playa por nombre
        /// </summary>
        /// <param name="nombre">el nombre del tipo de playa</param>
        /// <returns>Lsita de objetos Tipolaya</returns>
        public List<TipoPlaya> buscarTipoPlayaPorNombre(string nombre)
        {
            //lista de playas de estacionamiento a devolver
            List<TipoPlaya> listaTipos = new List<TipoPlaya>();

            //lista de playas existente con el nombre a buscar
            var list = contexto.tiposPlayas.Where(m => m.Nombre == nombre && m.FechaBaja == null);

            //carga de las playas a la lista
            foreach (TipoPlaya tipoPlaya in list)
                listaTipos.Add(tipoPlaya);

            //retornar la lista
            return listaTipos;
        }

        /// <summary>
        /// Registra nuevo tipo de playa
        /// </summary>
        /// <param name="tipoPlaya">Objeto tipo de playa</param>
        public void registrarTipoPlaya(TipoPlaya tipoPlaya)
        {
            //registra un tipo de playa
            contexto.tiposPlayas.Add(tipoPlaya);
            contexto.SaveChanges();
        }

        /// <summary>
        /// Actualiza un tipo de playa
        /// </summary>
        /// <param name="tipoPlaya">Objeto TipoPlaya</param>
        public void actualizarTipoPlaya(TipoPlaya tipoPlaya)
        {
            //actualizar un tipo de playa
            contexto.Entry(tipoPlaya);
            contexto.SaveChanges();
        }            

        /// <summary>
        /// Elimina un tipo de playa por ID
        /// </summary>
        /// <param name="idTipoPlaya">ID del tipo de playa</param>
        public void eliminarTipoPlaya(int idTipoPlaya)
        {
            //eliminar un tipo de playa(Actualiza fecha baja) 
            TipoPlaya tipoPlaya = buscarTipoPlayaPorId(idTipoPlaya);
            tipoPlaya.FechaBaja = DateTime.Now;
            actualizarTipoPlaya(tipoPlaya);           
        }       

    }
}
