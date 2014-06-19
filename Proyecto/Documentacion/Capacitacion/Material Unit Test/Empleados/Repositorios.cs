using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace Empleados
{
    public interface IRepositorioEmpleado : IRepositorio<Empleado> { }
    public interface IRepositorioTarjeta : IRepositorio<Tarjeta> { }

    public class RepositorioEmpleados : Repositorio<Empleado>, IRepositorioEmpleado { }
    public class RepositorioTarjetas : Repositorio<Tarjeta>, IRepositorioTarjeta { }

}
