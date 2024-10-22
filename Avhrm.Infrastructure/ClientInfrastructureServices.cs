using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Avhrm.Infrastructure.Client;
public static class ClientInfrastructureServices
{
    public static void AddClientInfrastructureServices(this IServiceCollection services
        , IConfiguration config)
    {
        services.AddScoped(sp =>
        {
            HttpClient httpClient = new(sp.GetRequiredService<ApiHandler>());

            return httpClient;
        });

        services.AddScoped<ApiHandler>();

        services.AddSerilog(config);
    }
}
