using Avhrm.Identity.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Avhrm.Identity;

public static class IdentityServices
{
    public static void AddIdentityServices(this IServiceCollection services)
    {
        services.AddDbContext<AvhrmIdentityContext>(options =>
        {
            options.UseSqlServer();
        });
    }
}
