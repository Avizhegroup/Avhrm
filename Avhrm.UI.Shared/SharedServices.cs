using Avhrm.Core.Contracts;
using Avhrm.Identity;
using Avhrm.Identity.Contracts;
using Avhrm.UI.Shared.Extensions;
using Microsoft.Extensions.Configuration;

namespace Avhrm.UI.Shared;

public static class SharedServices
{
    public static void AddSharedServices(this IServiceCollection services
        , IConfiguration configuration)
    {
        services.AddHttpClient();

        services.AddGrpcService<IVacationRequest>(configuration);

        services.AddGrpcService<IAuthenticationService>(configuration);

        services.AddIdentityUIServices();
    }
}
