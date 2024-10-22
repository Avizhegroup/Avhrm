using Avhrm.Application.Client;
using Avhrm.Identity;
using Avhrm.Infrastructure.Client;
using Microsoft.Extensions.Configuration;
using MudBlazor.Services;

namespace Avhrm.UI.Shared;
public static class SharedServices
{
    public static void AddSharedServices(this IServiceCollection services
        , IConfiguration configuration)
    {
        services.AddClientInfrastructureServices(configuration);

        services.AddIdentityUIServices();

        services.AddMudServices();

        services.AddClientApplicationServices();
    }
}
