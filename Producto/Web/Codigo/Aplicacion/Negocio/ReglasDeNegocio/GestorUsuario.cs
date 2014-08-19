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
        Encriptacion cifrar;

        public GestorUsuario()
        {
            usuarioDao = new RepositorioUsuario();
            rolDao = new RepositorioRol();
            cifrar = new Encriptacion();
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
            
            if (ValidarUsuarioIngresado(usuario.NombreUsuario) !=null)
            {
                resultado.AgregarMensaje("Ya existe un usuario con ese nombre.");
            }

            if (usuario.Nombre == "" && usuario.Mail == "" && usuario.NombreUsuario == "" && usuario.Contraseña == ""
                && usuario.Apellido == "")
            {
                resultado.AgregarMensaje("Debe ingresar todos los datos para la registracion.");
            }

            return resultado;
        }

        public Usuario Login(string usuario,string contraseña)
        {
            string cifrada = Encriptar(contraseña);
            IList<Usuario> resultado = usuarioDao.FindWhere(x => (x.Mail.Equals(usuario) || x.NombreUsuario.Equals(usuario)) && x.Contraseña.Equals(cifrada));
            return resultado.FirstOrDefault();
        }

        public Usuario ValidarUsuarioIngresado(string usuario)
        {
            IList<Usuario> resultado = usuarioDao.FindWhere(x => x.NombreUsuario.Equals(usuario));
            return resultado.FirstOrDefault();
        }

        public Usuario ValidarEmailIngresado(string email)
        {
            IList<Usuario> resultado = usuarioDao.FindWhere(x => x.Mail.Equals(email));
            return resultado.FirstOrDefault();
        }

        public string Encriptar(string contraseña)
        {
            return cifrar.Encriptar(contraseña);
        }

        public string Desencriptar(string contraseña)
        {
            return cifrar.Desencriptar(contraseña);
        }

        public IList<Usuario> BuscarUsuarios()
        {
            return usuarioDao.FindAll();
        }
        public Usuario BuscarUsuarioPorId(int id)
        {
            return usuarioDao.FindById(id);
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
            Rol rol = rolDao.FindById(idRol);
            usuario.Rol = rol;
            usuarioDao.Update(usuario);
        }
    }
}
