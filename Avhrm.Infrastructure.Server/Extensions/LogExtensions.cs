using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Serilog;

namespace Avhrm.Infrastructure.Server;
public static class LogExtensions
{
    public static void AddSerilog(this IServiceCollection services
        , IConfiguration appConfig)
    {
        services.AddLogging(config =>
        {
            var customLogger = new LoggerConfiguration()
                .Enrich.FromLogContext().MinimumLevel.Information();

            customLogger.WriteTo.Debug();

#if DEBUG
            customLogger.WriteTo.Console();
#else
            if (appConfig["Seq:Url"].HasValue())
            {
                customLogger
                .WriteTo.Seq(appConfig["Seq:Url"].ToString());
            }
#endif
            Log.Logger =
                   customLogger.CreateLogger();

            config.AddSerilog(logger: Log.Logger, dispose: true);
        });
    }
}
