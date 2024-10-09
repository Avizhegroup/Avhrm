using Avhrm.Application.Common;
using Avhrm.Application.Features.Account.Query.GerUserLogin;
using ProtoBuf.Grpc;
using ProtoBuf.Grpc.Configuration;

namespace Avhrm.Application;

[Service]
public interface IAuthenticationService
{
    Task<BaseDto<string>> Authenticate(GetUserLoginQuery request, CallContext callContext = default);
}
