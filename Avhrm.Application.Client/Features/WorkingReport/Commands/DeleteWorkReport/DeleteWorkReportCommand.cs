namespace Avhrm.Application.Client.Features;
public class DeleteWorkReportCommand : IRequest<DeleteWorkReportVm>
{
    public int Id { get; set; }
} 
