using System.Reflection;
using FluentValidation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RealEstate.Shared.CQRS;
using RealEstate.Shared.Decorator;
using RealEstate.Shared.Middleware;

namespace RealEstate.Shared;

public static class DependencyInjection
{


    public static IServiceCollection AddShared(this IServiceCollection services, IConfiguration configuration,params Assembly[] assemblies)
    {
        services.AddScoped<IDomainEventDispatcher, DomainEventDispatcher>();
        services.AddScoped<GlobalExceptionHandlingMiddleware>();
        services.Scan(scan =>
            scan.FromAssemblies(assemblies)
                .AddClasses(classes => classes.AssignableTo(typeof(IRequestHandler<>)), publicOnly: false)
                .AsImplementedInterfaces()
                .WithScopedLifetime()
                .AddClasses(classes => classes.AssignableTo(typeof(IDomainEventHandler<>)), publicOnly: false)
                .AsImplementedInterfaces()
                .WithScopedLifetime()

        );
        
        services.AddValidatorsFromAssemblies(assemblies);
        services.TryDecorate(typeof(ICommandHandler<>), typeof(ValidationDecorator.CommandHandler<>));
        services.TryDecorate(typeof(IQueryHandler<>), typeof(ValidationDecorator.QueryHandler<>));
        services.TryDecorate(typeof(ICommandHandler<>), typeof(LoggingDecorator.CommandHandler<>));
        services.TryDecorate(typeof(IQueryHandler<>), typeof(LoggingDecorator.QueryHandler<>));

        return services;
    }

}