using Avhrm.Persistence.Services;

namespace Avhrm.Application.Server.Features;
public class DeleteVacationRequestHandler(AvhrmDbContext context) : IRequestHandler<DeleteVacationRequestCommand, DeleteVacationRequestVm>
{
    public async Task<DeleteVacationRequestVm> Handle(DeleteVacationRequestCommand request, CancellationToken cancellationToken) 
        => new()
        {
            Result = (await context.VacationRequests.Where(p => p.Id == request.Id).ExecuteDeleteAsync(cancellationToken)) > 0,
        };
}
