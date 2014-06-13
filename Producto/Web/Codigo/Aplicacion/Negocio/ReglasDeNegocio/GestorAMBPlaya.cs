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

	    public void registrarPlaya(PlayaDeEstacionamiento p)
	    {
		    playaDao.registrarPlaya(p);
	    }	

	    public void actulaizarPlaya(PlayaDeEstacionamiento p)
	    {
            playaDao.actualizarPlaya(p);
	    }

	    public void eliminarPlaya(int id)
	    {
            playaDao.eliminarPlaya(id);
	    }

        public PlayaDeEstacionamiento buscarPlayaPorId(int id)
        {
            return playaDao.buscarPlayaPorId(id);
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
