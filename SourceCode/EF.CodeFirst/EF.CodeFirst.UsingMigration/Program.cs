
namespace EF.CodeFirst.UsingMigration
{
    using K.Common;
    using Migrations;
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Data.Entity;
    using System.Linq;

    class Program
    {
        /// <summary>
        /// 使用Migration命令来操作数据库
        /// </summary>
        /// <remarks>
        /// 在生产环境下，为防止数据丢失应按照以下步骤来操作
        /// 在本地开发环境运行以下命令生成脚本
        /// Update-Database -Script -SourceMigration $initialdatabase -TargetMigration MigrationFileName
        /// 省略-TargetMigration MigrationFileName参数，会默认以最近的一个MigrationFileName来生成脚本
        /// 具体参见命令 get-help Update-Database -detailed
        /// 在生产环境运行以上命令生成的脚本
        /// </remarks>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Operator.HandleProcess(() =>
            {
                #region 此处用于配置数据库的初始化行为，此处的三个泛型类可以继承后扩展自定义操作
                //Database.SetInitializer(new DropCreateDatabaseAlways<DataContext>());
                //Database.SetInitializer(new CreateDatabaseIfNotExists<DataContext>());
                //Database.SetInitializer(new DropCreateDatabaseIfModelChanges<DataContext>());
                //扩展MigrateDatabaseToLatestVersion类，需要修改对应Configuration的访问级别
                //Database.SetInitializer(new MigrateDatabaseToLatestVersion<DataContext, Configuration>());
                #endregion

                using (var db = new DataContext())
                {
                    db.AA.Add(new A
                    {
                        Msg = Guid.NewGuid().ToString("N"),
                        Created = DateTime.Now
                    });
                    db.BB.Add(new B { Msg = Guid.NewGuid().ToString("N") });

                    var commit = db.SaveChanges();

                    Console.WriteLine($"提交结果({commit}){Environment.NewLine}遍历当前数据集：");

                    db.AA.ToList().ForEach(p => Console.WriteLine($"id:{p.Id}; msg:{p.Msg}"));

                    Console.WriteLine();

                    db.BB.ToList().ForEach(p => Console.WriteLine($"id:{p.Id}; msg:{p.Msg}"));
                }
            });

            Console.WriteLine("主函数执行完成，按任意键退出……");
            Console.ReadKey();
        }
    }

    public class DataContext : DbContext
    {
        public DataContext() : base(Parameters.LocalDbConnString) { }

        //public DataContext() : base(Parameters.LocalDbOemConnString) { }

        public DbSet<A> AA { get; set; }

        public DbSet<B> BB { get; set; }
    }

    public class Basic
    {
        [Key]
        public int Id { get; set; }

        [StringLength(50, MinimumLength = 10)]
        public string Msg { get; set; }
    }

    public class A : Basic
    {
        public DateTime Created { get; set; }
    }

    public class B : Basic { }
}
