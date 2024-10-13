using Avhrm.Domains;
using Avhrm.Persistence.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Avhrm.Persistence;
public static class PersistenceServices
{
    public static void AddPersistenceServices(this IServiceCollection services
        , IConfiguration configuration)
    {
        services.AddDbContext<AvhrmDbContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("Server"));
        });

        services.AddIdentityCore<ApplicationUser>()
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<AvhrmDbContext>();
    }
}
