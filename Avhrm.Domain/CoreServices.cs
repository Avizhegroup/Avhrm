using Microsoft.Extensions.DependencyInjection;
using ProtoBuf.Grpc.Server;

namespace Avhrm.Core;

public static class CoreServices
{
    public static void AddCoreServices(this IServiceCollection services)
    {
        services.AddCodeFirstGrpc();
    }
}
