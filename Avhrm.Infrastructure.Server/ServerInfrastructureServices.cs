using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Avhrm.Infrastructure.Server;

public static class ServerInfrastructureServices
{
    public static void AddServerInfrastructureServices(this IServiceCollection services
        , IConfiguration configuration)
    {
        services.AddSerilog(configuration);
    }
}
