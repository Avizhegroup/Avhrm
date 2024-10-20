using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

#if BlazorServer
using Serilog;
#endif

namespace Avhrm.Infrastructure.Client;
public static class LogExtensions
{
    public static void AddSerilog(this IServiceCollection services
        , IConfiguration appConfig)
    {
#if BlazorServer
        services.AddLogging(config =>
        {
            var customLogger = new LoggerConfiguration()
                .Enrich.FromLogContext().MinimumLevel.Information();

            customLogger.WriteTo.Debug();

#if DEBUG
            customLogger.WriteTo.Console();

#else
            customLogger
                .WriteTo.Seq("http://localhost:5341");
#endif
            Log.Logger =
                   customLogger.CreateLogger();

            config.AddSerilog(logger: Log.Logger, dispose: true);
        });
    }
#endif
}
