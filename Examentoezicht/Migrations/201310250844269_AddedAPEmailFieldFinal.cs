namespace Examentoezicht.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedAPEmailFieldFinal : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "EmailAP", c => c.String());
            DropColumn("dbo.AspNetUsers", "APEmail");
            DropColumn("dbo.AspNetUsers", "APEmailAddress");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "APEmailAddress", c => c.String());
            AddColumn("dbo.AspNetUsers", "APEmail", c => c.String());
            DropColumn("dbo.AspNetUsers", "EmailAP");
        }
    }
}
