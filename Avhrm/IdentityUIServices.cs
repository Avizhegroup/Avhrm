using Avhrm.Identity.Services;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.Extensions.DependencyInjection;

namespace Avhrm.Identity;

public static class IdentityUIServices
{
    public static void AddIdentityUIServices(this IServiceCollection services)
    {
        services.AddScoped<AuthenticationStateProvider, AvhrmStateProvider>();

        services.AddScoped(sp => (AvhrmStateProvider)sp.GetRequiredService<AuthenticationStateProvider>());
    }
}
