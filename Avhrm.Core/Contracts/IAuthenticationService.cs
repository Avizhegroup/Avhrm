using System.ServiceModel;

namespace Avhrm.Identity.Contracts;

[ServiceContract]
public interface IAuthenticationService
{
    [OperationContract]
    Task<bool> Authenticate(string username, string password);
}
