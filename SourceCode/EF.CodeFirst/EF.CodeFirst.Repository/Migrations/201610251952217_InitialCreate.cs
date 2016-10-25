namespace EF.CodeFirst.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.P_Courses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 10),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.P_Grades",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 10),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.P_Roles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 10),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.D_StudentScores",
                c => new
                    {
                        RefStudentId = c.String(nullable: false, maxLength: 20),
                        RefCourseId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.RefStudentId, t.RefCourseId });
            
            CreateTable(
                "dbo.P_Sexes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 10),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.D_StudentRemarks",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 20),
                        Name = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.D_Students",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 20),
                        Name = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.D_Students");
            DropTable("dbo.D_StudentRemarks");
            DropTable("dbo.P_Sexes");
            DropTable("dbo.D_StudentScores");
            DropTable("dbo.P_Roles");
            DropTable("dbo.P_Grades");
            DropTable("dbo.P_Courses");
        }
    }
}
