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
            IList<Rol> roles = rolDao.FindAll();
            foreach (Rol rol in roles)
            {
                IList<Permiso> permisos = BuscarPermisosPorRol(rol);
                rol.Permisos = permisos;
            }
            return roles;
        }
        public IList<Permiso> BuscarPermisos()
        {
            IList<Permiso> permisos = permisoDao.FindAll();
            foreach (Permiso permiso in permisos)
            {
                permiso.Roles = rolDao.FindWhere(p => p.Permisos.Any(r => p.Id == permiso.Id));
            }
            return permisos;
        }
        public IList<Permiso> BuscarPermisosPorRol(Rol rol)
        {
            IList<Permiso> permisos = permisoDao.FindWhere(p => p.Roles.Any(r => r.Id == rol.Id));
            foreach (Permiso permiso in permisos)
            {
                permiso.Roles = rolDao.FindWhere(p => p.Permisos.Any(r => p.Id == permiso.Id));
            }
            return permisos;
        }
        public Rol BuscarRol(int idRol)
        {
            Rol rol = rolDao.FindById(idRol);
            rol.Permisos = permisoDao.FindWhere(p => p.Roles.Any(r => r.Id == rol.Id));
            return rol;
        }
        public Permiso BuscarPermiso(int id)
        {
            Permiso permiso = permisoDao.FindById(id);
            permiso.Roles = rolDao.FindWhere(p => p.Permisos.Any(r => p.Id == permiso.Id));
            return permiso;
        }

        public Resultado GuardarRol(Rol rol)
        {
            Resultado resultado = new Resultado();

            rolDao.Update(rol);

            return resultado;
        }

        public Resultado CrearRol(Rol rol)
        {
            Resultado resultado = new Resultado();

            if (resultado.Ok)
            {
                rolDao.Create(rol);
            }
            return resultado;
        }
    }
}
