namespace Avhrm.Application.Client.Features;
public class GetVacationRequestsByUserIdQuery : IRequest<GetVacationRequestsByUserIdVm>
{
    public string UserId { get; set; }
}
