using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Property;

public static class DependencyInjection
{
    
    public static IServiceCollection AddPropertyModule(this IServiceCollection services,IConfiguration configuration)
    {

        return services;
    }


    public static IApplicationBuilder UsePropertyModule(this IApplicationBuilder app)
    {

        return app;
    }


}