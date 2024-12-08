namespace MyIoC.DependencyInjection;

public class DIServiceCollection
{
    private readonly List<ServiceDescriptor> _serviceDescriptors = new();

    public DIContainer BuildContainer()
    {
        return new DIContainer(_serviceDescriptors);
    }

    public void RegisterSingleton<TService>(TService implementation) =>
        Register(new ServiceDescriptor(implementation, ServiceLifetime.Singleton));

    public void RegisterSingleton<TService>() =>
        Register(new ServiceDescriptor(typeof(TService), ServiceLifetime.Singleton));

    public void RegisterSingleton<TService, TImplementation>() where TImplementation : TService =>
        Register(new ServiceDescriptor(typeof(TService), typeof(TImplementation), ServiceLifetime.Singleton));

    public void RegisterTransient<TService>() =>
        Register(new ServiceDescriptor(typeof(TService), ServiceLifetime.Transient));

    public void RegisterTransient<TService, TImplementation>() where TImplementation : TService =>
        Register(new ServiceDescriptor(typeof(TService), typeof(TImplementation), ServiceLifetime.Transient));

    private void Register(ServiceDescriptor serviceDescriptor)
    {
        _serviceDescriptors.Add(serviceDescriptor);
    }
}
