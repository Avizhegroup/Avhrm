using AutoMapper;
using Avhrm.Domains;
using Avhrm.Persistence.Services;

namespace Avhrm.Application.Server.Features;
public class InsertUserHandler(AvhrmDbContext context
    , IMapper mapper): IRequestHandler<InsertUserCommand, InsertUserVm>
{
    public async Task<InsertUserVm> Handle(InsertUserCommand request, CancellationToken cancellationToken)
    {
        if (await context.Users.AnyAsync(p=> p.UserName == request.Username))
        {
            return new()
            {
                Result = false
            };
        }

        ApplicationUser? user = mapper.Map<ApplicationUser>(request);

        user.Id = Guid.NewGuid().ToString();    

        user.Points = 0;

        user.AccessFailedCount = 0;

        user.SecurityStamp = Guid.NewGuid().ToString();

        user.EmailConfirmed = false;

        user.PhoneNumberConfirmed = false;

        user.TwoFactorEnabled = false;

        user.LockoutEnabled = false;

        return new()
        {
            Result = await context.SaveChangesAsync(cancellationToken) > 0
        };
    }
}
