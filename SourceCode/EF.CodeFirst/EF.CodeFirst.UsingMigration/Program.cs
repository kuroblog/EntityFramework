
namespace EF.CodeFirst.UsingMigration
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    public class Basic
    {
        [Key]
        public int Id { get; set; }

        public string Msg { get; set; }
    }

    public class A : Basic { }

    public class B : Basic { }
}
