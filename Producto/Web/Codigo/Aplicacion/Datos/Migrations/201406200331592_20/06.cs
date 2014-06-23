namespace Datos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _2006 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.PlayaDeEstacionamientoes", "FechaBaja", c => c.DateTime());
            AlterColumn("dbo.TipoPlayas", "FechaBaja", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.TipoPlayas", "FechaBaja", c => c.DateTime(nullable: false));
            AlterColumn("dbo.PlayaDeEstacionamientoes", "FechaBaja", c => c.DateTime(nullable: false));
        }
    }
}
