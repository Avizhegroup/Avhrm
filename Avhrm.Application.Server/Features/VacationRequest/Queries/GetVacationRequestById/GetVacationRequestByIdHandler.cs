using AutoMapper;
using Avhrm.Persistence.Services;
using Microsoft.AspNetCore.Http;

namespace Avhrm.Application.Server.Features;
public class GetVacationRequestByIdHandler(IMapper mapper
    , AvhrmDbContext context
    , IHttpContextAccessor httpContextAccessor) : IRequestHandler<GetVacationRequestByIdQuery, GetVacationRequestByIdVm>
{
    public async Task<GetVacationRequestByIdVm> Handle(GetVacationRequestByIdQuery request, CancellationToken cancellationToken)
    => mapper.Map<GetVacationRequestByIdVm>(await context.VacationRequests.FirstOrDefaultAsync(p => p.CreatorUserId == httpContextAccessor.HttpContext.User.GetUserId() && p.Id == request.VacationRequestId));
}
