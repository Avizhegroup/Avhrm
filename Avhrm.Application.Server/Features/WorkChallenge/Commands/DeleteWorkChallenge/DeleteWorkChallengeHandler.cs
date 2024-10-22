using AutoMapper;
using Avhrm.Persistence.Services;

namespace Avhrm.Application.Server.Features;

public class DeleteWorkChallengeHandler (AvhrmDbContext context
    , IMapper mapper): IRequestHandler<DeleteWorkChallengeCommand, DeleteWorkChallengeVm>
{
    public async Task<DeleteWorkChallengeVm> Handle(DeleteWorkChallengeCommand request, CancellationToken cancellationToken)
    => new()
    {
        Result = (await context.WorkChallenges
                               .Where(p=> p.Id == request.Id)
                               .ExecuteDeleteAsync(cancellationToken)) > 0
    };
}
