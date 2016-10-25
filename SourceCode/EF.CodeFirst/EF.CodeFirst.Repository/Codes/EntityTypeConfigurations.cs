
namespace EF.CodeFirst.Repository
{
    using System.Data.Entity.ModelConfiguration;

    public partial class GradeConfiguration : EntityTypeConfiguration<GradeEntity>
    {
        public GradeConfiguration()
        {
            ToTable("P_Grades");
            Property(p => p.Name).HasMaxLength(10);
        }
    }

    public partial class RoleConfiguration : EntityTypeConfiguration<RoleEntity>
    {
        public RoleConfiguration()
        {
            ToTable("P_Roles");
            Property(p => p.Name).HasMaxLength(10);
        }
    }

    public partial class SexConfiguration : EntityTypeConfiguration<SexEntity>
    {
        public SexConfiguration()
        {
            ToTable("P_Sexes");
            Property(p => p.Name).HasMaxLength(10);
        }
    }

    public partial class StudentConfiguration : EntityTypeConfiguration<StudentEntity>
    {
        public StudentConfiguration()
        {
            ToTable("D_Students");
            HasRequired(p => p.Grade).WithMany(p => p.Students).Map(p => p.MapKey("RefGradeId"));
            HasOptional(p => p.Sex).WithMany(p => p.Students).Map(p => p.MapKey("RefSexId"));
            HasMany(p => p.Roles).WithMany(p => p.Students).Map(p =>
            {
                p.ToTable("R_StudentRoles");
                p.MapLeftKey("RefStudentId");
                p.MapRightKey("RefRoleId");
            });
        }
    }

    public partial class StudentRemarkConfiguration : EntityTypeConfiguration<StudentRemarkEntity>
    {
        public StudentRemarkConfiguration()
        {
            ToTable("D_StudentRemarks");
            HasRequired(p => p.Student).WithOptional(p => p.Remark).WillCascadeOnDelete(true);
        }
    }

    public partial class CourseConfiguration : EntityTypeConfiguration<CourseEntity>
    {
        public CourseConfiguration()
        {
            ToTable("P_Courses");
            Property(p => p.Name).HasMaxLength(10);
        }
    }

    public partial class StudentScoreConfiguration : EntityTypeConfiguration<StudentScoreEntity>
    {
        public StudentScoreConfiguration()
        {
            ToTable("D_StudentScores");
            HasKey(p => new { p.RefStudentId, p.RefCourseId });
            HasRequired(p => p.Student).WithMany(p => p.Scores).HasForeignKey(p => p.RefStudentId);
            HasRequired(p => p.Course).WithMany(p => p.Scores).HasForeignKey(p => p.RefCourseId);
        }
    }
}
