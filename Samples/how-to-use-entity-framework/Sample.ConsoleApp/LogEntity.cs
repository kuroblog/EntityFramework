
namespace Sample.ConsoleApp
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.ModelConfiguration;

    public class LogEntity : IEntity
    {
        public Guid Id { get; set; } = Guid.Empty;

        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;

        [Required]
        public string Message { get; set; }
    }

    public class LogConfiguration : EntityTypeConfiguration<LogEntity>
    {
        public LogConfiguration()
        {
            HasKey(p => p.Id);
            Property(p => p.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
        }
    }
}
