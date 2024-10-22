
using AutoMapper;
using Avhrm.Persistence.Services;
using Microsoft.AspNetCore.Http;

namespace Avhrm.Application.Server.Features;
public class GetAllWorkTypesHandler(IMapper mapper
    , AvhrmDbContext context
    , IHttpContextAccessor httpContextAccessor) : IRequestHandler<GetAllWorkTypesQuery, GetAllWorkTypesVm>
{
    public async Task<GetAllWorkTypesVm> Handle(GetAllWorkTypesQuery request, CancellationToken cancellationToken)
    => new()
    {
        Data = mapper.Map<List<GetAllWorkTypesDto>>(context.WorkTypes
                                                           .Where(p => p.DepartmentId == int.Parse(httpContextAccessor.HttpContext.User.GetDepartmentId())))
    };
}