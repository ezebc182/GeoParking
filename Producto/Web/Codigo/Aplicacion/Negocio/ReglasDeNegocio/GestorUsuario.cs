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

        /// <summary>
        /// Valida los datos de usuario, y de ser correctos la registra.
        /// </summary>
        /// <param name="usuario">playa a registrar</param>
        /// <returns>Resultado</returns>
        public Resultado RegistrarUsuario(Usuario usuario)
        {
            var resultado = ValidarRegistracion(usuario);

            if (resultado.Ok)
            {
                usuarioDao.Create(usuario);
            }

            return resultado;
        }

        /// <summary>
        /// Valida los datos de usuario para registrarlo
        /// </summary>
        /// <param name="usuario">playa que se esta registrando</param>
        /// <returns>Resultado</returns>
        private Resultado ValidarRegistracion(Usuario usuario)
        {
            var resultado = new Resultado();

            if (usuario.Nombre == "" && usuario.Mail == "" && usuario.NombreUsuario == "" && usuario.Contraseña == ""
                && usuario.Apellido == "")
            {
                resultado.AgregarMensaje("Debe ingresar todos los datos para la registracion.");
            }

            return resultado;
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
        public void AsigarRolAUsuario(int idUsuario, int idRol)
        {
            Usuario usuario = usuarioDao.FindById(idUsuario);
            usuario.RolId = idRol;
            usuarioDao.Update(usuario);
        }
    }
}
