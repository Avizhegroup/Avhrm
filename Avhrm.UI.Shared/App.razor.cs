using Microsoft.AspNetCore.Components.Routing;

namespace Avhrm.UI.Shared;

public partial class App
{
    [AutoInject] private IJSRuntime _jsRuntime = default!;

    private async Task OnNavigateAsync(NavigationContext args)
    {

    }
}
