using System.Security.Claims;

namespace Avhrm.Tools;
public static class ClaimsPrincipalExtensions
{
    public static string GetUserId(this ClaimsPrincipal principal)
    {
        var claims = ((ClaimsIdentity)principal.Identity).Claims;

        if (claims.Any())
        {
            return claims.FirstOrDefault(p => p.Type == ClaimTypes.NameIdentifier).Value;
        }

        return null;
    }

    public static string GetUsername(this ClaimsPrincipal principal)
    {
        var claims = ((ClaimsIdentity)principal.Identity).Claims;

        if (claims.Any())
        {
            return claims.FirstOrDefault(p => p.Type == ClaimTypes.Name).Value;
        }

        return null;
    }

    public static string GetUserPersianName(this ClaimsPrincipal principal)
    {
        var claims = ((ClaimsIdentity)principal.Identity).Claims;

        if (claims.Any())
        {
            return claims.FirstOrDefault(p => p.Type == "family_name").Value;
        }

        return null;
    }

    public static string GetUserRoleName(this ClaimsPrincipal principal)
    {
        var claims = ((ClaimsIdentity)principal.Identity).Claims;

        var claim = claims.FirstOrDefault(p => p.Type == "role");

        if (claim is not null)
        {
            return claim.Value;
        }

        return null;
    }

    public static string GetDepartmentId(this ClaimsPrincipal principal)
    {
        var claims = ((ClaimsIdentity)principal.Identity).Claims;

        var claim = claims.FirstOrDefault(p => p.Type == ClaimTypes.UserData);

        if (claim is not null)
        {
            return claim.Value;
        }

        return null;
    }
}