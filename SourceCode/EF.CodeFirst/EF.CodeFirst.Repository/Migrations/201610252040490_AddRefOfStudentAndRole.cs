namespace EF.CodeFirst.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRefOfStudentAndRole : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.R_StudentRoles",
                c => new
                    {
                        RefStudentId = c.String(nullable: false, maxLength: 20),
                        RefRoleId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.RefStudentId, t.RefRoleId })
                .ForeignKey("dbo.D_Students", t => t.RefStudentId, cascadeDelete: true)
                .ForeignKey("dbo.P_Roles", t => t.RefRoleId, cascadeDelete: true)
                .Index(t => t.RefStudentId)
                .Index(t => t.RefRoleId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.R_StudentRoles", "RefRoleId", "dbo.P_Roles");
            DropForeignKey("dbo.R_StudentRoles", "RefStudentId", "dbo.D_Students");
            DropIndex("dbo.R_StudentRoles", new[] { "RefRoleId" });
            DropIndex("dbo.R_StudentRoles", new[] { "RefStudentId" });
            DropTable("dbo.R_StudentRoles");
        }
    }
}
