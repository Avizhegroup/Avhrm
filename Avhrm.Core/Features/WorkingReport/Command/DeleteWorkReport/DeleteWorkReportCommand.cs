using ProtoBuf;

namespace Avhrm.Core.Features.WorkingReport.Command.DeleteWorkReport;

[ProtoContract]
public class DeleteWorkReportCommand
{
    [ProtoMember(1)]
    public int? Id { get; set; }
} 
