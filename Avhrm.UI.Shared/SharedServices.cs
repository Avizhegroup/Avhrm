using Avhrm.Core.Contracts;
using Avhrm.Identity;
using Avhrm.Identity.Contracts;
using Avhrm.UI.Shared.Extensions;

namespace Avhrm.UI.Shared;

public static class SharedServices
{
    public static void AddSharedServices(this IServiceCollection services)
    {
        services.AddGrpcService<IVacationRequest>();

        services.AddGrpcService<IAuthenticationService>();

        services.AddIdentityUIServices();
    }
}
