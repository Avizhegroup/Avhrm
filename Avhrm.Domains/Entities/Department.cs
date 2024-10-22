using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Avhrm.Domains;
public class Department : IBaseEntity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required]
    [StringLength(128)]
    public string Name { get; set; }

    public int? ParentDepartmentId { get; set; }
    public Department? ParentDepartment { get; set; }

    public ICollection<ApplicationUser> Users { get; set; }
    public ICollection<WorkType> WorkTypes { get; set; }
    public ICollection<WorkChallenge> WorkingChallenges { get; set; }
    public ICollection<Department> ChildDepartments { get; set; }

    public DateTime CreateDateTime { get; set; }
    public string CreatorUserId { get; set; }
    public DateTime? LastUpdateDateTime { get; set; }
    public string? LastUpdateUserId { get; set; }
}

public class DepartmentConfig : IEntityTypeConfiguration<Department>
{
    public void Configure(EntityTypeBuilder<Department> builder)
    {
        builder.HasMany(p => p.Users)
               .WithOne(p => p.Department)
               .HasForeignKey(p => p.DepartmentId);

        builder.HasMany(p => p.WorkTypes)
               .WithOne(p => p.Department)
               .HasForeignKey(p => p.DepartmentId);

        builder.HasMany(p => p.WorkingChallenges)
               .WithOne(p => p.Department)
               .HasForeignKey(p => p.DepartmentId);

        builder.HasOne(c => c.ParentDepartment)              
               .WithMany(c => c.ChildDepartments)            
               .HasForeignKey(c => c.ParentDepartmentId)     
               .OnDelete(DeleteBehavior.Restrict);
    }
}
