namespace Avhrm.Application.Client.Features;
public class GetVacationRequestByIdQuery : IRequest<GetVacationRequestByIdVm>
{
    public int VacationRequestId { get; set; }
}
