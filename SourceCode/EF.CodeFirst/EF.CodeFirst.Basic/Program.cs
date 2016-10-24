
namespace EF.CodeFirst.Basic
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Data.Entity;
    using System.Diagnostics;
    using System.Linq;

    class Program
    {
        /// <summary>
        /// 演示最基础的CodeFirst的使用方法
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            using (var db = new DataContext())
            {
                var tmp = Guid.NewGuid().ToString("N");
                Debug.WriteLine($"tmp={tmp}");
                db.Array.Add(new A { Msg = tmp });
                var commit = db.SaveChanges();

                Console.WriteLine($"commit value is {tmp}, result is {commit}{Environment.NewLine}results:");

                db.Array.ToList().ForEach(p => Console.WriteLine($"id:{p.Id}; msg:{p.Msg}"));
            }

            Console.WriteLine("enter any key to exit...");
            Console.ReadKey();
        }

        public class DataContext : DbContext
        {
            private const string LocalDbConnString = nameof(LocalDbConnString);

            private const string MssqlDbConnString = nameof(MssqlDbConnString);

            public DataContext() : base(LocalDbConnString) { }


            public DbSet<A> Array { get; set; }
        }

        public class A
        {
            [Key]
            public int Id { get; set; }

            public string Msg { get; set; }
        }
    }
}
