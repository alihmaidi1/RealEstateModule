using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Property;

public static class DependencyInjection
{
    
    
    public static IServiceCollection AddPropertyModule(this IServiceCollection services, IConfiguration configuration)
    {
        return services;
    }
    
    
    public static WebApplication UsePropertyModule(this WebApplication app)
    {

        return app;
    }
}