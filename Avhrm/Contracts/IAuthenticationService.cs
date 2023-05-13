namespace Avhrm.Identity.Contracts;

public interface IAuthenticationService
{
    Task<bool> Authenticate(string username, string password);
    Task Logout();
}
