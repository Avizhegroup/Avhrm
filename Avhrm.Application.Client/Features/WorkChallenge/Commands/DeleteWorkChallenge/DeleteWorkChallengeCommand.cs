namespace Avhrm.Application.Client.Features;
public class DeleteWorkChallengeCommand : IRequest<DeleteWorkChallengeVm>
{
    public int Id { get; set; }
}
