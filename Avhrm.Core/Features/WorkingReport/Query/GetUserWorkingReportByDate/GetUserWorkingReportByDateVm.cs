using ProtoBuf;

namespace Avhrm.Application.Features.WorkingReport.Query.GetUserWorkingReportByDate;

[ProtoContract]
public class GetUserWorkingReportByDateVm
{
    [ProtoMember(1)]
    public int Id { get; set; }

    [ProtoMember(2)]
    public string PersianDate { get; set; }

    [ProtoMember(3)]
    public decimal SpentHours { get; set; }

    [ProtoMember(4)]
    public string WorkTypeDescription { get; set; }

    [ProtoMember(5)]
    public string Desc { get; set; }
}
