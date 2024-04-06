using Avhrm.Core.Features.Account.Query.GerUserLogin;
using Avhrm.Identity.Contracts;
using Avhrm.Identity.UI.Services;

namespace Avhrm.UI.Shared.Pages.Account;
public partial class Login
{
    public bool IsMessageShown = false;
    public string MessageText = string.Empty;

    public GetUserLoginQuery Request { get; set; } = new();

    [Inject] public IAuthenticationService AuthenticationService { get; set; } 
    [Inject] public AvhrmClientAuthenticationStateProvider ClientAuthProvider { get; set; }
    [Inject] public NavigationManager NavigationManager { get; set; }

    public MudAlert Alert { get; set; }

    public async Task OnValidSubmit(EditContext context)
    {
        var token = await AuthenticationService.Authenticate(Request);

        if (token.Value.HasNoValue())
        {
            IsMessageShown = true;

            MessageText = TextResources.APP_StringKeys_Error_Login;

            return;
        }

        await ClientAuthProvider.SetUserAuthenticated(token.Value);

        NavigationManager.NavigateTo("/", true);
    }

    public async Task OnInvalidSubmit(EditContext context)
    {
        IsMessageShown = true;

        MessageText = string.Empty;

        foreach (var valid in context.GetValidationMessages())
        {
            MessageText += $"{valid} \n"; 
        }
    }
}
