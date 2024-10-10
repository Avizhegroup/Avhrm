using Avhrm.Domains;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace Avhrm.Identity.Server.Utilities;
public static class CryptographyTools
{
    public static string GetHashedStringSha256StringBuilder(string data)
    {
        using var sha256 = SHA256.Create();

        var byteHash = sha256.ComputeHash(Encoding.UTF8.GetBytes(data));

        StringBuilder sb = new();

        for (int i = 0; i < byteHash.Length; i++)
        {
            sb.Append(byteHash[i].ToString("x2"));
        }

        return sb.ToString();
    }

    public static bool ValidatePasswordInSHA256(string passHash, string password)
    {
        var passArray = Encoding.UTF8.GetBytes(password);

        var hash256Array = SHA256.HashData(passArray);

        StringBuilder sb = new();

        for (int i = 0; i < hash256Array.Length; i++)
        {
            sb.Append(hash256Array[i].ToString("x2"));
        }

        var hash256 = sb.ToString();

        if (hash256.Equals(passHash))
        {
            return true;
        }

        return false;
    }

    public static SigningCredentials GetJwtCredential(string key)
    {
        SymmetricSecurityKey symmetricKey = GetSymmetricKey(key);

        return new(symmetricKey, SecurityAlgorithms.HmacSha256Signature);
    }

    public static SymmetricSecurityKey GetSymmetricKey(string passKey)
    {
        var key = Encoding.UTF8.GetBytes(passKey);

        return new(key);
    }

    public static ClaimsIdentity GetClaimsIdentity(ApplicationUser user)
    {
        List<Claim> claims = new();

        claims.Add(new(ClaimTypes.Name, user.UserName));

        claims.Add(new(ClaimTypes.NameIdentifier, user.Id));

        claims.Add(new(ClaimTypes.Surname, user.PersianName));

        claims.Add(new(ClaimTypes.UserData, user.DepartmentId.ToString()));

        return new(claims);
    }
}
