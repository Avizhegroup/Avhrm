namespace Avhrm.Application.Features ;

public class GetUserLoginQuery
{
    [Required(ErrorMessageResourceType = typeof(TextResources), ErrorMessageResourceName = "APP_StringKeys_Error_Required")]
    [Display(Name = "APP_StringKeys_Account_Username", ResourceType = typeof(TextResources))]
    public string Username { get; set; }

    [Required(ErrorMessageResourceType = typeof(TextResources), ErrorMessageResourceName = "APP_StringKeys_Error_Required")]
    [Display(Name = "APP_StringKeys_Account_Password", ResourceType = typeof(TextResources))]
    public string Password { get; set; }
}
