using Avhrm.Identity.Server.Extensions;
using Avhrm.Identity.Server.Models;
using Avhrm.Identity.Server.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Avhrm.Identity.Server;

public static class IdentityServerServices
{
    public static void AddIdentityServerServices(this IServiceCollection services
        , IConfiguration configuration)
    {
        services.AddDbContext<AvhrmIdentityContext>(options =>
         { 
             options.UseSqlServer(configuration.GetConnectionString("Identity")); 
         });

        services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<AvhrmIdentityContext>()
                .AddDefaultTokenProviders();

        services.AddAvhrmAuthorize(configuration);
    }
}
