namespace Planit.Domain.Abstractions.Factory;

public class BaseFactory<T> : IBaseFactory<T>
    where T : class, INamedService
{
    protected readonly Dictionary<string, T> services;

    protected BaseFactory(IEnumerable<T> services)
    {
        this.services = services.ToDictionary(s => s.Name, s => s);
    }   

    public T Create(string name)
    {
        return services[name];
    }
}