using AutoMapper;
using Avhrm.Persistence.Services;

namespace Avhrm.Application.Server.Features;
public class GetAllCustomersHandler(IMapper mapper
    , AvhrmDbContext context) : IRequestHandler<GetAllCustomersQuery, GetAllCustomersVm>
{
    public async Task<GetAllCustomersVm> Handle(GetAllCustomersQuery request, CancellationToken cancellationToken)
    => new GetAllCustomersVm()
    { 
        Data = mapper.Map<List<GetAllCustomersDto>>(await context.Customers.ToListAsync())
    };
}
