namespace EF.CodeFirst.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddGradeToStudent : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.D_Students", "RefGradeId", c => c.Int(nullable: false));
            CreateIndex("dbo.D_Students", "RefGradeId");
            AddForeignKey("dbo.D_Students", "RefGradeId", "dbo.P_Grades", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.D_Students", "RefGradeId", "dbo.P_Grades");
            DropIndex("dbo.D_Students", new[] { "RefGradeId" });
            DropColumn("dbo.D_Students", "RefGradeId");
        }
    }
}
