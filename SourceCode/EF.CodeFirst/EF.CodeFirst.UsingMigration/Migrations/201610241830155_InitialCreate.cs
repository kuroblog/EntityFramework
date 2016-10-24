namespace EF.CodeFirst.UsingMigration.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.A",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Msg = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.B",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Msg = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.B");
            DropTable("dbo.A");
        }
    }
}
