using Avhrm.Core.Features.Account.Query.GerUserLogin;
using Avhrm.Identity.Contracts;

namespace Avhrm.UI.Shared.Pages.Account;

public partial class Login
{
    public GetUserLoginQuery Request { get; set; } = new();

    [Inject] public IAuthenticationService AuthenticationService { get; set; }
    [Inject] public NavigationManager NavigationManager { get; set; }

    public async Task OnValidSubmit(EditContext context)
    {
        string token = await AuthenticationService.Authenticate(Request);

        if (string.IsNullOrEmpty(token))
        {
            return;
        }

        NavigationManager.NavigateTo("/", true);
    }
}
