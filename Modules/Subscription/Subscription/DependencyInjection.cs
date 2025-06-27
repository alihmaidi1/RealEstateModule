using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RealEstate.Shared.Data;
using RealEstate.Shared.Data.Interceptors;
using RealEstate.Shared.Data.Seed;
using Subscription.Data;
using Subscription.Data.Seed;

namespace Subscription;

public static class DependencyInjection
{
    
    
    public static IServiceCollection AddSubscriptionModule(this IServiceCollection services,IConfiguration configuration)
    {

        var connectionString = configuration.GetConnectionString("DefaultConnection");
        services.AddScoped<ISaveChangesInterceptor, AuditableEntityInterceptor>();
        services.AddScoped<ISaveChangesInterceptor, DispatchDomainEventsInterceptor>();
        services.AddScoped<IDataSeeder, SubscriptionSeeder>();
        
        services.AddDbContext<SubscriptionDbContext>((sp, options) =>
        {
            options.AddInterceptors(sp.GetServices<ISaveChangesInterceptor>());
            options.UseSqlServer(connectionString);
            
        });

        return services;
    }


    public static IApplicationBuilder UseSubscriptionModule(this IApplicationBuilder app)
    {

        app.UseMigration<SubscriptionDbContext>();
        
        return app;
    }
    
}