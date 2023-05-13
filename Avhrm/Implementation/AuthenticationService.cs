using Avhrm.Identity.Contracts;

namespace Avhrm.Identity.Implementation;

public class AuthenticationService : IAuthenticationService
{
    private readonly AvhrmAuthenticationStateProvider authenticationStateProvider;

    public AuthenticationService(AvhrmAuthenticationStateProvider authenticationStateProvider)
    {
        this.authenticationStateProvider = authenticationStateProvider;
    }

    public async Task<bool> Authenticate(string username, string password)
    {
        return false;
    }

    public async Task Logout()
    {
        await authenticationStateProvider.SetUserLoggedOut();
    }
}
