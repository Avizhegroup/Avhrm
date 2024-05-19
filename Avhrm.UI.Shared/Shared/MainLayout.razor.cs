using Avhrm.Identity.UI.Services;
using Microsoft.AspNetCore.Components.Routing;

namespace Avhrm.UI.Shared;
public partial class MainLayout
{
    public ComponentsContext Context { get; set; } = new();

    [Inject] public NavigationManager NavigationManager { get; set; }
    [Inject] public AvhrmClientAuthenticationStateProvider AuthStateProvider { get; set; }

    protected override async Task OnInitializedAsync()
    {
        NavigationManager.LocationChanged += NavigationManager_LocationChanged;
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
}
