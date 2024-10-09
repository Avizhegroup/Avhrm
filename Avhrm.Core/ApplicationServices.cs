using Microsoft.Extensions.DependencyInjection;

namespace Avhrm.Application;
public static class CoreServices
{
    public static void AddApplicationServices(this IServiceCollection services)
    {
        services.AddAutoMapper(options =>
        {
            options.AddProfile<ApplicationProfile>();
        });
    }
}
