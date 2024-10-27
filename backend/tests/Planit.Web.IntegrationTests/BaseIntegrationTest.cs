using Microsoft.Extensions.DependencyInjection;

namespace Planit.Web.IntegrationTests;

[Collection("Integration Tests")]
public class BaseIntegrationTest : IDisposable, IAsyncLifetime
{
    protected CustomWebApplicationFactory Factory { get; private set; }
    protected IServiceScope Scope { get; private set; }

    public BaseIntegrationTest(CustomWebApplicationFactory factory)
    {
        Factory = factory;
        Scope = factory.Server.Services.CreateScope();
    }

    public virtual void Dispose()
    {
        Scope.Dispose();
        Console.WriteLine("Dispose");
    }

    public virtual Task InitializeAsync()
    {
        return Task.CompletedTask;
    }

    public virtual Task DisposeAsync()
    {
        return Task.CompletedTask;
    }
}