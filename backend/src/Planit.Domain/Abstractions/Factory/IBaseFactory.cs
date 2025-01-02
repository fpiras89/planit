namespace Planit.Domain.Abstractions.Factory;

public interface IBaseFactory<T> 
    where T : class, INamedService
{
    T Create(string name);
}