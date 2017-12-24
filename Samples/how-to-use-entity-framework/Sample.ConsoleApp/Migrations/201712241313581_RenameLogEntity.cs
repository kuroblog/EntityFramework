namespace Sample.ConsoleApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RenameLogEntity : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.LogEntities", newName: "logs");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.logs", newName: "LogEntities");
        }
    }
}
