using Avhrm.Identity.Contracts;
using Microsoft.AspNetCore.Authorization;

namespace Avhrm.Identity.Server.Implementation;

[Authorize]
public class AuthenticationService : IAuthenticationService
{
    [AllowAnonymous]
    public async Task<bool> Authenticate(string username, string password)
    {
        return false;
    }
}
