using ProtoBuf;

namespace Avhrm.Core.Features.WorkingReport.Query.GetUserWorkingReportByDate;

[ProtoContract]
public class GetUserWorkingReportByDateQuery
{
    [ProtoMember(1)]
    public DateTime? Date { get; set; }
}
