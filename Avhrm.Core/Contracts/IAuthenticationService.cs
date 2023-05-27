using System.ServiceModel;

namespace Avhrm.Identity.Contracts;

[ServiceContract]
public interface IAuthenticationService
{
    [OperationContract]
    Task<string> Authenticate(string username, string password);
}
