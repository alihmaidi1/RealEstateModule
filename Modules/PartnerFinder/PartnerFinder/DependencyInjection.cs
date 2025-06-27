using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace PartnerFinder;

public static class DependencyInjection
{
    public static IServiceCollection AddPartnerFinderModule(this IServiceCollection services,IConfiguration configuration)
    {

        return services;
    }


    public static IApplicationBuilder UsePartnerFinderModule(this IApplicationBuilder app)
    {

        return app;
    }

    
}