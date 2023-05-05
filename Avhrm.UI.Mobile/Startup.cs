using Microsoft.Extensions.Logging;
using Avhrm.UI.Shared;

namespace Avhrm.UI.Mobile;

public static class Startup
{
    public static void ConfigureServices(this IServiceCollection services)
    {
        services.AddMauiBlazorWebView();

        services.AddBlazorWebViewDeveloperTools();

        services.AddLogging(options =>
        {
#if DEBUG
            options.AddDebug();
#endif
        });

        services.AddSharedServices();
    }
}
