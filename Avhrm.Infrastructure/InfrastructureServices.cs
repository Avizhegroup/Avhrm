using Microsoft.Extensions.DependencyInjection;
using ProtoBuf.Grpc.Server;

namespace Avhrm.Infrastructure;
public static class InfrastructureServices
{
    public static void AddInfrastructureServices(this IServiceCollection services)
    {
        services.AddCodeFirstGrpc(options =>
        {
            options.EnableDetailedErrors = true;
            options.ResponseCompressionLevel = System.IO.Compression.CompressionLevel.Optimal;
        });
    }
}
