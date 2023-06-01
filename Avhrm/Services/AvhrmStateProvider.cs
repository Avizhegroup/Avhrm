using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.JSInterop;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Avhrm.Identity.Services;

public class AvhrmStateProvider : AuthenticationStateProvider
{
    private readonly IJSRuntime jsRuntime;

    public AvhrmStateProvider(IJSRuntime jSRuntime)
    {
        this.jsRuntime = jSRuntime;
    }

    public override async Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        try // this try-catch is used because of pre-rendering of blazor that throws excption on localStorage call
        {
            string? token;

#if BlazorHybrid
            token = Preferences.Get("access_token", null);
#else
            token = await jsRuntime.InvokeAsync<string>("window.localStorage.getItem", "jwt");
#endif
            string? signTime = await jsRuntime.InvokeAsync<string>("window.localStorage.getItem", "signTime");

            if (token.HasNoValue())
            {
                return new(new(new ClaimsIdentity()));
            }

            return new(new(new ClaimsIdentity(GetClaims(token), "jwt")));
        }
        catch (Exception ex)
        {
            return new(new(new ClaimsIdentity()));
        }
    }

    public async Task SetUserAuthenticated(string token)
    {
        var claims = GetClaims(token);

        await jsRuntime.InvokeVoidAsync("window.localStorage.setItem", "jwt", token);

        var authUser = new ClaimsPrincipal(new ClaimsIdentity(claims));

        var authState = Task.FromResult(new AuthenticationState(authUser));

        NotifyAuthenticationStateChanged(authState);
    }

    public async Task SetUserLoggedOut()
    {
#if BlazorHybrid
        Preferences.Remove("access_token");
#else
        await jsRuntime.InvokeVoidAsync("window.localStorage.removeItem", "jwt");
#endif

        var anonUser = new ClaimsPrincipal(new ClaimsIdentity());

        var authState = Task.FromResult(new AuthenticationState(anonUser));

        NotifyAuthenticationStateChanged(authState);
    }

    private IEnumerable<Claim> GetClaims(string token)
    {
        var handler = new JwtSecurityTokenHandler();

        var jwtToken = (JwtSecurityToken)handler.ReadToken(token);

        Claim[] claims = jwtToken.Claims.ToArray();

        return claims;
    }
}
