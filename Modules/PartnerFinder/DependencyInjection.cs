using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

using Microsoft.Extensions.Configuration;
namespace PartnerFinder;

public static class DependencyInjection
{



    public static IServiceCollection AddPartnerFinderModule(this IServiceCollection services, IConfiguration configuration)
    {
        return services;
    }
    
    
    public static  WebApplication UsePartnerFinderModule(this WebApplication app)
    {

        return app;
    }
}