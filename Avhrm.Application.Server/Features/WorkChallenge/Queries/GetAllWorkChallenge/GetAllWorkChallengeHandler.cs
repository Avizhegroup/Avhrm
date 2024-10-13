using AutoMapper;
using Avhrm.Persistence.Services;
using Microsoft.AspNetCore.Http;

namespace Avhrm.Application.Server.Features;
public class GetAllWorkChallengeHandler(IMapper mapper
    , AvhrmDbContext context
    , IHttpContextAccessor httpContextAccessor) : IRequestHandler<GetAllWorkChallengeQuery, GetAllWorkChallengeVm>
{
    public async Task<GetAllWorkChallengeVm> Handle(GetAllWorkChallengeQuery request, CancellationToken cancellationToken)
    => new()
    {
        Data = mapper.Map<List<GetAllWorkChallengeDto>>(context.WorkChallenges.Where(p => p.DepartmentId == int.Parse(httpContextAccessor.HttpContext.User.GetDepartmentId())))
    };
}
