using Avhrm.Identity.Contracts;
using Avhrm.Identity.Implementation;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.Extensions.DependencyInjection;

namespace Avhrm.Identity;

public static class IdentityUIServices
{
    public static void AddIdentityUIServices(this IServiceCollection services)
    {
        services.AddScoped<AuthenticationStateProvider, AvhrmAuthenticationStateProvider>();

        services.AddScoped(sp => (AvhrmAuthenticationStateProvider)sp.GetRequiredService<AuthenticationStateProvider>());
    }
}
