namespace Datos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PlayaDeEstacionamientoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        TipoPlayaId = c.Int(nullable: false),
                        TipoPlaya = c.String(),
                        Direccion = c.String(),
                        Latitud = c.Double(nullable: false),
                        Longitud = c.Double(nullable: false),
                        Capacidad = c.Int(nullable: false),
                        HoraDesde = c.String(),
                        HoraHasta = c.String(),
                        Motos = c.Boolean(nullable: false),
                        PrecioMotos = c.Double(nullable: false),
                        Bicicletas = c.Boolean(nullable: false),
                        PrecioBicicletas = c.Double(nullable: false),
                        Utilitarios = c.Boolean(nullable: false),
                        PrecioUtilitarios = c.Double(nullable: false),
                        FechaAlta = c.DateTime(nullable: false),
                        FechaBaja = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TipoPlayas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Descripcion = c.String(),
                        FechaAlta = c.DateTime(nullable: false),
                        FechaBaja = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.TipoPlayas");
            DropTable("dbo.PlayaDeEstacionamientoes");
        }
    }
}
