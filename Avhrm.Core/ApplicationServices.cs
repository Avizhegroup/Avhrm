using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Avhrm.Application.Server;;
public static class ApplicationServices
{
    public static void AddApplicationServices(this IServiceCollection services)
    {
        services.AddAutoMapper(options =>
        {
            options.AddProfile<ApplicationProfile>();
        });

        services.AddMediatR(options =>
        {
            options.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
        });
    }
}
