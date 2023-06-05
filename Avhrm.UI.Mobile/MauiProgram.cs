using Avhrm.UI.Shared;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.FileProviders;
using System.Reflection;

namespace Avhrm.UI.Mobile;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        var assembly = typeof(MainLayout).GetTypeInfo().Assembly;

        builder
            .UseMauiApp<App>()
            .Configuration.AddJsonFile(new EmbeddedFileProvider(assembly), "appsettings.json", optional: false, false);

        builder.Services.ConfigureServices(builder.Configuration);

        return builder.Build();
    }
}