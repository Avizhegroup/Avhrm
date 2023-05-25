using Avhrm.Identity.Server.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Avhrm.Identity.Server;

public static class IdentityServerServices
{
    public static void AddIdentityServerServices(this IServiceCollection services)
    {
        services.AddDbContext<AvhrmIdentityContext>(options =>
        {
            options.UseSqlServer();
        });
    }
}
