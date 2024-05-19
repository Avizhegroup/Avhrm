using Avhrm.UI.Shared.Services;
using Grpc.Net.Client;
using Grpc.Net.Client.Web;
using Microsoft.Extensions.Configuration;
using ProtoBuf.Grpc.Client;
using System.Net;
using System.Net.Security;
using System.Security.Authentication;

namespace Avhrm.UI.Shared.Extensions;

public static class ServicesExtensions
{
    public static void AddGrpcService<TService>(this IServiceCollection services
        , IConfiguration configuration) where TService : class
    {
        services.AddScoped(services =>
        {
            var handler = services.GetRequiredService<AvhrmHttpClient>();

            AppContext.SetSwitch("System.Net.Http.SocketsHttpHandler.Http2UnencryptedSupport", true);
            var channel = GrpcChannel.ForAddress(configuration.GetSection("Api")["Ip"], new GrpcChannelOptions
            {
                HttpHandler = new GrpcWebHandler(handler)
            });

            return channel.CreateGrpcService<TService>();
        });
    }
}
