
namespace EF.CodeFirst.Repository
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    #region basic entity
    public abstract class Basic
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 1)]
        public string Name { get; set; }
    }
    #endregion

    public partial class GradeEntity : Basic
    {
        public virtual ICollection<StudentEntity> Students { get; set; }
    }

    public partial class RoleEntity : Basic
    {
        public virtual ICollection<StudentEntity> Students { get; set; }
    }

    public partial class SexEntity : Basic
    {
        public virtual ICollection<StudentEntity> Students { get; set; }
    }

    public partial class StudentEntity// : Basic
    {
        [Key]
        [StringLength(20, MinimumLength = 3)]
        public string Id { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 3)]
        public string Name { get; set; }

        public virtual GradeEntity Grade { get; set; }

        public virtual SexEntity Sex { get; set; }

        public virtual StudentRemarkEntity Remark { get; set; }

        public virtual ICollection<RoleEntity> Roles { get; set; }

        public virtual ICollection<StudentScoreEntity> Scores { get; set; }
    }

    public partial class StudentRemarkEntity// : Basic
    {
        [Key]
        [StringLength(20, MinimumLength = 3)]
        public string Id { get; set; }

        //[NotMapped]
        //private new string Name { get; set; }

        [StringLength(255, MinimumLength = 3)]
        public string Remark { get; set; }

        [StringLength(255, MinimumLength = 3)]
        public string Remark1 { get; set; }

        [StringLength(255, MinimumLength = 3)]
        public string Remark2 { get; set; }

        [StringLength(255, MinimumLength = 3)]
        public string Remark3 { get; set; }

        public virtual StudentEntity Student { get; set; }
    }

    public partial class CourseEntity : Basic
    {
        public virtual ICollection<StudentScoreEntity> Scores { get; set; }
    }

    public partial class StudentScoreEntity
    {
        [StringLength(20, MinimumLength = 3)]
        public string RefStudentId { get; set; }

        public virtual StudentEntity Student { get; set; }

        public int RefCourseId { get; set; }

        public virtual CourseEntity Course { get; set; }

        [Required]
        public double Score { get; set; }
    }
}
