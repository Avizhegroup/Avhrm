namespace Avhrm.Application.Client.Features;
public class GetWorkReportByIdVm
{
    public int? Id { get; set; }
    public string PersianDate { get; set; }
    public string? Desc { get; set; }
    public decimal SpentHours { get; set; }
    public decimal? EstimateHours { get; set; }
    public int? ProjectId { get; set; }
    public int? CustomerId { get; set; }
    public int WorkTypeId { get; set; }
    public WorkDayType WorkDayType { get; set; }
    public WorkReportTimeOfDay WorkReportTimeOfDay { get; set; }
    public List<int> WorkChallengesIds { get; set; }
}
