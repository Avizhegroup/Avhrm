using ProtoBuf;

namespace Avhrm.Application.Features.WorkingReport.Query.GetWorkReportById;

[ProtoContract]
public class GetWorkReportByIdQuery
{
    [ProtoMember(1)]
    public int Id { get; set; }
}
