namespace EF.CodeFirst.Repository.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<EF.CodeFirst.Repository.BasicContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "EF.CodeFirst.Repository.BasicContext";
        }

        protected override void Seed(EF.CodeFirst.Repository.BasicContext context) { }
    }
}
