using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Avhrm.Application.Client;
public static class ApplicationServices
{
    public static void AddClientApplicationServices(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
    }
}
