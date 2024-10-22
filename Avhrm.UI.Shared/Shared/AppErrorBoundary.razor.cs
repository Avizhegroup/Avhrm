using System.Diagnostics;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.Extensions.Logging;

namespace Avhrm.UI.Shared;
public partial class AppErrorBoundary
{
    public bool ShowException = false;

    [Inject] public NavigationManager NavigationManager { get; set; }
    [Inject] public ILogger<AppErrorBoundary> Logger { get; set; }
    [Inject] public IJSRuntime JSRuntime { get; set; }

    protected override async Task OnInitializedAsync()
    {
        ShowException = true;
    }

    protected override async Task OnErrorAsync(Exception ex)
    {
#if DEBUG
         Debugger.Break();
#else
        Logger.LogWarning(ex, ex.Message);
#endif

        if (ex is CryptographicException)
        {
            await JSRuntime.InvokeVoidAsync("localStorage.clear");

            NavigationManager.NavigateTo("/account/login", true);
        }
    }

    public async Task Refresh(MouseEventArgs e)
    {
        NavigationManager.NavigateTo(NavigationManager.Uri, true);
    }

    public async Task GoHome(MouseEventArgs e)
    {
        NavigationManager.NavigateTo("/", true);
    }
}
