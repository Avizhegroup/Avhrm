using Microsoft.Extensions.DependencyInjection;

namespace Avhrm.Core;
public static class CoreServices
{
    public static void AddCoreServices(this IServiceCollection services)
    {
        services.AddAutoMapper(options =>
        {
            options.AddProfile<ApplicationProfile>();
        });
    }
}
