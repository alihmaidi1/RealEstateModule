using System.Reflection;
using FluentValidation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RealEstate.Shared.CQRS;
using RealEstate.Shared.Decorator;

namespace RealEstate.Shared;

public static class DependencyInjection
{


    public static IServiceCollection AddShared(this IServiceCollection services, IConfiguration configuration,params Assembly[] assemblies)
    {
        services.AddScoped<IDomainEventDispatcher, DomainEventDispatcher>();
        services.Scan(scan =>
            scan.FromAssemblies(assemblies)
                .AddClasses(classes => classes.AssignableTo(typeof(ICommandHandler<>)), publicOnly: false)
                .AsImplementedInterfaces()
                .WithScopedLifetime()
                .AddClasses(classes => classes.AssignableTo(typeof(IQueryHandler<>)), publicOnly: false)
                .AsImplementedInterfaces()
                .WithScopedLifetime()
                .AddClasses(classes => classes.AssignableTo(typeof(IDomainEventHandler<>)), publicOnly: false)
                .AsImplementedInterfaces()
                .WithScopedLifetime()

        );
        
        services.AddValidatorsFromAssemblies(assemblies);
        services.TryDecorate(typeof(ICommandHandler<>), typeof(ValidationDecorator.CommandHandler<>));
        services.TryDecorate(typeof(IQueryHandler<>), typeof(ValidationDecorator.QueryHandler<>));
        // services.TryDecorate(typeof(ICommandHandler<>), typeof(ValidationDecorator.CommandHandler<>));

        return services;
    }

}