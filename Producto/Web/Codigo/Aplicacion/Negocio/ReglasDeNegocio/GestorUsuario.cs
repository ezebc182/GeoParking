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
    public class GestorUsuario
    {
        IRepositorioUsuario usuarioDao;
        IRepositorioRol rolDao;

        public GestorUsuario()
        {
            usuarioDao = new RepositorioUsuario();
            rolDao = new RepositorioRol();
        }

        public GestorUsuario(IRepositorioUsuario usuario, IRepositorioRol rol)
        {
            usuarioDao = usuario;
            rolDao = rol;
        }

        public IList<Usuario> BuscarUsuarios()
        {
            return usuarioDao.FindAll();
        }

        public Rol BuscarRolPorUsuarioId(int id)
        {
            return rolDao.FindById(id);
        }
        public IList<Rol> BuscarRoles()
        {
            return rolDao.FindAll();
        }
    }
}
