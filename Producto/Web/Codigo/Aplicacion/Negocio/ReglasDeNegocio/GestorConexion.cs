using Datos;
using Entidades;
using Newtonsoft.Json;
using ReglasDeNegocio.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReglasDeNegocio
{
    public class GestorConexion
    {
        IRepositorioConexion daoConexion;

        public GestorConexion()
        {
            daoConexion = new RepositorioConexion();
        }

        public IList<Conexion> BuscarConexiones()
        {
            return daoConexion.FindWhere(x => x.FechaBaja == null);
        }

        public IList<Conexion> BuscarMisConexiones(string usuario)
        {
            return daoConexion.FindWhere(x => x.FechaBaja == null && x.UsuarioResponsable == usuario);
        }

        public string CrearConexionJSON(Conexion Conexion)
        {
            return JsonConvert.SerializeObject(RegistrarNuevaConexion(Conexion));
        }

        public bool RegistrarNuevaConexion(Conexion Conexion)
        {
            var resultado = new Resultado();

            if (resultado.Ok)
            {
                daoConexion.Create(Conexion);
            }

            return resultado.Ok;
        }

        public Conexion BuscarConexion(int id)
        {
            return daoConexion.FindWhere(x => x.FechaBaja == null && x.Id == id).FirstOrDefault();
        }

        public bool UpdateConexion(Conexion Conexion)
        {
            var resultado = new Resultado();

            if (resultado.Ok)
            {
                daoConexion.Update(Conexion);
            }

            return resultado.Ok;
        }
    }
}

