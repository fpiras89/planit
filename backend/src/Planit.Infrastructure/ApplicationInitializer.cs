using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Planit.Application.Interfaces;

namespace Planit.Infrastructure;

public class ApplicationInitializer : IHostedService
{
    private readonly IServiceProvider serviceProvider;
    private readonly ILogger<ApplicationInitializer> logger;

    public ApplicationInitializer(IServiceProvider serviceProvider, ILogger<ApplicationInitializer> logger)
    {
        this.serviceProvider = serviceProvider;
        this.logger = logger;
    }

    public async Task StartAsync(CancellationToken cancellationToken)
    {
        logger.LogInformation("Application initialization started");

        using var scope = serviceProvider.CreateScope();
        
        var applicationInitializers = scope.ServiceProvider
            .GetServices<IApplicationInitializer>();

        foreach(var initializer in applicationInitializers)
        {
            await initializer.ExecuteAsync();
        }

        logger.LogInformation("Application initialization completed");
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }
}
