using Avhrm.Core.Features.Account.Query.GerUserLogin;
using ProtoBuf.Grpc;
using System.ServiceModel;

namespace Avhrm.Identity.Contracts;

[ServiceContract]
public interface IAuthenticationService
{
    [OperationContract]
    Task<string> Authenticate(GetUserLoginQuery request, CallContext callContext = default);
}
