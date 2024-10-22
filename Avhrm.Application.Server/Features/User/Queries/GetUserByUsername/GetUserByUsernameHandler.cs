using AutoMapper;
using Avhrm.Persistence.Services;

namespace Avhrm.Application.Server.Features;
public class GetUserByUsernameHandler(AvhrmDbContext context
    , IMapper mapper) : IRequestHandler<GetUserByUsernameQuery, GetUserByUsernameVm>
{
    public async Task<GetUserByUsernameVm> Handle(GetUserByUsernameQuery request, CancellationToken cancellationToken)
    => mapper.Map<GetUserByUsernameVm>(
            context.Users
    .Join(context.UserRoles,
        user => user.Id,
        userRole => userRole.UserId,
        (user, userRole) => new { user, userRole })
    .Join(context.Roles,
        userRole => userRole.userRole.RoleId,
        role => role.Id,
        (userRole, role) => new { userRole.user, role })
    .Select(x => new GetUserByUsernameVm()
    {
        Username = x.user.UserName,
        PersianName = x.user.PersianName,
        ParentId = x.user.ParentId,
        DepartmentId = x.user.DepartmentId,
        RoleId = x.role.Id

    }).FirstOrDefault(p => p.Username == request.Username));
}
