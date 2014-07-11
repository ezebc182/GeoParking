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

        public GestorHorario(IRepositorioDiaAtencion repositorioHorario)
        {
            diaAtencionDao = repositorioHorario;
        }


        public Resultado RegistrarHorario(Horario horario)
        {
            var resultado = ValidarRegistracion(horario);

            if (resultado.Ok)
            {
                horarioDao.Create(horario);
            }

            return resultado;
        }

        private Resultado ValidarRegistracion(Horario horario)
        {
            var resultado = new Resultado();



            return resultado;
        }

        public Resultado ActualizarHorario(Horario horario)
        {
            var resultado = ValidarActualizacion();

            if (resultado.Ok)
            {
                horarioDao.Update(horario);
            }
            return resultado;
        }


        private Resultado ValidarActualizacion()
        {
            var resultado = new Resultado();

            //Agregar validaciones

            return resultado;
        }

        public Resultado EliminarHorario(int idHorario)
        {
            var resultado = ValidarEliminacion();

            if (resultado.Ok)
            {
                horarioDao.Delete(m => m.Id == idHorario);
            }

            return resultado;
        }

        private Resultado ValidarEliminacion()
        {
            var resultado = new Resultado();

            //Agregar validaciones

            return resultado;
        }


        public Horario BuscarHorarioPorId(int idHorario)
        {
            return horarioDao.FindById(idHorario);
        }

        public DiaAtencion GetDiaAtencionById(int IdDiaAtencionSeleccionado)
        {
            return diaAtencionDao.FindById(IdDiaAtencionSeleccionado);
        }
                
        public IList<DiaAtencion> BuscarDiasDeAtencion()
        {
            return diaAtencionDao.FindAll();
        }
    }
}
