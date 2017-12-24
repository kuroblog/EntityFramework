namespace Sample.ConsoleApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddLog : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.LogEntities",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        CreatedOn = c.DateTime(nullable: false),
                        Message = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.LogEntities");
        }
    }
}
