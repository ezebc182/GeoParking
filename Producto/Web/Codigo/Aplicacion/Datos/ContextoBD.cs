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



        //TODOS LOS METODOS DE PLAYA DE ESTACIONAMIENTO
        /// <summary>
        /// busca playa de estacionamiento por el ID
        /// </summary>
        /// <param name="id">es el ID de la playa</param>
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
            List<PlayaDeEstacionamiento> playasEstacionamientos = new List<PlayaDeEstacionamiento>();

            //lista de playas existente con el nombre a buscar
            var list = playas.Where(m => m.nombre == nombre);

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
        /// <param name="id">es el ID de la playa</param>
        public void eliminarPlaya(int id)
        {
            //elimina la playa 
            playas.Remove(playas.Find(id));
            //guarda los cambios
            SaveChanges();
        }        

        //TODOS LOS METODOS DE TIPO DE PLAYA

        /// <summary>
        /// Busca tipo de playa por ID
        /// </summary>
        /// <param name="id">ID del tipo de playa</param>
        /// <returns>Objeto TipoPlaya</returns>
        public TipoPlaya buscarTipoPlayaPorId(int id)
        {
            //retorno la playa con el id
            return tiposPlayas.Find(id);
        }

        /// <summary>
        /// Buscar tipo de playa por nombre
        /// </summary>
        /// <param name="nombre">el nombre del tipo de playa</param>
        /// <returns>Lsita de objetos Tipolaya</returns>
        public List<TipoPlaya> buscarTipoPlayaPorNombre(string nombre)
        {
            //lista de playas de estacionamiento a devolver
            List<TipoPlaya> tipos = new List<TipoPlaya>();

            //lista de playas existente con el nombre a buscar
            var list = tiposPlayas.Where(m => m.nombre == nombre);

            //carga de las playas a la lista
            foreach (TipoPlaya tipoPlaya in list)
                tipos.Add(tipoPlaya);

            //retornar la lista
            return tipos;
        }

        /// <summary>
        /// Registra nuevo tipo de playa
        /// </summary>
        /// <param name="tp">Objeto tipo de playa</param>
        public void registrarTipoPlaya(TipoPlaya tp)
        {
            //agrego la playa a la BD
            tiposPlayas.Add(tp);
            //guardo los cambios
            SaveChanges();
        }

        /// <summary>
        /// Actualiza un tipo de playa
        /// </summary>
        /// <param name="tp">Objeto TipoPlaya</param>
        public void actualizarTipoPlaya(TipoPlaya tp)
        {
            Entry(tp);
            SaveChanges();
        }

        /// <summary>
        /// Elimina un tipo de playa por ID
        /// </summary>
        /// <param name="id">ID del tipo de playa</param>
        public void eliminarTipoPlaya(int id)
        {
            //elimino la playa con el id
            tiposPlayas.Remove(tiposPlayas.Find(id));
            //guardo los cambios
            SaveChanges();
        }

        public List<TipoPlaya> buscarTiposPlayas()
        {
            //lista de las playas a retornar
            List<TipoPlaya> listaTiposPlayas = new List<TipoPlaya>();

            //lista de playas existente con el nombre a buscar
            var list = tiposPlayas;

            //carga de las playas a la lista
            foreach (TipoPlaya tipo in list)
                listaTiposPlayas.Add(tipo);

            //retorna la lista
            return listaTiposPlayas;
        }

    }
}
