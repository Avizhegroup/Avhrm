using Avhrm.Identity.Server;
using Avhrm.Persistence;
using Microsoft.AspNetCore.ResponseCompression;
using System.IO.Compression;

namespace Avhrm.Api;
public static partial class Program
{
    public static void ConfigureServices(this IServiceCollection services
       , IConfiguration configuration)
    {
        services.AddControllers();

        services.AddCors(options =>
        {
            options.AddPolicy("OpenCors", builder =>
            {
                builder
                    .AllowAnyOrigin()
                    .AllowAnyHeader()
                    .AllowAnyMethod();
            });
        });

        services.AddResponseCompression(opts =>
        {
            opts.EnableForHttps = true;
            opts.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat(new[] { "application/octet-stream" }).ToArray();
            opts.Providers.Add<BrotliCompressionProvider>();
            opts.Providers.Add<GzipCompressionProvider>();
        })
            .Configure<BrotliCompressionProviderOptions>(opt => opt.Level = CompressionLevel.Fastest)
            .Configure<GzipCompressionProviderOptions>(opt => opt.Level = CompressionLevel.Fastest);

        services.AddSwaggerGen();

        services.AddHttpContextAccessor();

        services.AddApplicationServices();

        services.AddPersistenceServices(configuration);

        services.AddIdentityServerServices(configuration);
    }
}
