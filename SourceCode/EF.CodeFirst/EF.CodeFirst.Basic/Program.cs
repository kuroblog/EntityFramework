
namespace EF.CodeFirst.Basic
{
    using System;
    using System.Collections.Generic;
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
            try
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
            }
            catch (Exception ex)
            {
                var errors = new List<Tuple<int, string, string>>();
                var tmp = ex;
                var index = 0;
                do
                {
                    errors.Add(Tuple.Create(++index, ex.GetType().Name, ex.Message.Replace(Environment.NewLine, string.Empty)));
                    ex = tmp.InnerException == null ? null : ex.InnerException;
                } while (ex != null);

                if (errors.Count > 0)
                {
                    Console.WriteLine($"执行完成，发生以下错误：{Environment.NewLine}");
                    errors.ForEach(p => Console.WriteLine($"{p.Item1.ToString().PadLeft(2, '0')}）异常类型:{p.Item2};异常信息:{p.Item3}{Environment.NewLine}"));
                }
            }

            Console.WriteLine("主函数执行完成，按任意键退出……");
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

            [StringLength(50)]
            public string Msg { get; set; }
        }
    }
}
