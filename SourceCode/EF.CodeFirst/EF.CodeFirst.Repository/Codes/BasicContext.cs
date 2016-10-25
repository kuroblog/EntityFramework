
namespace EF.CodeFirst.Repository
{
    using K.Common;
    using System.Data.Entity;

    public partial class BasicContext : DbContext
    {
        public BasicContext() : base(Parameters.LocalDbConnString) { }

        public BasicContext(string nameOrConnectionName) : base(nameOrConnectionName) { }

        public DbSet<GradeEntity> Grades { get; set; }

        public DbSet<RoleEntity> Roles { get; set; }

        public DbSet<SexEntity> Sexes { get; set; }

        public DbSet<StudentEntity> Students { get; set; }

        public DbSet<StudentRemarkEntity> StudentRemarks { get; set; }

        public DbSet<CourseEntity> Courses { get; set; }

        public DbSet<StudentScoreEntity> Scores { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new GradeConfiguration());
            modelBuilder.Configurations.Add(new RoleConfiguration());
            modelBuilder.Configurations.Add(new SexConfiguration());
            modelBuilder.Configurations.Add(new StudentConfiguration());
            modelBuilder.Configurations.Add(new StudentRemarkConfiguration());
            modelBuilder.Configurations.Add(new CourseConfiguration());
            modelBuilder.Configurations.Add(new StudentScoreConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
