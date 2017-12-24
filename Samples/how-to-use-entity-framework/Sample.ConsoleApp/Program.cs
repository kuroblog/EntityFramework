
namespace Sample.ConsoleApp
{
    using Sample.ConsoleApp.Migrations;
    using System.Data.Entity;

    class Program
    {
        static void Main(string[] args)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<SampleContext, Configuration>());
        }
    }
}
