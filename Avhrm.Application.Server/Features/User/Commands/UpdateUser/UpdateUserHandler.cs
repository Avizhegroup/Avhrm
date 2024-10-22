using AutoMapper;
using Avhrm.Identity.Server.Utilities;
using Avhrm.Persistence.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;

namespace Avhrm.Application.Server.Features;

public class UpdateUserHandler(IMapper mapper
    , AvhrmDbContext context
    , IHttpContextAccessor httpContextAccessor
    , ILogger<UpdateUserHandler> logger) : IRequestHandler<UpdateUserCommand, UpdateUserVm>
{
    public async Task<UpdateUserVm> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        try
        {
            using var transaction = context.Database.BeginTransaction();

            var user = await context.Users.FirstOrDefaultAsync(p => p.UserName == request.Username, cancellationToken);

            user.PersianName = request.PersianName;

            user.PasswordHash = CryptographyTools.GetHashedStringSha256StringBuilder(request.Password);

            user.DepartmentId = request.DepartmentId;

            user.ParentId = request.ParentId;

            context.Update(user);

            await context.SaveChangesAsync(cancellationToken);

            await context.UserRoles.Where(p => p.UserId == user.Id)
                                   .ExecuteDeleteAsync(cancellationToken);

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
            logger.LogError(ex, ex.Message);

            return new()
            {
                Result = false
            };
        }
    }
}
