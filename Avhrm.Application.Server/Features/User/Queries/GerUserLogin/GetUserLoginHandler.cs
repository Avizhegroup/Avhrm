using Avhrm.Domains;
using Avhrm.Identity.Server.Utilities;
using Avhrm.Persistence.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
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

        var user = context.Users
    .Join(context.UserRoles,
        user => user.Id,
        userRole => userRole.UserId,
        (user, userRole) => new { user, userRole })
    .Join(context.Roles,
        userRole => userRole.userRole.RoleId,
        role => role.Id,
        (userRole, role) => new { userRole.user, role })
    .Where(x => x.user.UserName == request.Username && x.user.PasswordHash == hashedPassword)
    .Select(x => new ApplicationUser
    {
        Id = x.user.Id,
        UserName = x.user.UserName,
        PersianName = x.user.PersianName,
        Parent = x.user.Parent,
        Children = x.user.Children,
        DepartmentId = x.user.DepartmentId,
        Department = x.user.Department,
        Points = x.user.Points,
        RoleName = x.role.Name
    })
    .FirstOrDefault();

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
            Expires = DateTime.Now.AddDays(2),
            SigningCredentials = CryptographyTools.GetJwtCredential("84311GFT66934ECC86D327R7CF4F2OPC"),
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
