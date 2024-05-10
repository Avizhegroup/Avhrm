using ProtoBuf;

namespace Avhrm.Core.Features.WorkingReport.Query.GetWorkReportById;

[ProtoContract]
public class GetWorkReportByIdQuery
{
    [ProtoMember(1)]
    public int Id { get; set; }
}
