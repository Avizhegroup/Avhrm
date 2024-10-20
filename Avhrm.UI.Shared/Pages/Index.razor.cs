using Avhrm.Identity.UI.Services;
using Microsoft.AspNetCore.Components.Web;
using System.Security.Claims;

namespace Avhrm.UI.Shared.Pages;

public partial class Index
{
    public ClaimsPrincipal User;

    [Inject] public NavigationManager NavigationManager { get; set; }
    [Inject] public AvhrmClientAuthenticationStateProvider AuthState { get; set; }

    [CascadingParameter] public ComponentsContext Context { get; set; }

    protected override async Task OnInitializedAsync()
    {
        Context.IsDrawerShown = true;

        Context.IsBackButtonShown = false;

        User = (await AuthState.GetAuthenticationStateAsync()).User;
    }

    public async Task OnWorkingSearchClick(MouseEventArgs e)
    {
        NavigationManager.NavigateTo("/workingreport/search");
    }

    public async Task OnWorkingChallengeClick(MouseEventArgs e)
    {
        NavigationManager.NavigateTo("/workingchallenge/manage");
    }

    public async Task OnAccountManageClick(MouseEventArgs e)
    {
        NavigationManager.NavigateTo("/account/manage");
    }
}
