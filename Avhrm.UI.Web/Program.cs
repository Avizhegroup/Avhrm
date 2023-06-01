using Avhrm.UI.Web;

var builder = WebApplication.CreateBuilder(args);

builder.Services.ConfigureService(builder.Configuration);

var app = builder.Build();

app.Configure();

app.Run();