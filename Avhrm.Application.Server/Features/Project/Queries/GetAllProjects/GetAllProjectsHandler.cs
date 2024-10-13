using AutoMapper;
using Avhrm.Persistence.Services;

namespace Avhrm.Application.Server.Features;
public class GetAllProjectsHandler(IMapper mapper
    , AvhrmDbContext context) : IRequestHandler<GetAllProjectsQuery, GetAllProjectsVm>
{
    public async Task<GetAllProjectsVm> Handle(GetAllProjectsQuery request, CancellationToken cancellationToken)
    => new() 
    {
        Data = mapper.Map<List<GetAllProjectsDto>>(await context.Projects.ToListAsync())
    };
}
