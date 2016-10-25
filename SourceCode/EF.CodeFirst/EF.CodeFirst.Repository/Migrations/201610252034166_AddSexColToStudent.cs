namespace EF.CodeFirst.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSexColToStudent : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.D_Students", "RefSexId", c => c.Int());
            CreateIndex("dbo.D_Students", "RefSexId");
            AddForeignKey("dbo.D_Students", "RefSexId", "dbo.P_Sexes", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.D_Students", "RefSexId", "dbo.P_Sexes");
            DropIndex("dbo.D_Students", new[] { "RefSexId" });
            DropColumn("dbo.D_Students", "RefSexId");
        }
    }
}
