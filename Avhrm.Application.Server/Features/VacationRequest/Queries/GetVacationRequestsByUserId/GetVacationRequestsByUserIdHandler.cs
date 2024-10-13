using AutoMapper;
using Avhrm.Persistence.Services;
using Microsoft.AspNetCore.Http;

namespace Avhrm.Application.Server.Features;
public class GetVacationRequestsByUserIdHandler(IMapper mapper
    , AvhrmDbContext context
    , IHttpContextAccessor httpContextAccessor) : IRequestHandler<GetVacationRequestsByUserIdQuery, GetVacationRequestsByUserIdVm>
{
    public async Task<GetVacationRequestsByUserIdVm> Handle(GetVacationRequestsByUserIdQuery request, CancellationToken cancellationToken)
    => new()
    {
        Data = mapper.Map<List<GetVacationRequestsByUserIdDto>>(await context.VacationRequests
                     .Where(p => p.CreatorUserId == request.UserId)
                     .AsNoTracking()
                     .ToListAsync())
    };
}
