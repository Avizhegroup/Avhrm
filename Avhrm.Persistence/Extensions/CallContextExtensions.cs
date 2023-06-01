using Grpc.Core;
using ProtoBuf.Grpc;
using System.Security.Claims;

namespace Avhrm.Persistence;

public static class CallContextExtensions
{
    public static string GetUserId(this CallContext context)
    {
        var user = context.ServerCallContext.GetHttpContext().User;

        return user.Claims.First(item => item.Type == ClaimTypes.NameIdentifier).Value;
    }
}
