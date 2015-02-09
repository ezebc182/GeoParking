using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using ReglasDeNegocio.Util;
using Datos;
using Newtonsoft.Json;

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

        public IList<Permiso> BuscarPermisosPorRol(int idRol)
        {
            IList<Permiso> permisos = permisoDao.FindWhere(p => p.Roles.Any(r => r.Id == idRol));
            foreach (Permiso permiso in permisos)
            {
                permiso.Roles = null;
            }
            return permisos;
        }

        public IList<Rol> BuscarRolesPorPermiso(Permiso permiso)
        {
            IList<Rol> roles = rolDao.FindWhere(x => x.Permisos.Any(p => p.Id == permiso.Id));
            return roles;
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
            permiso.Roles = BuscarRolesPorPermiso(permiso);
            return permiso;
        }

        public bool GuardarRol(Rol rol)
        {
            Resultado resultado = new Resultado();
            ValidarDatosGralesRol(rol, resultado);
            if (resultado.Ok)
            {
                rolDao.Update(rol);
            }
            return resultado.Ok;
        }

        public bool CrearRol(Rol rol)
        {
            Resultado resultado = new Resultado();
            ValidarDatosGralesRol(rol, resultado);
            if (resultado.Ok)
            {
                rolDao.Create(rol);
            }
            return resultado.Ok;
        }

        private void ValidarDatosGralesRol(Rol rol, Resultado resultado)
        {
            if ((string.IsNullOrEmpty(rol.Nombre)) || (string.IsNullOrEmpty(rol.Descripcion)))
            {
                resultado.AgregarMensaje("Debe ingresar todos los datos del rol.");
            }
        }

        public string GetPermisosJSON(int id)
        {
            return JsonConvert.SerializeObject(BuscarPermisosPorRol(id));
        }

        public string ResultadoGuardarJSON(Rol rol)
        {
            return JsonConvert.SerializeObject(GuardarRol(rol));
        }

        public string ResultadoCrearRolJSON(Rol rol)
        {
            return JsonConvert.SerializeObject(CrearRol(rol));
        }

        public Resultado GuardarPermiso(IList<Permiso> permiso)
        {
            Resultado resultado = new Resultado();
            return resultado;
        }
    }
}
