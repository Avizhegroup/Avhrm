using Microsoft.AspNetCore.Components.Routing;
using Microsoft.AspNetCore.Components.Web;

namespace Avhrm.UI.Shared;
public partial class MainLayout
{
    public bool IsDrawerOpen = false;

    [Inject] public NavigationManager NavigationManager { get; set; }

    protected override async Task OnInitializedAsync()
    {
        NavigationManager.LocationChanged += NavigationManager_LocationChanged;
    }

    public void NavigationManager_LocationChanged(object? sender, LocationChangedEventArgs e)
    {
        IsDrawerOpen = false;

        StateHasChanged();
    }

    public async Task OnSwipEnd(SwipeEventArgs e)
    {
        if (e.SwipeDirection == SwipeDirection.RightToLeft)
        {
            IsDrawerOpen = true;
        }
        else if (e.SwipeDirection == SwipeDirection.LeftToRight)
        {
            IsDrawerOpen = false;
        }
    }
}
