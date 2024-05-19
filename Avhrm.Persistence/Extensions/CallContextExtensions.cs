using Grpc.Core;
using ProtoBuf.Grpc;
using System.Security.Claims;

namespace Avhrm.Persistence;

public static class CallContextExtensions
{
    public static string GetUserId(this CallContext context)
    {
        var user = context.ServerCallContext.GetHttpContext().User;

        var claims = ((ClaimsIdentity)user.Identity).Claims;

        if (claims.Any())
        {
            return claims.FirstOrDefault(p => p.Type == ClaimTypes.NameIdentifier).Value;
        }

        return null;
    }

    public static string GetUsername(this CallContext context)
    {
        var user = context.ServerCallContext.GetHttpContext().User;

        var claims = ((ClaimsIdentity)user.Identity).Claims;

        if (claims.Any())
        {
            return claims.FirstOrDefault(p => p.Type == ClaimTypes.Name).Value;
        }

        return null;
    }

    public static string GetUserPersianName(this CallContext context)
    {
        var user = context.ServerCallContext.GetHttpContext().User;

        var claims = ((ClaimsIdentity)user.Identity).Claims;

        if (claims.Any())
        {
            return claims.FirstOrDefault(p => p.Type == ClaimTypes.Surname).Value;
        }

        return null;
    }

    public static int? GetDepartmentId(this CallContext context)
    {
        var user = context.ServerCallContext.GetHttpContext().User;

        var claims = ((ClaimsIdentity)user.Identity).Claims;

        var claim = claims.FirstOrDefault(p => p.Type == ClaimTypes.UserData);

        if (claim is not null)
        {
            return int.Parse(claim.Value);
        }

        return null;
    }
}
