using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.JSInterop;

namespace Avhrm.Identity.Implementation;

public class AvhrmAuthenticationStateProvider : AuthenticationStateProvider
{
    private readonly IJSRuntime jsRuntime;

    public AvhrmAuthenticationStateProvider(IJSRuntime jSRuntime)
    {
        jsRuntime = jSRuntime;
    }

    public override async Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        try // this try-catch is used because of pre-rendering of blazor that throws excption on localStorage call
        {
            string? token = await jsRuntime.InvokeAsync<string>("window.localStorage.getItem", "jwt");

            string? signTime = await jsRuntime.InvokeAsync<string>("window.localStorage.getItem", "signTime");

            if (token.HasNoValue())
            {
                return new(new(new ClaimsIdentity()));
            }
            else
            {
                if ((DateTime.Now - DateTime.Parse(signTime)).TotalMinutes > 30)
                {
                    return new(new(new ClaimsIdentity()));
                }
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

        string signTime = DateTime.Now.ToString();

        string userId = claims.FirstOrDefault(p => p.Type == "nameid").Value;

        string username = claims.FirstOrDefault(p => p.Type == "unique_name").Value;

        await jsRuntime.InvokeVoidAsync("window.localStorage.setItem", "token", userId);

        await jsRuntime.InvokeVoidAsync("window.localStorage.setItem", "jwt", token);

        await jsRuntime.InvokeVoidAsync("window.localStorage.setItem", "username", username);

        await jsRuntime.InvokeVoidAsync("window.localStorage.setItem", "signTime", signTime);

        var authUser = new ClaimsPrincipal(new ClaimsIdentity(claims));

        var authState = Task.FromResult(new AuthenticationState(authUser));

        NotifyAuthenticationStateChanged(authState);
    }

    public async Task SetUserLoggedOut()
    {
        await jsRuntime.InvokeVoidAsync("window.localStorage.removeItem", "token");

        await jsRuntime.InvokeVoidAsync("window.localStorage.removeItem", "username");

        await jsRuntime.InvokeVoidAsync("window.localStorage.removeItem", "jwt");

        await jsRuntime.InvokeVoidAsync("window.localStorage.removeItem", "signTime");

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
