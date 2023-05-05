using Grpc.Net.Client;
using Microsoft.AspNetCore.Components;
using ProtoBuf.Grpc.Client;

namespace Avhrm.UI.Shared.Extensions;

public static class ServicesExtensions
{
    public static void AddGrpcService<TService>(this IServiceCollection services) where TService : class
    {
        services.AddScoped(services =>
        {
            var httpClient = GetHttpClient(services);
            
            var backendUrl = services.GetRequiredService<NavigationManager>().BaseUri;
            
            var channel = GrpcChannel.ForAddress(backendUrl, new GrpcChannelOptions
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
