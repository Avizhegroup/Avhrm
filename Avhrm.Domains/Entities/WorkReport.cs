using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Avhrm.Domains;
public class WorkReport : IBaseEntity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required]
    [StringLength(10)]
    public string PersianDate { get; set; }

    [StringLength(512)]
    public string? Desc { get; set; }

    [Required]
    public decimal SpentHours { get; set; }

    public decimal? EstimateHours { get; set; }

    public int? ProjectId { get; set; }
    public Project? Project { get; set; }

    public int? CustomerId { get; set; }
    public Customer? Customer { get; set; }

    [Required]
    public int WorkTypeId { get; set; }
    public WorkType WorkType { get; set; }

    [Required]
    public int WorkDayType { get; set; }

    [Required]
    public int WorkReportTimeOfDay { get; set; }

    public ICollection<WorkChallenge> WorkChallenges { get; set; }

    public DateTime CreateDateTime { get; set; }
    public string CreatorUserId { get; set; }
    public DateTime? LastUpdateDateTime { get; set; }
    public string? LastUpdateUserId { get; set; }
}

public class WorkReportConfigs : IEntityTypeConfiguration<WorkReport>
{
    public void Configure(EntityTypeBuilder<WorkReport> builder)
    {
        builder.HasMany(p => p.WorkChallenges)
               .WithMany(p => p.WorkReports)
               .UsingEntity<WorkReportWorkChallenge>("WorkReportWorkChallenge",
               l => l.HasOne(typeof(WorkReport)).WithMany().HasForeignKey("WorkReportId").HasPrincipalKey(nameof(WorkReport.Id)),
            r => r.HasOne(typeof(WorkChallenge)).WithMany().HasForeignKey("WorkChallengeId").HasPrincipalKey(nameof(WorkChallenge.Id)),
            j => j.HasKey("WorkReportId", "WorkChallengeId"));
    }
}