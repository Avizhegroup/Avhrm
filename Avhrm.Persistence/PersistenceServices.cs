using Avhrm.Domains;
using Avhrm.Persistence.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProtoBuf.Grpc.Server;

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

        services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<AvhrmDbContext>()
                .AddDefaultTokenProviders();

        services.AddCodeFirstGrpc();
    }
}
