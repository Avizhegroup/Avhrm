using Grpc.Core;
using ProtoBuf.Grpc;
using System.Security.Claims;

namespace Avhrm.Core.Extensions;

public static class CallContextExtensions
{
    public static Guid GetUserId(this CallContext context)
    {
        var user = context.ServerCallContext.GetHttpContext().User;

        return Guid.Parse(user.Claims.First(item => item.Type == ClaimTypes.NameIdentifier).Value);
    }
}
