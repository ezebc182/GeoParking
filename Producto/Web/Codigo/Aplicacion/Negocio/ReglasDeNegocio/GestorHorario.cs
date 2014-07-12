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
    public class GestorHorario
    {
        IRepositorioDiaAtencion diaAtencionDao;
        IRepositorioHorario horarioDao;

        public GestorHorario()
        {
            diaAtencionDao = new RepositorioDiaAtencion();
            horarioDao = new RepositorioHorario();
        }

        public GestorHorario(IRepositorioDiaAtencion diaAtencionDao,
        IRepositorioHorario horarioDao)
        {
            this.diaAtencionDao = diaAtencionDao;
            this.horarioDao = horarioDao;
        }
        /// <summary>
        /// Busca un horario por su id
        /// </summary>
        /// <param name="idHorario"></param>
        /// <returns></returns>
        public Horario BuscarHorarioPorId(int idHorario)
        {
            return horarioDao.FindById(idHorario);
        }
        /// <summary>
        /// Busca un dia de atencion por su id
        /// </summary>
        /// <param name="IdDiaAtencionSeleccionado"></param>
        /// <returns></returns>
        public DiaAtencion BuscarDiaAtencionPorId(int IdDiaAtencionSeleccionado)
        {
            return diaAtencionDao.FindById(IdDiaAtencionSeleccionado);
        }
        /// <summary>
        /// busca todos los dias de atencion
        /// </summary>
        /// <returns></returns>
        public IList<DiaAtencion> BuscarDiasDeAtencion()
        {
            return diaAtencionDao.FindAll();
        }
    }
}
