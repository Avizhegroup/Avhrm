using AutoMapper;
using Avhrm.Persistence.Services;

namespace Avhrm.Application.Server.Features;
public class GetUserByUsernameHandler(AvhrmDbContext context
    , IMapper mapper) : IRequestHandler<GetUserByUsernameQuery, GetUserByUsernameVm>
{
    public async Task<GetUserByUsernameVm> Handle(GetUserByUsernameQuery request, CancellationToken cancellationToken)
    => mapper.Map<GetUserByUsernameVm>(context.Users.Include(p => p.Department)
                                                    .FirstOrDefault(p => p.UserName == request.Username));
}
