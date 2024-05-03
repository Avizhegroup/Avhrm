using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Avhrm.Domains;
public class Project : IBaseEntity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required]
    [StringLength(512)]
    public string Name { get; set; }

    public ICollection<WorkReport> WorkingReports { get; set; }
    public ICollection<Customer> Customers { get; set; }

    public DateTime? VerifyDateTime { get; set; }
    public DateTime CreateDateTime { get; set; }
    public string CreatorUserId { get; set; }
    public DateTime? LastUpdateDateTime { get; set; }
    public string? LastUpdateUserId { get; set; }
}

public class ProjectConfig : IEntityTypeConfiguration<Project>
{
    public void Configure(EntityTypeBuilder<Project> builder)
    {
        builder.HasMany(p => p.WorkingReports)
               .WithOne(p => p.Project)
               .HasForeignKey(p => p.ProjectId);

        builder.HasMany(p => p.Customers)
               .WithOne(p => p.Project)
               .HasForeignKey(p => p.ProjectId);
    }
}

