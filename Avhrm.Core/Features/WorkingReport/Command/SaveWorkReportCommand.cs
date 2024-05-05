using Avhrm.Core.Features.WorkingReport.Enum;
using System.ComponentModel.DataAnnotations;

namespace Avhrm.Core.Features.WorkingReport.Command;

public class SaveWorkReportCommand
{
    public int? Id { get; set; }

    public string PersianDate { get; set; }

    [StringLength(512)]
    public string? Desc { get; set; }

    [Required]
    public decimal SpentHours { get; set; }

    public int? ProjectId { get; set; }

    public int? CustomerId { get; set; }

    [Required]
    public int WorkTypeId { get; set; }

    [Required]
    public WorkDayType WorkDayType { get; set; }

    [Required]
    public WorkReportTimeOfDay WorkReportTimeOfDay { get; set; }

    public List<int> WorkChallenges { get; set; }
}
