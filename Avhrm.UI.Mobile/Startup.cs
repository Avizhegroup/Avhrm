using Microsoft.Extensions.Logging;
using Avhrm.UI.Shared;
using Microsoft.Extensions.Configuration;

namespace Avhrm.UI.Mobile;

public static class Startup
{
    public static void ConfigureServices(this IServiceCollection services
        , IConfiguration configuration)
    {
        services.AddMauiBlazorWebView();

        services.AddBlazorWebViewDeveloperTools();

        services.AddLogging(options =>
        {
#if DEBUG
            options.AddDebug();
#endif
        });

        services.AddSharedServices(configuration);

#if ANDROID
        services.AddAndroidServices();
#elif iOS
        services.AddiOSServices();
#endif
    }
}
