using AutoMapper;
using Avhrm.Domains;
using Avhrm.Persistence.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;

namespace Avhrm.Application.Server.Features;
public class InsertUserHandler(AvhrmDbContext context
    , IMapper mapper
    , ILogger<InsertUserHandler> logger) : IRequestHandler<InsertUserCommand, InsertUserVm>
{
    public async Task<InsertUserVm> Handle(InsertUserCommand request, CancellationToken cancellationToken)
    {
        try
        {
            using var transaction = await context.Database.BeginTransactionAsync(cancellationToken);

            if (await context.Users.AnyAsync(p => p.UserName == request.Username, cancellationToken))
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

            await context.AddAsync(user, cancellationToken);

            await context.SaveChangesAsync(cancellationToken);

            IdentityUserRole<string> userRole = new()
            {
                RoleId = request.RoleId,
                UserId = user.Id
            };

            await context.AddAsync(userRole, cancellationToken);

            await context.SaveChangesAsync(cancellationToken);

            await transaction.CommitAsync(cancellationToken);

            return new()
            {
                Result = true
            };
        }
        catch (Exception ex)
        {
            logger.LogWarning(ex, ex.Message);

            return new()
            {
                Result = false
            };
        }
    }
}
