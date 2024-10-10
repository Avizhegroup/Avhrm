using ProtoBuf.Grpc;

namespace Avhrm.Application.Server;;
public interface IAuthenticationService
{
    Task<BaseDto<string>> Authenticate(GetUserLoginQuery request, CallContext callContext = default);
}
