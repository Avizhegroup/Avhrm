using Avhrm.UI.Web;
using Microsoft.Extensions.FileProviders;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

var assembly = typeof(MainLayout).GetTypeInfo().Assembly;

builder
    .Configuration.AddJsonFile(new EmbeddedFileProvider(assembly), "appsettings.json", optional: false, false);

builder.Services.ConfigureService(builder.Configuration);

var app = builder.Build();

app.Configure();

app.Run();