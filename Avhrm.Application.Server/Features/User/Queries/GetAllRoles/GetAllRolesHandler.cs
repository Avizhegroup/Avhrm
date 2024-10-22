using AutoMapper;
using Avhrm.Persistence.Services;

namespace Avhrm.Application.Server.Features;
public class GetAllRolesHandler(AvhrmDbContext context
    , IMapper mapper): IRequestHandler<GetAllRolesQuery, GetAllRolesVm>
{
    public async Task<GetAllRolesVm> Handle(GetAllRolesQuery request, CancellationToken cancellationToken)
    => new() 
    { 
       Data = mapper.Map<List<GetAllRolesDto>>(context.Roles)
    };
}
