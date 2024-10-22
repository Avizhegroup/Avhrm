using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Avhrm.Domains;
public class WorkType : IBaseEntity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required]
    [StringLength(256)]
    public string Description { get; set; }

    [Required]
    public int DepartmentId { get; set; }
    public Department Department { get; set; }

    public DateTime CreateDateTime { get; set; }
    public string CreatorUserId { get; set; }
    public DateTime? LastUpdateDateTime { get; set; }
    public string? LastUpdateUserId { get; set; }
    public ICollection<WorkReport> WorkingReports { get; set; }
}

public class WorkTypeConfig : IEntityTypeConfiguration<WorkType>
{
    public void Configure(EntityTypeBuilder<WorkType> builder)
    {
        builder.HasMany(p => p.WorkingReports)
               .WithOne(p => p.WorkType)
               .HasForeignKey(p => p.WorkTypeId);
    }
}
