using Avhrm.Identity.Server.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using Avhrm.Identity.Server.Models;
using Microsoft.Extensions.Configuration;
using Avhrm.Identity.Server.Utilities;
using CallContext = ProtoBuf.Grpc.CallContext;
using Avhrm.Identity.Contracts;
using Avhrm.Core.Features.Account.Query.GerUserLogin;
using Avhrm.Core.Common;

namespace Avhrm.Identity.Server.Implementation;

[Authorize]
public class AuthenticationService : IAuthenticationService
{
    private readonly AvhrmIdentityContext context;
    private readonly IConfiguration configuration;

    public AuthenticationService(AvhrmIdentityContext context
        , IConfiguration configuration)
    {
        this.context = context;
        this.configuration = configuration;
    }

    [AllowAnonymous]
    public async Task<BaseDto<string>> Authenticate(GetUserLoginQuery request, CallContext callContext = default)
    {
        string hashedPassword = CryptographyTools.GetHashedStringSha256StringBuilder(request.Password);

        var user = await context.Users
            .FirstOrDefaultAsync(p => p.UserName == request.Username
                                && p.PasswordHash == hashedPassword);

        if (user is null)
        {
            return new() 
            {
                Value = string.Empty 
            };
        }

        var claimsIdentity = GetClaimsIdentity(user);

        var configSec = configuration.GetSection("Identity");

        SecurityTokenDescriptor descriptor = new()
        {             
            Issuer = configSec["Issuer"],
            Audience = configSec["Audience"],
            IssuedAt = DateTime.Now,
            NotBefore = DateTime.Now.AddMinutes(0),
            Expires = DateTime.Now.AddHours(int.Parse(configSec["Expires"])),
            SigningCredentials = CryptographyTools.GetJwtCredential(configSec["Signing"]),
            Subject = claimsIdentity,
            Claims = claimsIdentity.Claims.ToDictionary(claim => claim.Type, claim => (object)claim.Value)
        };

        JwtSecurityTokenHandler tokenHandler = new();

        SecurityToken securityToken = tokenHandler.CreateToken(descriptor);

        string jwt = tokenHandler.WriteToken(securityToken);

        return new()
        {
            Value = jwt
        };
    }

    private ClaimsIdentity GetClaimsIdentity(ApplicationUser user)
    {
        List<Claim> claims = new();

        claims.Add(new(ClaimTypes.Name, user.UserName));

        claims.Add(new(ClaimTypes.NameIdentifier, user.Id));

        claims.Add(new(ClaimTypes.Surname, user.PersianName));

        return new(claims);
    }
}
