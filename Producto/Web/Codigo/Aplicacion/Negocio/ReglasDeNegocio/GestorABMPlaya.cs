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
        RepositorioPlayaDeEstacionamiento playaDao;
        RepositorioTipoDePlaya tipoDao;
        

        public GestorABMPlaya()
        {
            playaDao = new RepositorioPlayaDeEstacionamiento();
            tipoDao = new RepositorioTipoDePlaya();
	    }


	    public Resultado RegistrarPlaya(PlayaDeEstacionamiento playa)
	    {
            var resultado = ValidarRegistracion();
            
            if (resultado.Ok)
            {
                playaDao.Create(playa);
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
                playaDao.Update(playa);
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
                playaDao.Delete(m => m.Id==idPlaya);
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
            return playaDao.FindWhere(m => m.Id==idPlaya && m.FechaBaja==null)[0];
        }

        public IList<PlayaDeEstacionamiento> BuscarPlayaPorNombre(string nombre)
        {
            return playaDao.FindWhere(m => m.Nombre.Contains(nombre));
        }

        public IList<TipoPlaya> BuscarTipoPlayas()
        {
            return tipoDao.FindAll();
        }
    }
}
