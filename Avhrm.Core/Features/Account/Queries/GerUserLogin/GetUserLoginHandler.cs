using Avhrm.Identity.Server.Utilities;
using Avhrm.Persistence.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;

namespace Avhrm.Application.Server.Features;
public class GetUserLoginHandler(AvhrmDbContext context
    , IConfiguration configuration) : IRequestHandler<GetUserLoginQuery, GetUserLoginVm>
{
    public async Task<GetUserLoginVm> Handle(GetUserLoginQuery request, CancellationToken cancellationToken)
    {
        string hashedPassword = CryptographyTools.GetHashedStringSha256StringBuilder(request.Password);

        var user = await context.Users
                                             .FirstOrDefaultAsync(p =>
                                             p.UserName == request.Username
                                          && p.PasswordHash == hashedPassword);

        if (user is null)
        {
            return new()
            {
                Token = string.Empty
            };
        }

        var claimsIdentity = CryptographyTools.GetClaimsIdentity(user);

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
            Token = jwt
        };
    }
}
