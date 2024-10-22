using Avhrm.Identity.UI.Services;
using Avhrm.UI.Shared.Tools;
using Microsoft.AspNetCore.Components.Routing;

namespace Avhrm.UI.Shared;
public partial class MainLayout
{
    public bool IsAdmin = false;
    public string Name;
    public ComponentsContext Context { get; set; } = new();

    [Inject] public NavigationManager NavigationManager { get; set; }
    [Inject] public AvhrmClientAuthenticationStateProvider AuthStateProvider { get; set; }
    [Inject] public IJSRuntime JSRuntime { get; set; }

    protected override async Task OnInitializedAsync()
    {
        NavigationManager.LocationChanged += NavigationManager_LocationChanged;

        var user = (await AuthStateProvider.GetAuthenticationStateAsync()).User;

        if (user.Identities.Any(p=>p.IsAuthenticated))
        {
            Name = user.GetUserPersianName();

            IsAdmin = user.GetUserRoleName().ToLower() == "admin";
        }
        
        Context.OnChange += StateHasChanged;
    }

    public void NavigationManager_LocationChanged(object? sender, LocationChangedEventArgs e)
    {
        Context.IsDrawerOpen = false;

        StateHasChanged();
    }

    public async Task OnSwipEnd(SwipeEventArgs e)
    {
        if (e.SwipeDirection == SwipeDirection.RightToLeft)
        {
            Context.IsDrawerOpen = true;
        }
        else if (e.SwipeDirection == SwipeDirection.LeftToRight)
        {
            Context.IsDrawerOpen = false;
        }
    }

    public async Task OnClickExit()
    {
        await AuthStateProvider.SetUserLoggedOut();
    }

    public async Task OnToggleDrawerClick()
    {
        Context.IsDrawerOpen = !Context.IsDrawerOpen;
    }

    public async Task OnOverlayClick(bool newValue)
    {
        if (!newValue)
        {
            Context.IsDrawerOpen = false;
        }
    }

    public async Task OnBackClick()
    {
        await JSRuntime.InvokeVoidAsync("history.back");
    }
}
