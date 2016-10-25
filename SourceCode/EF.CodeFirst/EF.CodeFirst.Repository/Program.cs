
namespace EF.CodeFirst.Repository
{
    using K.Common;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;

    class Program
    {
        static void Main(string[] args)
        {
            Operator.HandleProcess(() =>
            {
                #region reset database
                //Database.SetInitializer(new DropCreateDatabaseAlways<BasicContext>());
                //using (var db = new BasicContext())
                //{
                //    db.Database.Initialize(true);
                //}
                #endregion

                #region initialize database
                //using (var context = new BasicContext())
                //{
                //    #region grades
                //    context.Grades.Add(new GradeEntity { Name = "一年级" });
                //    context.Grades.Add(new GradeEntity { Name = "二年级" });
                //    context.Grades.Add(new GradeEntity { Name = "三年级" });
                //    #endregion

                //    #region roles
                //    context.Roles.Add(new RoleEntity { Name = "管理员" });
                //    context.Roles.Add(new RoleEntity { Name = "学生" });
                //    context.Roles.Add(new RoleEntity { Name = "老师" });
                //    #endregion

                //    #region sexes
                //    context.Sexes.Add(new SexEntity { Name = "男" });
                //    context.Sexes.Add(new SexEntity { Name = "女" });
                //    #endregion

                //    #region courses
                //    context.Courses.Add(new CourseEntity { Name = "语文" });
                //    context.Courses.Add(new CourseEntity { Name = "数学" });
                //    context.Courses.Add(new CourseEntity { Name = "英语" });
                //    #endregion

                //    context.SaveChanges();
                //}
                #endregion

                using (var db = new BasicContext())
                {
                    var id = "002";

                    var sex = db.Sexes.ToList().FirstOrDefault();

                    var role = db.Roles.ToList().LastOrDefault();

                    var grade = db.Grades.ToList().LastOrDefault();

                    var studentRep = new StudentRepository(db);
                    var student = new StudentEntity { Id = id, Name = $"t{id}", Sex = sex, Roles = new List<RoleEntity> { role }, Grade = grade };
                    //student.Roles.Add(role);
                    studentRep.Insert(student);

                    var studentRemarkRep = new StudentRemarkRepository(db);
                    studentRemarkRep.Insert(new StudentRemarkEntity { Remark = $"test messags of {id}", Student = student });

                    var course = db.Courses.ToList().LastOrDefault();
                    new StudentScoreRepository(db).Insert(new StudentScoreEntity { Course = course, Student = student, Score = 99 });

                    db.SaveChanges();
                }
            });

            Console.WriteLine("主函数执行完成，按任意键退出……");
            Console.ReadKey();
        }
    }
}
