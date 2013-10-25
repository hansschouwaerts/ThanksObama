namespace Examentoezicht.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Toezichtbeurts",
                c => new
                    {
                        ToezichtbeurtId = c.Int(nullable: false, identity: true),
                        Datum = c.String(),
                        Start = c.String(),
                        Einde = c.String(),
                        Duurtijd = c.String(),
                        Capaciteit = c.Int(nullable: false),
                        Gereserveerd = c.Int(nullable: false),
                        AangemaaktOp = c.DateTime(nullable: false),
                        GewijzigdOp = c.DateTime(nullable: false),
                        Digitaal = c.Boolean(nullable: false),
                        Campus = c.String(),
                        Departement = c.String(),
                    })
                .PrimaryKey(t => t.ToezichtbeurtId);
            
            CreateTable(
                "dbo.Lectors",
                c => new
                    {
                        LectorId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Email = c.String(),
                        AangemaaktOp = c.DateTime(nullable: false),
                        AangepastOp = c.DateTime(nullable: false),
                        Wachtwoord = c.String(),
                        Departement = c.String(),
                    })
                .PrimaryKey(t => t.LectorId);
            
            CreateTable(
                "dbo.Reservaties",
                c => new
                    {
                        ReservatieId = c.Int(nullable: false, identity: true),
                        ToezichtbeurtId = c.Int(nullable: false),
                        LectorId = c.Int(nullable: false),
                        AangemaaktOp = c.DateTime(nullable: false),
                        AangepastOp = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ReservatieId)
                .ForeignKey("dbo.Lectors", t => t.LectorId, cascadeDelete: true)
                .ForeignKey("dbo.Toezichtbeurts", t => t.ToezichtbeurtId, cascadeDelete: true)
                .Index(t => t.LectorId)
                .Index(t => t.ToezichtbeurtId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Reservaties", "ToezichtbeurtId", "dbo.Toezichtbeurts");
            DropForeignKey("dbo.Reservaties", "LectorId", "dbo.Lectors");
            DropIndex("dbo.Reservaties", new[] { "ToezichtbeurtId" });
            DropIndex("dbo.Reservaties", new[] { "LectorId" });
            DropTable("dbo.Reservaties");
            DropTable("dbo.Lectors");
            DropTable("dbo.Toezichtbeurts");
        }
    }
}
