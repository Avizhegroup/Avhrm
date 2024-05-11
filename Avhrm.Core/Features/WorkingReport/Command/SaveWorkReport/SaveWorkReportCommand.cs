using Avhrm.Core.Features.WorkingReport.Enum;
using ProtoBuf;
using System.ComponentModel.DataAnnotations;

namespace Avhrm.Core.Features.WorkingReport.Command.SaveWorkReport;

[ProtoContract]
public class SaveWorkReportCommand
{
    [ProtoMember(1)]
    public int? Id { get; set; }

    [ProtoMember(2)]
    public string PersianDate { get; set; }

    [ProtoMember(3)]
    [StringLength(512)]
    public string? Desc { get; set; }

    [ProtoMember(4)]
    [Required]
    public decimal SpentHours { get; set; }

    [ProtoMember(5)]
    public decimal? EstimateHours { get; set; }

    [ProtoMember(6)]
    public int? ProjectId { get; set; }

    [ProtoMember(7)]
    public int? CustomerId { get; set; }

    [ProtoMember(8)]
    [Required]
    public int WorkTypeId { get; set; }

    [ProtoMember(9)]
    [Required]
    public WorkDayType WorkDayType { get; set; }

    [ProtoMember(10)]
    [Required]
    public WorkReportTimeOfDay WorkReportTimeOfDay { get; set; }

    [ProtoMember(11)]
    public IEnumerable<int> WorkChallengesIds { get; set; }
}
