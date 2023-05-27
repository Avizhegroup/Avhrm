using Avhrm.Identity.Contracts;
using Avhrm.Identity.Server.Extensions;
using Avhrm.Identity.Server.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

namespace Avhrm.Identity.Server.Implementation;

[Authorize]
public class AuthenticationService : IAuthenticationService
{
    private readonly AvhrmIdentityContext context;

    public AuthenticationService(AvhrmIdentityContext context)
    {
        this.context = context;
    }

    [AllowAnonymous]
    public async Task<string> Authenticate(string username, string password)
    {
        string hashedPassword = CryptographyTools.GetHashedStringSha256StringBuilder(password);

        var user = await context.Users
            .FirstOrDefaultAsync(p => p.UserName == username 
                                && p.PasswordHash == hashedPassword);

        if (user is null)
        {
            return string.Empty;
        }

        return false;
    }
}
