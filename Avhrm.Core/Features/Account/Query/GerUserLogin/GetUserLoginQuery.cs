using ProtoBuf;
using System.ComponentModel.DataAnnotations;

namespace Avhrm.Application.Features.Account.Query.GerUserLogin;

[ProtoContract]
public class GetUserLoginQuery
{
    [Required(ErrorMessageResourceType = typeof(TextResources), ErrorMessageResourceName = "APP_StringKeys_Error_Required")]
    [Display(Name = "APP_StringKeys_Account_Username", ResourceType = typeof(TextResources))]
    [ProtoMember(1)]
    public string Username { get; set; }

    [Required(ErrorMessageResourceType = typeof(TextResources), ErrorMessageResourceName = "APP_StringKeys_Error_Required")]
    [Display(Name = "APP_StringKeys_Account_Password", ResourceType = typeof(TextResources))]
    [ProtoMember(2)]
    public string Password { get; set; }
}
