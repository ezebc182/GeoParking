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
            return permisoDao.FindWhere(p => p.Roles.Any(r => r.Id == rol.Id));
        }
        public Rol BuscarRol(int idRol)
        {
            return rolDao.FindById(idRol);
        }
        public Permiso BuscarPermiso(int id)
        {
            return permisoDao.FindById(id);
        }

        public int GuardarRol(Rol rol)
        {
            return rolDao.Update(rol);
        }

        public Rol CrearRol(Rol rol)
        {
            return rolDao.Create(rol);
        }
    }
}
