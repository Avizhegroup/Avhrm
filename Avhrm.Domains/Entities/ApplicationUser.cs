using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Avhrm.Domains;
public class ApplicationUser : IdentityUser
{
    [Required]
    [StringLength(128)]
    public string PersianName { get; set; }

    public string? ParentId { get; set; }
    public ApplicationUser? Parent { get; set; }
	public ICollection<ApplicationUser> Children { get; set; }

    public int DepartmentId { get; set; }
    public Department Department { get; set; }

    public int Points { get; set; }

    [NotMapped]
    public string RoleName { get; set; }

    [NotMapped]
    public string RoleId { get; set; }

    public ICollection<UserPointChangeLog> PointChangeLogs { get; set; }
}

public class ApplicationUserConfig : IEntityTypeConfiguration<ApplicationUser>
{
    public void Configure(EntityTypeBuilder<ApplicationUser> builder)
    {
        builder.HasMany(p => p.PointChangeLogs)
               .WithOne(p => p.User)
               .HasForeignKey(p => p.UserId);
    }
}
