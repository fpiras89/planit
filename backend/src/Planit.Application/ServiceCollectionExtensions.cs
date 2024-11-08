using Microsoft.Extensions.DependencyInjection;
using Planit.Application.Abstractions.Cqrs;

namespace Planit.Application;
public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(ServiceCollectionExtensions).Assembly));
        services.AddScoped<IRequestDispatcher, RequestDispatcher>();

        return services;
    }
}
