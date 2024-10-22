using AutoMapper;
using Avhrm.Domains;
using Avhrm.Persistence.Services;

namespace Avhrm.Application.Server.Features;
public class GetAllUsersHandler(AvhrmDbContext context
    , IMapper mapper) : IRequestHandler<GetAllUsersQuery, GetAllUsersVm>
{
    public async Task<GetAllUsersVm> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
    => new()
    {
        Data = mapper.Map<List<GetAllUsersDto>>(context.Users
                                                       .Include(p=>p.Department))
    };
}
