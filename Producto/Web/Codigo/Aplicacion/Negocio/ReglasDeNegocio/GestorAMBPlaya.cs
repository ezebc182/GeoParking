using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using Datos;

namespace ReglasDeNegocio
{
    public class GestorAMBPlaya
    {
        PlayaDeEstacionamientoDAO playaDao;
        TipoPlayaDAO tipoDao;

        public GestorAMBPlaya()
        {
            playaDao = new PlayaDeEstacionamientoDAO();
            tipoDao = new TipoPlayaDAO();
	    }

	    public void registrarPlaya(PlayaDeEstacionamiento playa)
	    {
		    playaDao.registrarPlaya(playa);
	    }	

	    public void actulaizarPlaya(PlayaDeEstacionamiento playa)
	    {
            playaDao.actualizarPlaya(playa);
	    }

	    public void eliminarPlaya(int idPlaya)
	    {
            playaDao.eliminarPlaya(idPlaya);
	    }

        public PlayaDeEstacionamiento buscarPlayaPorId(int idPlaya)
        {
            return playaDao.buscarPlayaPorId(idPlaya);
        }

        public List<PlayaDeEstacionamiento> buscarPlayaPorNombre(string nombre)
        {
            return playaDao.buscarPlayaPorNombre(nombre);
        }

        public List<TipoPlaya> buscarTipoPlayas()
        {
            return tipoDao.buscarTiposPlayas();
        }
    }
}
