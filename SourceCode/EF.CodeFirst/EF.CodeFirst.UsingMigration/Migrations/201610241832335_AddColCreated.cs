namespace EF.CodeFirst.UsingMigration.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddColCreated : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.A", "Created", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.A", "Created");
        }
    }
}
