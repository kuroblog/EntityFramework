
namespace EF.CodeFirst.Relationship
{
    using K.Common;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;

    class Program
    {
        static void Main(string[] args)
        {
            Operator.HandleProcess(() =>
            {
                Database.SetInitializer(new DropCreateDatabaseAlways<DataContext>());

                using (var db = new DataContext())
                {
                    db.Database.Initialize(true);
                }
            });

            Console.WriteLine("主函数执行完成，按任意键退出……");
            Console.ReadKey();
        }

        public abstract class Basic
        {
            public int Id { get; set; }
        }

        public partial class DataContext : DbContext
        {
            public DataContext() : base("LocalDbConnString") { }

            #region 测试用
            //public DbSet<AMain> AMain { get; set; }

            //public DbSet<ARef> ARef { get; set; }

            //public DbSet<BMain> BMain { get; set; }

            //public DbSet<BRef> BRef { get; set; }
            #endregion

            public DbSet<Student> Students { get; set; }

            public DbSet<StudentRemark> StudentRemarks { get; set; }

            public DbSet<Sex> Sexes { get; set; }

            public DbSet<Role> Roles { get; set; }

            public DbSet<Course> Courses { get; set; }

            public DbSet<StudentScore> StudentScores { get; set; }

            public DbSet<Grade> Grades { get; set; }

            protected override void OnModelCreating(DbModelBuilder modelBuilder)
            {
                //一对一
                modelBuilder.Entity<StudentRemark>().HasRequired(p => p.Student).WithOptional(p => p.Remark);
                //一对多，使用MapKey来设置数据库的外键名称，使用WillCascadeOnDelete来设置级联（默认为启用）
                //modelBuilder.Entity<User>().HasRequired(p => p.Sex).WithMany(p => p.Users).Map(p => p.MapKey("SexId"));
                //外键表显式定义了外键属性的话，可以使用HasForeignKey来限定
                //modelBuilder.Entity<User>().HasRequired(p => p.Sex).WithMany(p => p.Users).HasForeignKey(p=>p.SexId);
                //一对多，可以为空
                modelBuilder.Entity<Student>().HasOptional(p => p.Sex).WithMany(p => p.Studenns).Map(p => p.MapKey("SexId"));

                modelBuilder.Entity<Student>().HasRequired(p => p.Grade).WithMany(p => p.Students).Map(p => p.MapKey("GradeId"));

                //多对多，使用Map来设置数据库的关联表名称，和外键名称
                modelBuilder.Entity<Student>().HasMany(p => p.Roles).WithMany(p => p.Students).Map(p =>
                {
                    p.ToTable("StudentRoles");
                    p.MapLeftKey("StudentId");
                    p.MapRightKey("RoleId");
                });

                //多对多，关联表设置
                modelBuilder.Entity<StudentScore>().HasKey(p => new { p.StudentId, p.CourseId });
                modelBuilder.Entity<StudentScore>().HasRequired(p => p.Student).WithMany(p => p.Scores).HasForeignKey(p => p.StudentId);
                modelBuilder.Entity<StudentScore>().HasRequired(p => p.Course).WithMany(p => p.Scores).HasForeignKey(p => p.CourseId);


                base.OnModelCreating(modelBuilder);
            }
        }

        public partial class Grade : Basic
        {
            public string Name { get; set; }

            public virtual ICollection<Student> Students { get; set; }
        }

        public partial class Course : Basic
        {
            public string Name { get; set; }

            public virtual ICollection<StudentScore> Scores { get; set; }
        }

        public partial class StudentScore
        {
            public double Score { get; set; }

            public int StudentId { get; set; }

            public virtual Student Student { get; set; }

            public int CourseId { get; set; }

            public virtual Course Course { get; set; }
        }

        public partial class Role : Basic
        {
            public string Name { get; set; }

            public virtual ICollection<Student> Students { get; set; }
        }

        public partial class Sex : Basic
        {
            public string Name { get; set; }

            public virtual ICollection<Student> Studenns { get; set; }
        }

        public partial class Student : Basic
        {
            public string Name { get; set; }

            public virtual Grade Grade { get; set; }

            //public int SexId { get; set; }

            public virtual Sex Sex { get; set; }

            public virtual StudentRemark Remark { get; set; }

            public virtual ICollection<Role> Roles { get; set; }

            public virtual ICollection<StudentScore> Scores { get; set; }
        }

        public partial class StudentRemark : Basic
        {
            public string Remark { get; set; }

            public string Remark1 { get; set; }

            public string Remark2 { get; set; }

            public string Remark3 { get; set; }

            public virtual Student Student { get; set; }
        }

        #region 一对多
        public partial class AMain : Basic
        {
            public virtual ICollection<ARef> Ref { get; set; }
        }

        public partial class ARef : Basic
        {
            public virtual AMain Main { get; set; }

            /// <summary>
            /// 此处可以不用定义，区别在于定义了，约束为非空，不定义则可以为空
            /// </summary>
            public int AMainId { get; set; }
        }
        #endregion

        #region 一对多
        public partial class BMain : Basic
        {
            public virtual ICollection<BRef> Ref { get; set; }
        }

        public partial class BRef : Basic
        {
            public virtual BMain Main { get; set; }
        }
        #endregion
    }
}
