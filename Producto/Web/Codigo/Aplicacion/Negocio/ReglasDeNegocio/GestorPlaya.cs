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
    public class GestorPlaya
    {
        IRepositorioPlayaDeEstacionamiento playaDao;
        IRepositorioTipoDePlaya tipoDao;
        IRepositorioDiaAtencion diaAtencionDao;

        public GestorPlaya()
        {
            playaDao = new RepositorioPlayaDeEstacionamiento();
            tipoDao = new RepositorioTipoDePlaya();
            diaAtencionDao = new RepositorioDiaAtencion();
        }

        public GestorPlaya(IRepositorioPlayaDeEstacionamiento repositorioPlaya, IRepositorioTipoDePlaya repositorioTipoPlaya)
        {
            playaDao = repositorioPlaya;
            tipoDao = repositorioTipoPlaya;
        }


        public Resultado RegistrarPlaya(PlayaDeEstacionamiento playa)
        {
            var resultado = ValidarRegistracion(playa);

            if (resultado.Ok)
            {
                playaDao.Create(playa);
            }

            return resultado;
        }

        private Resultado ValidarRegistracion(PlayaDeEstacionamiento playa)
        {
            var resultado = new Resultado();

            

            return resultado;
        }

        public Resultado ActualizarPlaya(PlayaDeEstacionamiento playa)
        {
            var resultado = ValidarActualizacion();

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
                playaDao.Delete(m => m.Id == idPlaya);
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
            return playaDao.FindById(idPlaya);
        }

        public IList<PlayaDeEstacionamiento> BuscarPlayaPorNombre(string nombre)
        {
            var lista = playaDao.FindWhere(m => m.Nombre.Contains(nombre) && !m.FechaBaja.HasValue);

            foreach (var playa in lista)
            {
                //StringBuilder extras = new StringBuilder();
                //extras.Append(playa.Autos ? "Autos" : "");
                //extras.Append(playa.Motos ? " Motos" : "");
                //extras.Append(playa.Bicicletas ? " Bicicletas" : "");
                //extras.Append(playa.Utilitarios ? " Utilitarios" : "");
                playa.TipoPlayaNombre = tipoDao.FindById(playa.TipoPlayaId).Nombre;
                //playa.Extras = extras.ToString();
            }
            return lista;
        }

        public IList<TipoPlaya> BuscarTipoPlayas()
        {
            return tipoDao.FindAll();
        }

        public DiaAtencion GetDiaAtencionById(int IdDiaAtencionSeleccionado)
        {
           return diaAtencionDao.FindById(IdDiaAtencionSeleccionado);
        }
    }
}
