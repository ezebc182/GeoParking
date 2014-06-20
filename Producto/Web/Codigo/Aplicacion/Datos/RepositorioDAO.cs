using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;

namespace Datos
{
    //interfaces que implementan la interface IRepositorio 
    public interface IRepositorioPlayaDeEstacionamiento : IRepositorio<PlayaDeEstacionamiento> { }
    public interface IRepositorioTipoDePlaya : IRepositorio<TipoPlaya> { }

    //Clases DAO para cada entidad que heredan de la clase Repositorio
    public class RepositorioPlayaDeEstacionamiento : Repositorio<PlayaDeEstacionamiento>, IRepositorioPlayaDeEstacionamiento { }
    public class RepositorioTipoDePlaya : Repositorio<TipoPlaya>, IRepositorioTipoDePlaya { }
    
}
