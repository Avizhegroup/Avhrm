using Avhrm.Server.Intercepters;
using Avhrm.Persistence;
using Avhrm.Core;
using Avhrm.Identity.Server;
using Avhrm.Identity.Server.Implementation;
using Avhrm.Persistence.Services;

namespace Avhrm.Server;
public static class Startup
{
    // This method gets called by the runtime. Use this method to add services to the container.
    public static void ConfigureServices(this IServiceCollection services
        , IConfiguration configuration)
    {
        services.AddGrpc(options => options.Interceptors.Add<LogInterceptor>());

        services.AddCoreServices();

        services.AddPersistenceServices(configuration);

        services.AddIdentityServerServices(configuration);
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public static void Configure(this WebApplication app)
    {
#if DEBUG
        app.UseDeveloperExceptionPage();
#else
        app.UseExceptionHandler("/Home/Error");
#endif
        app.UseRouting();

        app.UseGrpcWeb(new GrpcWebOptions
        {
            DefaultEnabled = true
        });

        app.UseAuthentication();

        app.UseAuthorization();

        app.MapGrpcService<VacationRequestService>();

        app.MapGrpcService<AuthenticationService>();

        app.MapGrpcService<WorkReportService>();

        app.MapGrpcService<WorkChallengeService>();

        app.MapGrpcService<WorkTypeService>();

        app.MapGrpcService<ProjectService>();
    }
}
