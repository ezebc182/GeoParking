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
    public class GestorUsuario
    {
        IRepositorioUsuario usuarioDao;
        IRepositorioRol rolDao;
        IRepositorioPermiso permisoDao;
        Encriptacion cifrar;


        public GestorUsuario()
        {
            permisoDao = new RepositorioPermiso();
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

        private Resultado ValidarUpdate(Usuario usuario)
        {
            var resultado = new Resultado();

            if (usuario.Nombre == "" && usuario.Mail == "" && usuario.NombreUsuario == "" && usuario.Contraseña == ""
                && usuario.Apellido == "")
            {
                resultado.AgregarMensaje("Debe ingresar todos los datos para la registracion.");
            }

            return resultado;
        }

        public Usuario BuscarUsuarioByNombreOEmail(string usuario)
        {
            return usuarioDao.FindWhere(x => (x.Mail.Equals(usuario) || x.NombreUsuario.Equals(usuario))).FirstOrDefault();
        }

        public Usuario Login(string usuario,string contraseña)
        {
            string cifrada = Encriptar(contraseña);
            Usuario resultado = usuarioDao.FindWhere(x => (x.Mail.Equals(usuario) || x.NombreUsuario.Equals(usuario)) && x.Contraseña.Equals(cifrada)).FirstOrDefault();
            if (resultado != null)
            {
                resultado.Rol = rolDao.FindWhere(x => x.Id == resultado.RolId).First();
                resultado.Rol.Permisos = permisoDao.FindWhere(x => x.Roles.Any(p => p.Id == resultado.RolId));
            }
            return resultado;
        }

        public Usuario BuscarUsuario(int id)
        {
            return usuarioDao.FindWhere(x => x.Id == id).FirstOrDefault();
        }

        public string BuscarUsuarioJSON(int id)
        {
            return JsonConvert.SerializeObject(BuscarUsuario(id).RolId);
        }

        public Usuario ValidarUsuarioIngresado(string usuario)
        {
            IList<Usuario> resultado = usuarioDao.FindWhere(x => x.NombreUsuario.Equals(usuario));
            return resultado.FirstOrDefault();
        }

        public Usuario ValidarUsuarioYMailIngresado(string usuario)
        {
            IList<Usuario> resultado = usuarioDao.FindWhere(x => x.NombreUsuario.Equals(usuario) || x.Mail.Equals(usuario));
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

        public string ValidacionLogin(string usuario, string contraseña)
        {
            string cifrada = Encriptar(contraseña);
            Usuario resultado = usuarioDao.FindWhere(x => (x.Mail.Equals(usuario) || x.NombreUsuario.Equals(usuario)) && x.Contraseña.Equals(cifrada)).FirstOrDefault();
            if (resultado != null)
            {
                resultado.Rol = rolDao.FindWhere(x => x.Id == resultado.RolId).First();
                resultado.Rol.Permisos = permisoDao.FindWhere(x => x.Roles.Any(p => p.Id == resultado.RolId));
                return "true";
            }
            else
            {
                return "false";
            }
        }

        public IList<Usuario> BuscarUsuarios()
        {
            return usuarioDao.FindAll();
        }
        public Usuario BuscarUsuarioPorId(int id)
        {
            var usuario = usuarioDao.FindById(id);
            usuario.Rol = rolDao.FindById(usuario.RolId);
            return usuario;
        }

        public string GetDatosUsuarioJSON(int id)
        {
            return JsonConvert.SerializeObject(usuarioDao.FindWhere(u => u.Id == id ));
        }

        public string AsigarRolAUsuarioJSON(int idUsuario, int idRol)
        {
            return JsonConvert.SerializeObject(AsigarRolAUsuario(idUsuario, idRol));
        }

        public string RegistrarUsuarioJSON(Usuario usuario)
        {
            return JsonConvert.SerializeObject(RegistrarNuevoUsuario(usuario));
        }

        public bool RegistrarNuevoUsuario(Usuario usuario)
        {
            var resultado = ValidarRegistracion(usuario);

            if (resultado.Ok)
            {
                usuarioDao.Create(usuario);
            }

            return resultado.Ok;
        }

        public bool AsigarRolAUsuario(int idUsuario, int idRol)
        {
            Resultado resultado = new Resultado();

            Usuario usuario = usuarioDao.FindById(idUsuario);
            usuario.RolId = idRol;
            Rol rol = rolDao.FindById(idRol);
            usuario.Rol = rol;
            usuarioDao.Update(usuario);

            return resultado.Ok;
        }

        public bool UpdateUsuario(Usuario usuario)
        {
            var resultado = ValidarUpdate(usuario);
            if (resultado.Ok)
            {
                usuarioDao.Update(usuario);
            }
            return resultado.Ok;
        }

        public Usuario BuscarPorNombreDeUsuario(string usuario)
        {
            return usuarioDao.FindWhere(x=> x.NombreUsuario == usuario).FirstOrDefault();
        }

        public string GuardarUsuarioJSON(Usuario usuario)
        {
            return JsonConvert.SerializeObject(UpdateUsuario(usuario));
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
