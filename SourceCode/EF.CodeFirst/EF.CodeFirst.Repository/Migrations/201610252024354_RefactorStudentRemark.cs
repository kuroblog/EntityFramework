namespace EF.CodeFirst.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RefactorStudentRemark : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.D_StudentRemarks", "Remark", c => c.String(maxLength: 255));
            AddColumn("dbo.D_StudentRemarks", "Remark1", c => c.String(maxLength: 255));
            AddColumn("dbo.D_StudentRemarks", "Remark2", c => c.String(maxLength: 255));
            AddColumn("dbo.D_StudentRemarks", "Remark3", c => c.String(maxLength: 255));
            CreateIndex("dbo.D_StudentRemarks", "Id");
            AddForeignKey("dbo.D_StudentRemarks", "Id", "dbo.D_Students", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.D_StudentRemarks", "Id", "dbo.D_Students");
            DropIndex("dbo.D_StudentRemarks", new[] { "Id" });
            DropColumn("dbo.D_StudentRemarks", "Remark3");
            DropColumn("dbo.D_StudentRemarks", "Remark2");
            DropColumn("dbo.D_StudentRemarks", "Remark1");
            DropColumn("dbo.D_StudentRemarks", "Remark");
        }
    }
}
