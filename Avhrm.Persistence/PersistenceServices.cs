using Avhrm.Core.Entities;
using Avhrm.Persistence.Repositories;
using Avhrm.Persistence.Services;
using Microsoft.AspNetCore.Builder;
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
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnectionString"));
        });

        services.AddCodeFirstGrpc();
    }
}
