namespace EF.CodeFirst.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RefactorTables : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.D_StudentScores", "Score", c => c.Double(nullable: false));
            CreateIndex("dbo.D_StudentScores", "RefStudentId");
            CreateIndex("dbo.D_StudentScores", "RefCourseId");
            AddForeignKey("dbo.D_StudentScores", "RefCourseId", "dbo.P_Courses", "Id", cascadeDelete: true);
            AddForeignKey("dbo.D_StudentScores", "RefStudentId", "dbo.D_Students", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.D_StudentScores", "RefStudentId", "dbo.D_Students");
            DropForeignKey("dbo.D_StudentScores", "RefCourseId", "dbo.P_Courses");
            DropIndex("dbo.D_StudentScores", new[] { "RefCourseId" });
            DropIndex("dbo.D_StudentScores", new[] { "RefStudentId" });
            DropColumn("dbo.D_StudentScores", "Score");
        }
    }
}
