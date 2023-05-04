using Avhrm.Core.Contracts;
using Avhrm.Mobile.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Avhrm.Mobile;

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

        services.AddGrpcService<IVacationRequest>();
    }
}
