
namespace EF.CodeFirst.Basic
{
    using K.Common;
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
            Operator.HandleProcess(() =>
            {
                using (var db = new DataContext())
                {
                    var tmp = Guid.NewGuid().ToString("N");
                    Debug.WriteLine($"tmp={tmp}");
                    db.Array.Add(new A { Msg = tmp });
                    var commit = db.SaveChanges();

                    Console.WriteLine($"提交数据({tmp})，返回({commit}){Environment.NewLine}遍历当前数据集：");

                    db.Array.ToList().ForEach(p => Console.WriteLine($"id:{p.Id}; msg:{p.Msg}"));
                }
            });

            Console.WriteLine("主函数执行完成，按任意键退出……");
            Console.ReadKey();
        }

        /// <summary>
        /// 继承DbContext，实现自定义处理
        /// </summary>
        public class DataContext : DbContext
        {
            /// <summary>
            /// 本地localdb连接字符串，与配置文件一致
            /// </summary>
            private const string LocalDbConnString = nameof(LocalDbConnString);

            /// <summary>
            /// 远程标准数据库连接字符串，与配置文件一致
            /// </summary>
            private const string MssqlDbConnString = nameof(MssqlDbConnString);

            /// <summary>
            /// 默认构造函数，使用哪个数据取决于传入基类构造函数的连接字符串
            /// </summary>
            public DataContext() : base(LocalDbConnString) { }

            /// <summary>
            /// 设置数据库对象
            /// </summary>
            public DbSet<A> Array { get; set; }
        }

        /// <summary>
        /// 数据库对应的实体
        /// </summary>
        public class A
        {
            /// <summary>
            /// 主键列
            /// </summary>
            [Key]
            public int Id { get; set; }

            /// <summary>
            /// 属性列
            /// </summary>
            public string Msg { get; set; }
        }
    }
}
