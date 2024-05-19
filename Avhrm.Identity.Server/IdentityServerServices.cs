using Avhrm.Identity.Server.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Avhrm.Identity.Server;
public static class IdentityServerServices
{
    public static void AddIdentityServerServices(this IServiceCollection services
        , IConfiguration configuration)
    { 
        services.AddAvhrmAuthorize(configuration);
    }
}
