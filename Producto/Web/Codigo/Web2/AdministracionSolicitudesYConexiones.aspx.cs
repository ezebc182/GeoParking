﻿using Entidades;
using ReglasDeNegocio;
using ReglasDeNegocio.Util;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web2
{
    public partial class AdministracionSolicitudesYConexiones : System.Web.UI.Page
    {
        private int rolId;
        private static int idUsuario;
        private static GestorUsuario gestorUsuario;
        private static GestorPlaya gestorPlaya;
        private static GestorSolicitud gestorSolicitud;
        private static GestorConexion gestorConexion;
        private static GestorEmails gestorMandarEmail;
        private static Encriptacion encriptacion;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (SessionUsuario != null)
                {
                    gestorSolicitud = new GestorSolicitud();
                    gestorConexion = new GestorConexion();
                    gestorUsuario = new GestorUsuario();
                    gestorMandarEmail = new GestorEmails();
                    gestorPlaya = new GestorPlaya();
                    encriptacion = new Encriptacion();
                    gestorSolicitud.BuscarSolicitudes();
                    gestorConexion.BuscarConexiones();
                    idUsuario = SessionUsuario.Id;
                    rolId = SessionUsuario.RolId;
                    if (rolId == 1)
                    {
                        t_solicitudes.InnerText = " Mis Solicitudes";
                        t_conexiones.InnerText = " Mis Conexiones";
                        btnModalConexion.Attributes["style"] = "display:none";
                        gvSolicitudes.DataSource = GetMisSolicitudes(SessionUsuario.Mail);
                        gvSolicitudes.DataBind();
                        gvConexiones.DataSource = GetMisConexiones(SessionUsuario.Mail);
                        gvConexiones.DataBind();
                    }
                    else
                    {
                        btnModalSolicitud.Attributes["style"] = "display:none";
                        gvSolicitudes.DataSource = GetSolicitudes();
                        gvSolicitudes.DataBind();
                        gvConexiones.DataSource = GetConexiones();
                        gvConexiones.DataBind();
                        hfUsuario.Value = "true";
                    }
                }
                else
                {
                    Response.Redirect("/web.aspx");
                }
            }
        }
        public Usuario SessionUsuario
        {
            get
            {
                if (Request.Cookies["SessionUsuario"] != null)
                {
                    Usuario sesion = new Usuario();
                    sesion.RolId = Int32.Parse(Request.Cookies["SessionUsuario"]["Rol"]);
                    sesion.NombreUsuario = Request.Cookies["SessionUsuario"]["NombreUsuario"];
                    sesion.Contraseña = Request.Cookies["SessionUsuario"]["Contraseña"];
                    sesion.Id = Int32.Parse(Request.Cookies["SessionUsuario"]["IdUsuario"]);
                    sesion.Nombre = Request.Cookies["SessionUsuario"]["Nombre"];
                    sesion.Apellido = Request.Cookies["SessionUsuario"]["Apellido"];
                    sesion.Mail = Request.Cookies["SessionUsuario"]["Mail"];
                    return sesion;
                }
                else
                {
                    return null;
                }
            }
        }

        private static DataTable GetSolicitudes()
        {
            DataTable dt = new DataTable();
            var resultado = gestorSolicitud.BuscarSolicitudes();
            dt.Columns.Add("Id");
            dt.Columns.Add("NombrePlaya");
            dt.Columns.Add("UsuarioResponsable");
            dt.Columns.Add("EstadoId");
            foreach (var item in resultado)
            {
                DataRow row = dt.NewRow();
                row["Id"] = item.Id;
                row["NombrePlaya"] = item.NombrePlaya;
                row["UsuarioResponsable"] = item.UsuarioResponsable;
                row["EstadoId"] = item.EstadoId;
                dt.Rows.Add(row);
            }
            return dt;
        }

        private static DataTable GetConexiones()
        {
            DataTable dt = new DataTable();
            var resultado = gestorConexion.BuscarConexiones();
            dt.Columns.Add("Id");
            dt.Columns.Add("Playa");
            dt.Columns.Add("UsuarioResponsable");
            dt.Columns.Add("Estado");
            foreach (var item in resultado)
            {
                PlayaDeEstacionamiento playa = gestorPlaya.BuscarPlayaPorId(item.PlayaDeEstacionamientoId);
                DataRow row = dt.NewRow();
                row["Id"] = item.Id;
                row["Playa"] = playa.Nombre + " - Direccion: " + playa.Calle + " " + playa.Numero + " " + playa.Ciudad;
                row["UsuarioResponsable"] = item.UsuarioResponsable;
                row["Estado"] = item.EstadoConfirmacion;
                dt.Rows.Add(row);
            }
            return dt;
        }

        private static DataTable GetMisSolicitudes(string usuario)
        {
            DataTable dt = new DataTable();
            var resultado = gestorSolicitud.BuscarMisSolicitudes(usuario);
            dt.Columns.Add("Id");
            dt.Columns.Add("NombrePlaya");
            dt.Columns.Add("UsuarioResponsable");
            dt.Columns.Add("EstadoId");
            foreach (var item in resultado)
            {
                DataRow row = dt.NewRow();
                row["Id"] = item.Id;
                row["NombrePlaya"] = item.NombrePlaya;
                row["UsuarioResponsable"] = item.UsuarioResponsable;
                row["EstadoId"] = item.EstadoId;
                dt.Rows.Add(row);
            }
            return dt;
        }

        private static DataTable GetMisConexiones(string usuario)
        {
            DataTable dt = new DataTable();
            var resultado = gestorConexion.BuscarMisConexiones(usuario);
            dt.Columns.Add("Id");
            dt.Columns.Add("Playa");
            dt.Columns.Add("UsuarioResponsable");
            dt.Columns.Add("Estado");
            foreach (var item in resultado)
            {
                PlayaDeEstacionamiento playa = gestorPlaya.BuscarPlayaPorId(item.PlayaDeEstacionamientoId);
                DataRow row = dt.NewRow();
                row["Id"] = item.Id;
                row["Playa"] = playa.Nombre + " - Direccion: " + playa.Calle + " " + playa.Numero + " " + playa.Ciudad;
                row["UsuarioResponsable"] = item.UsuarioResponsable;
                row["Estado"] = item.EstadoConfirmacion;
                dt.Rows.Add(row);
            }
            return dt;
        }

        protected void brnCrearSolicitud_Click(object sender, EventArgs e)
        {
            SolicitudConexion NuevaSolicitud = new SolicitudConexion();
            NuevaSolicitud.NombrePlaya = txtPlaya.Text;
            NuevaSolicitud.UsuarioResponsable = SessionUsuario.Mail;
            NuevaSolicitud.EstadoId = 6;
            var resultado = gestorSolicitud.RegistrarNuevaSolicitud(NuevaSolicitud);
            if (resultado == true)
            {
                string mensaje = "La solicitud se generó correctamente. Para avanzar en el proceso, toda la información solicitada debe ser enviada a GeoParking";
                mensaje += "\n\nINFORMACIÓN DE LA PLAYA";
                mensaje += "\n-Nombre\n-Tipo Playa\n-Teléfono\n-Email\n-Horario\n-Dirección (ciudad, calle, número)";
                mensaje += "\n-Vehículos Permitidos (tipo de vehíuclo - capacidad)\n-Precios (por hora, por 6hs, por 12 hs, etc)";
                mensaje += "\n\nINFORMACIÓN LEGAL";
                mensaje += "\n-Además de la información de la playa, el responsable debe presentar la documentación legal pertinente, que respalde la actividad ";
                mensaje += "económica llevada a cabo por la playa de estacionamiento";

                gestorMandarEmail.EnviarEmail(mensaje, SessionUsuario.Mail, "Creacion de Solicitud de Conexion en Geoparking");
                gvSolicitudes.DataSource = GetMisSolicitudes(SessionUsuario.Mail);
                gvSolicitudes.DataBind();
            }
        }

        protected void btnSi_Click(object sender, EventArgs e)
        {
            SolicitudConexion solicitud = gestorSolicitud.BuscarSolicitud(Int32.Parse(hfSolicitud.Value));
            solicitud.EstadoId = 8;
            var resultado = gestorSolicitud.UpdateSolicitud(solicitud);
            if (resultado == true)
            {
                gvSolicitudes.DataSource = GetMisSolicitudes(SessionUsuario.Mail);
                gvSolicitudes.DataBind();
            }
        }

        protected void btnSiConexion_Click(object sender, EventArgs e)
        {
            Conexion conexion = gestorConexion.BuscarConexion(Int32.Parse(hfConexion.Value));
            conexion.EstadoConfirmacion = true;
            var resultado = gestorConexion.UpdateConexion(conexion);
            if (resultado == true)
            {
                gvConexiones.DataSource = GetMisConexiones(SessionUsuario.Mail);
                gvConexiones.DataBind();
            }
        }

        protected void btnCrearConexion_Click(object sender, EventArgs e)
        {
            if (txtNombrePlaya.Text != "" && txtCiudad.Text != "" && txtDireccion.Text != "")
            {
                Usuario usuario = gestorUsuario.BuscarUsuarioByNombreOEmail(txtUsuario.Text);
                Conexion NuevaConexion = new Conexion();
                NuevaConexion.EstadoConfirmacion = false;
                NuevaConexion.PlayaDeEstacionamientoId = gestorPlaya.BuscarPlayaPorNombreYDireccion(txtNombrePlaya.Text, txtCiudad.Text, txtDireccion.Text, Int32.Parse(txtNumero.Text));
                NuevaConexion.UsuarioResponsable = usuario.Mail;
                NuevaConexion.Token = encriptacion.Encriptar(NuevaConexion.Id.ToString() + usuario.Id.ToString() + usuario.Nombre);
                if (usuario != null && NuevaConexion != null)
                {
                    var resultado = gestorConexion.RegistrarNuevaConexion(NuevaConexion);
                    if (resultado == true)
                    {
                        PlayaDeEstacionamiento playa = gestorPlaya.BuscarPlayaPorId(NuevaConexion.PlayaDeEstacionamientoId);
                        SolicitudConexion solicitud = gestorSolicitud.BuscarSolicitudByUsuario(usuario.Mail);
                        solicitud.EstadoId = 7;
                        gestorSolicitud.UpdateSolicitud(solicitud);
                        gvSolicitudes.DataSource = GetSolicitudes();
                        gvSolicitudes.DataBind();
                        gvConexiones.DataSource = GetConexiones();
                        gvConexiones.DataBind();
                        string url = HttpContext.Current.Request.Url.ToString();
                        Uri uri = new Uri(url);
                        gestorMandarEmail.EnviarEmail("Se ha creado la conexion con la playa " + playa.Nombre + " de Direccion: " + playa.Direcciones.FirstOrDefault().Calle + " " + playa.Direcciones.FirstOrDefault().Numero + " " + playa.Direcciones.FirstOrDefault().Ciudad + ". Verifique la información cargada y confirme la conexion con su playa. \n\nPresione el siguiente link para ingresar y ver sus conexiones " + uri.GetLeftPart(UriPartial.Authority) + "/Index.aspx .\n\nDatos de Acceso a la API GEOPARKING: \nIdentificador de Playa: " + playa.Id + " \nNumero de Acceso: " + NuevaConexion.Token + "", usuario.Mail, "Creacion de Conexion en Geoparking");
                    }
                }
            }
        }
    }
}