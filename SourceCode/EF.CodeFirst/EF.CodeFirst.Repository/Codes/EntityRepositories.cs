
namespace EF.CodeFirst.Repository
{
    public partial class GradeRepository : BasicRepository<GradeEntity>
    {
        public GradeRepository(BasicContext context) : base(context) { }

        public GradeRepository() { }
    }

    public partial class RoleRepository : BasicRepository<RoleEntity>
    {
        public RoleRepository(BasicContext context) : base(context) { }

        public RoleRepository() { }
    }

    public partial class SexRepository : BasicRepository<SexEntity>
    {
        public SexRepository(BasicContext context) : base(context) { }

        public SexRepository() { }
    }

    public partial class StudentRepository : BasicRepository<StudentEntity>
    {
        public StudentRepository(BasicContext context) : base(context) { }

        public StudentRepository() { }
    }

    public partial class StudentRemarkRepository : BasicRepository<StudentRemarkEntity>
    {
        public StudentRemarkRepository(BasicContext context) : base(context) { }

        public StudentRemarkRepository() { }
    }

    public partial class CourseRepository : BasicRepository<CourseEntity>
    {
        public CourseRepository(BasicContext context) : base(context) { }

        public CourseRepository() { }
    }

    public partial class StudentScoreRepository : BasicRepository<StudentScoreEntity>
    {
        public StudentScoreRepository(BasicContext context) : base(context) { }

        public StudentScoreRepository() { }
    }
}
