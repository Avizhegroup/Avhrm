using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Avhrm.Domains;
public class Customer : IBaseEntity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required]
    [StringLength(128)]
    public string Name { get; set; }

    public DateTime CreateDateTime { get; set; }
    public string CreatorUserId { get; set; }
    public ApplicationUser CreatorUser { get; set; }

    public DateTime? LastUpdateDateTime { get; set; }
    public string? LastUpdateUserId { get; set; }
    public ApplicationUser LastUpdateUser { get; set; }

    public Project Project { get; set; }
    public int ProjectId { get; set; }

    public ICollection<WorkReport> WorkReports { get; set; }
}

public class CustomerConfig : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.HasMany(p => p.WorkReports)
               .WithOne(p => p.Customer)
               .HasForeignKey(p => p.CustomerId);
    }
}