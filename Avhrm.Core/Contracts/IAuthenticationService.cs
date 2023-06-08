using Avhrm.Core.Common;
using Avhrm.Core.Features.Account.Query.GerUserLogin;
using ProtoBuf.Grpc;
using ProtoBuf.Grpc.Configuration;

namespace Avhrm.Identity.Contracts;

[Service]
public interface IAuthenticationService
{
    Task<BaseDto<string>> Authenticate(GetUserLoginQuery request, CallContext callContext = default);
}
