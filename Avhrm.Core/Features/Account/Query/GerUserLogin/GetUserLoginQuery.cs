using ProtoBuf;
using System.ComponentModel.DataAnnotations;

namespace Avhrm.Core.Features.Account.Query.GerUserLogin;

[ProtoContract]
public class GetUserLoginQuery
{
    [Required]
    [ProtoMember(1)]
    public string Username { get; set; }

    [Required]
    [ProtoMember(2)]
    public string Password { get; set; }
}
