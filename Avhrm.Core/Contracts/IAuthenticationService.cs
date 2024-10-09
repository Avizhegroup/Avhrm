using ProtoBuf.Grpc;

namespace Avhrm.Application;
public interface IAuthenticationService
{
    Task<BaseDto<string>> Authenticate(GetUserLoginQuery request, CallContext callContext = default);
}
