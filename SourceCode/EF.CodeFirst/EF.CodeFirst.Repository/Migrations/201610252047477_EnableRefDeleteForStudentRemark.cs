namespace EF.CodeFirst.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EnableRefDeleteForStudentRemark : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.D_StudentRemarks", "Id", "dbo.D_Students");
            AddForeignKey("dbo.D_StudentRemarks", "Id", "dbo.D_Students", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.D_StudentRemarks", "Id", "dbo.D_Students");
            AddForeignKey("dbo.D_StudentRemarks", "Id", "dbo.D_Students", "Id");
        }
    }
}
