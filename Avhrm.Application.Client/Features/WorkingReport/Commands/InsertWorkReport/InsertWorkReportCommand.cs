namespace Avhrm.Application.Client.Features;
public class InsertWorkReportCommand : IRequest<InsertWorkReportVm>
{
    [Required]
    public string PersianDate { get; set; }
 
    [StringLength(512)]
    public string? Desc { get; set; }

    [Required]
    [Range(0.5, 100)]
    public decimal SpentHours { get; set; } = 0;

    public int? ProjectId { get; set; }

    public int? CustomerId { get; set; }

    [Required]
    public int WorkTypeId { get; set; }

    [Required]
    public WorkDayType WorkDayType { get; set; } = WorkDayType.WorkDay;

    [Required]
    public WorkReportTimeOfDay WorkReportTimeOfDay { get; set; } = WorkReportTimeOfDay.Morning;

    public IEnumerable<int> WorkChallengesIds { get; set; } = new List<int>();
}
