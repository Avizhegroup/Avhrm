using ProtoBuf;

namespace Avhrm.Core.Features.WorkingReport.Query.GetUserWorkingReportByDate;

[ProtoContract]
public class GetUserWorkingReportByDateQuery
{
    public string Date { get; set; }
}
