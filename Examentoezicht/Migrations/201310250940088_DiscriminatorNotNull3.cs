namespace Examentoezicht.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DiscriminatorNotNull3 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.AspNetUsers", "Discriminator");
        }
        
        public override void Down()
        {
        }
    }
}
