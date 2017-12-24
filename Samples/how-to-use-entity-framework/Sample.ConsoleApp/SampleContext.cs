
namespace Sample.ConsoleApp
{
    using System.Data.Entity;

    public class SampleContext : DbContext
    {
        public const string nameOrConnectionString = "SampleContext";

        public SampleContext() : base(nameOrConnectionString: nameOrConnectionString) { }

        public SampleContext(string nameOrConnectionString = nameOrConnectionString) : base(nameOrConnectionString: nameOrConnectionString) { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);

            modelBuilder.Configurations.AddFromAssembly(typeof(SampleContext).Assembly);
        }

        public DbSet<LogEntity> Logs { get; set; }
    }
}
