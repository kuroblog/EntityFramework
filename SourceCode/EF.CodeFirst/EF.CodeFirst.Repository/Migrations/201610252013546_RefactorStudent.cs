namespace EF.CodeFirst.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RefactorStudent : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.D_Students", "Name", c => c.String(nullable: false, maxLength: 20));
            DropColumn("dbo.D_StudentRemarks", "Name");
        }
        
        public override void Down()
        {
            AddColumn("dbo.D_StudentRemarks", "Name", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.D_Students", "Name", c => c.String(nullable: false, maxLength: 50));
        }
    }
}
