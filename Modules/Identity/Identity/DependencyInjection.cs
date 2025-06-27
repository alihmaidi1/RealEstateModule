using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Identity;

public static class DependencyInjection
{


    public static IServiceCollection AddIdentityModule(this IServiceCollection services,IConfiguration configuration)
    {

        return services;
    }


    public static IApplicationBuilder UseIdentityModule(this IApplicationBuilder app)
    {

        return app;
    }

}