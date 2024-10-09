using ProtoBuf;

namespace Avhrm.Application.Features.WorkingReport.Command.DeleteWorkReport;

[ProtoContract]
public class DeleteWorkReportCommand
{
    [ProtoMember(1)]
    public int? Id { get; set; }
} 
