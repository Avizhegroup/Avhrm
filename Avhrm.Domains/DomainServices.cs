using Microsoft.Extensions.DependencyInjection;

namespace Avhrm.Domains;
public static class DomainServices
{
    public static void AddDomainServices(this IServiceCollection services)
    {
        services.AddAutoMapper(options =>
        {
            options.AddProfile<ApplicationProfile>();
        });
    }
}
