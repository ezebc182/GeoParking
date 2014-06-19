using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Empleados;

namespace Empleados
{
    public class Gestor
    {
        RepositorioEmpleados repositorio = new RepositorioEmpleados();

        public IList<Empleado> BuscarLeo()
        {
            return repositorio.FindWhere(x => x.nombre == "Leo");
        }
    }
}
