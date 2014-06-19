using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using ReglasDeNegocio.Util;
using Datos;

namespace ReglasDeNegocio
{
    public class GestorABMPlaya
    {
        PlayaDeEstacionamientoDAO playaDao;
        TipoPlayaDAO tipoDao;

        public GestorABMPlaya()
        {
            playaDao = new PlayaDeEstacionamientoDAO();
            tipoDao = new TipoPlayaDAO();
	    }


	    public Resultado RegistrarPlaya(PlayaDeEstacionamiento playa)
	    {
            var resultado = ValidarRegistracion();
            
            if (resultado.Ok)
            {
                playaDao.registrarPlaya(playa);
            }

            return resultado;
        }

        private Resultado ValidarRegistracion()
        {
            var resultado = new Resultado();

            //Agregar validaciones

            return resultado;
        }
	    
        public Resultado ActualizarPlaya(PlayaDeEstacionamiento playa)
	    {
            var resultado = ValidarRegistracion();
            
            if (resultado.Ok)
            {
                playaDao.actualizarPlaya(playa);
            }
            return resultado;
        }


        private Resultado ValidarActualizacion()
        {
            var resultado = new Resultado();

            //Agregar validaciones

            return resultado;
        }
	    
	    public Resultado EliminarPlaya(int idPlaya)
	    {
            var resultado = ValidarEliminacion();
            
            if (resultado.Ok)
            {
                playaDao.eliminarPlaya(idPlaya);
            }

            return resultado;
	    }
        
        private Resultado ValidarEliminacion()
        {
            var resultado = new Resultado();

            //Agregar validaciones

            return resultado;
        }
	    

        public PlayaDeEstacionamiento BuscarPlayaPorId(int idPlaya)
        {
            return playaDao.buscarPlayaPorId(idPlaya);
        }

        public List<PlayaDeEstacionamiento> BuscarPlayaPorNombre(string nombre)
        {
            return playaDao.buscarPlayaPorNombre(nombre);
        }

        public List<TipoPlaya> BuscarTipoPlayas()
        {
            return tipoDao.buscarTiposPlayas();
        }
    }
}
