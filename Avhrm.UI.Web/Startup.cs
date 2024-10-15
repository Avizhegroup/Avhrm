using Microsoft.AspNetCore.ResponseCompression;
using System.IO.Compression;
using Avhrm.UI.Shared;

namespace Avhrm.UI.Web;

public static class Startup
{
    public static void ConfigureService(this IServiceCollection services
        , ConfigurationManager configuration)
    {
        services.AddRazorPages();

#if DEBUG
        services.AddServerSideBlazor()
                .AddCircuitOptions(options =>
                {
                    options.DetailedErrors = true;
                });
#else
        services.AddServerSideBlazor();
#endif

        services.AddResponseCompression(opts =>
        {
            opts.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat(new[] { "application/octet-stream" });

            opts.Providers.Add<BrotliCompressionProvider>();

            opts.Providers.Add<GzipCompressionProvider>();
        })
            .Configure<BrotliCompressionProviderOptions>(opt => opt.Level = CompressionLevel.Fastest)
            .Configure<GzipCompressionProviderOptions>(opt => opt.Level = CompressionLevel.Fastest);

        services.AddSharedServices(configuration);
    }

    public static void Configure(this WebApplication app)
    {
#if DEBUG
        app.UseDeveloperExceptionPage();
#else
        app.UseExceptionHandler("/Home/Error");
#endif
        app.UseStaticFiles();

        app.UseRouting();

        app.UseResponseCompression();

        app.MapBlazorHub();

        app.MapFallbackToPage("/_Host");
    }
}
