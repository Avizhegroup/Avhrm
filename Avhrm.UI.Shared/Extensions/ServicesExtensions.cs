using Grpc.Net.Client;
using Microsoft.Extensions.Configuration;
using ProtoBuf.Grpc.Client;

namespace Avhrm.UI.Shared.Extensions;

public static class ServicesExtensions
{
    public static void AddGrpcService<TService>(this IServiceCollection services
        , IConfiguration configuration) where TService : class
    {
        services.AddScoped(services =>
        {
            var httpClient = GetHttpClient(services);
            
            var channel = GrpcChannel.ForAddress(configuration.GetSection("Api")["Ip"], new GrpcChannelOptions
            {
                HttpClient = httpClient,
            });

            return channel.CreateGrpcService<TService>();
        });
    }

    private static HttpClient GetHttpClient(IServiceProvider services)
    {
        var httpClient = services.GetRequiredService<HttpClient>();

        return httpClient;
    }
}
