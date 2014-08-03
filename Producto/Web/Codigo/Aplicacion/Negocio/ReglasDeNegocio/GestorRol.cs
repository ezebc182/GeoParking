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
    public class GestorRol
    {
        IRepositorioRol rolDao;
        IRepositorioPermiso permisoDao;

        public GestorRol()
        {
            rolDao = new RepositorioRol();
            permisoDao = new RepositorioPermiso();
        }
        public IList<Rol> BuscarRoles()
        {
            return rolDao.FindAll();
        }
        public IList<Permiso> BuscarPermisos()
        {
            return permisoDao.FindAll();
        }
        public IList<Permiso> BuscarPermisosPorRol(Rol rol)
        {
            return permisoDao.FindWhere(p => p.Roles.Contains(rol));
        }
        public Rol BuscarRol(int idRol)
        {
            return rolDao.FindById(idRol);
        }





    }
}
