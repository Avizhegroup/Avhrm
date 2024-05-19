using Avhrm.Identity.UI.Services;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.Extensions.DependencyInjection;

namespace Avhrm.Identity;

public static class IdentityUIServices
{
    public static void AddIdentityUIServices(this IServiceCollection services)
    {
        services.AddAuthorizationCore();

        services.AddScoped<AuthenticationStateProvider, AvhrmClientAuthenticationStateProvider>();

        services.AddScoped(sp => (AvhrmClientAuthenticationStateProvider)sp.GetRequiredService<AuthenticationStateProvider>());
    }
}
