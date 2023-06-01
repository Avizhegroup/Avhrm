using Avhrm.Identity.Contracts;
using Avhrm.UI.Shared.ViewModels;

namespace Avhrm.UI.Shared.Pages.Account;

public partial class Login
{
    public LoginVm Request { get; set; } = new();

    [Inject] public IAuthenticationService AuthenticationService { get; set; }
    [Inject] public NavigationManager NavigationManager { get; set; }

    public async Task OnValidSubmit(EditContext context)
    {
        string token = await AuthenticationService.Authenticate(Request.Username, Request.Password);

        if (string.IsNullOrEmpty(token))
        {
            return;
        }

        NavigationManager.NavigateTo("/", true);
    }
}
