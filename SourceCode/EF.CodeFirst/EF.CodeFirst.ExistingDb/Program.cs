
namespace EF.CodeFirst.ExistingDb
{
    using K.Common;
    using System;
    using System.Linq;

    class Program
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        /// <remarks>
        /// https://msdn.microsoft.com/en-us/data/dn579398.aspx
        /// 数据库已经存在
        /// 首先运行以下命令
        /// 运行Enable-Migrations -ContextTypeName MyDbContext
        /// 
        /// 1）非空库
        /// 运行Add-Migration Initial -IgnoreChanges
        /// 
        /// 2）是空库
        /// 运行Add-Migration Initial
        /// 
        /// 运行Update-Database
        /// 
        /// 具体参见get-help Add-Migration -detailed
        /// </remarks>
        static void Main(string[] args)
        {
            //Operator.HandleProcess(() =>
            //{
            //    using (var db = new DataContext())
            //    {
            //        //db.AA.Add(new A
            //        //{
            //        //    Msg = Guid.NewGuid().ToString("N"),
            //        //    Created = DateTime.Now
            //        //});
            //        //db.BB.Add(new B { Msg = Guid.NewGuid().ToString("N") });

            //        //var commit = db.SaveChanges();

            //        //Console.WriteLine($"提交结果({commit}){Environment.NewLine}遍历当前数据集：");

            //        db.A.ToList().ForEach(p => Console.WriteLine($"id:{p.Id};"));
            //        //db.A.ToList().ForEach(p => Console.WriteLine($"id:{p.Id}; msg:{p.Msg}"));

            //        Console.WriteLine();
                    
            //        db.B.ToList().ForEach(p => Console.WriteLine($"id:{p.Id}; msg:{p.Msg}"));
            //    }
            //});

            Console.WriteLine("主函数执行完成，按任意键退出……");
            Console.ReadKey();
        }
    }
}
