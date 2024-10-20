using AutoMapper;
using Avhrm.Persistence.Services;

namespace Avhrm.Application.Server.Features;
public class GetAllDepartmentHandler(AvhrmDbContext context
    , IMapper mapper) :IRequestHandler<GetAllDepartmentQuery, GetAllDepartmentVm>
{
    public async Task<GetAllDepartmentVm> Handle(GetAllDepartmentQuery request, CancellationToken cancellationToken)
    => new()
    {
        Data = mapper.Map<List<GetAllDepartmentDto>>(context.Departments)
    };
}
