using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Entidades;
using RefactorThis.GraphDiff;

namespace Datos
{
    public class ContextoBD : DbContext
    {
        //instancia del singleton        
        private ContextoBD instancia = null;        

        /// <summary>
        /// Crea el contexto con la BD, con el name "BD_Geoparking" en el webConfig 
        /// </summary>
        public ContextoBD()  : base("BD_Geoparking")
        {
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;

        }

        /// <summary>
        /// Utilizacion de fluent api para configuracines del contexto
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PlayaDeEstacionamiento>()
            .HasOptional(p => p.Horario)
            .WithRequired(h => h.PlayaDeEstacionamiento);

            modelBuilder.Entity<Horario>()
                .HasKey(h => h.PlayaDeEstacionamientoId)
                .Ignore(h => h.Id);

            modelBuilder.Entity<Servicio>()
                .HasOptional(s => s.Capacidad)
                .WithRequired(p => p.Servicio);

            modelBuilder.Entity<Capacidad>()
                .HasKey(c => c.ServicioId)
                .Ignore(c => c.Id);

            modelBuilder.Entity<Servicio>()
            .HasOptional(s => s.DisponibilidadPlayas)
            .WithRequired(p => p.Servicio);

            modelBuilder.Entity<DisponibilidadPlayas>()
                .HasKey(c => c.ServicioId)
                .Ignore(c => c.Id);

            base.OnModelCreating(modelBuilder);

        }

        /// <summary>
        /// 
        /// </summary>
        public DbSet<PlayaDeEstacionamiento> playas { get; set; }
        public DbSet<TipoPlaya> tiposPlayas { get; set; }
        public DbSet<Servicio> servicios { get; set; }
        public DbSet<TipoVehiculo> tiposVehiculos { get; set; }
        public DbSet<Usuario> usuarios { get; set; }
        public DbSet<Rol> roles { get; set; }
        public DbSet<Permiso> permisos { get; set; }
        public DbSet<Direccion> direcciones { get; set; }
        public DbSet<EstadisticaConsultas> estadisticasConsultas { get; set; }
        public DbSet<Evento> eventos { get; set; }
        public DbSet<DisponibilidadPlayas> disponibilidadPlayas { get; set; }
        public DbSet<HistorialDisponibilidadPlayas> historialDisponibilidadPlayas { get; set; }
        public DbSet<Zona> zonas { get; set; }
    }
}
