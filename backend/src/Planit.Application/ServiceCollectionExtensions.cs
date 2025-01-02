using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using Planit.Application.Abstractions.Cqrs;
using Planit.Application.Behaviors;

namespace Planit.Application;
public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssembly(typeof(ServiceCollectionExtensions).Assembly);
            cfg.AddOpenBehavior(typeof(LoggingBehavior<,>));
            cfg.AddOpenBehavior(typeof(ValidationBehavior<,>));
            cfg.AddOpenBehavior(typeof(ExceptionsBehavior<,>));
        });

        services.AddScoped<IRequestDispatcher, RequestDispatcher>();
        services.AddValidatorsFromAssembly(typeof(ServiceCollectionExtensions).Assembly);

        return services;
    }
}
