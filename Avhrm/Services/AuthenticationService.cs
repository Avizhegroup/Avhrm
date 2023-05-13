namespace Avhrm.Identity.Services;

public class AuthenticationService : IAuthenticationService
{
    private readonly RfidConnectApi api;
    private readonly SiloAuthenticationStateProvider authenticationStateProvider;

    public AuthenticationService(RfidConnectApi api
        , SiloAuthenticationStateProvider authenticationStateProvider)
    {
        this.api = api;
        this.authenticationStateProvider = authenticationStateProvider;
    }

    public async Task<bool> Authenticate(string username, string password)
    {
        var authenticationResponse = await api.PostAsyncByUri<string>("Account/AuthenticateByPassword"
            , new KeyValuePair<string, object>("Username", username)
            , new KeyValuePair<string, object>("Password", password));

        if (authenticationResponse.Successful)
        {
            await authenticationStateProvider.SetUserAuthenticated(authenticationResponse.Value);

            return true;
        }

        return false;
    }

    public async Task Logout()
    {
        await authenticationStateProvider.SetUserLoggedOut();
    }

}
