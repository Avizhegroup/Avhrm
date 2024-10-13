namespace Avhrm.Application.Client.Features;
public class GetWorkReportByIdQuery : IRequest<GetWorkReportByIdVm>
{
    public int Id { get; set; }
}
