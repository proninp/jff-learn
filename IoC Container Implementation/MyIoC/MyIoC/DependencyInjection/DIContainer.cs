namespace MyIoC.DependencyInjection;
public class DIContainer
{
    private List<ServiceDescriptor> _serviceDescriptors;

    public DIContainer(List<ServiceDescriptor> serviceDescriptors)
    {
        _serviceDescriptors = serviceDescriptors;
    }

    public TService GetRequiredService<TService>()
    {
        return (TService)GetService(typeof(TService));
    }

    private object GetService(Type serviceType)
    {
        var descriptor = _serviceDescriptors
            .SingleOrDefault(sd => sd.ServiceType == serviceType);

        if (descriptor is null)
            throw new Exception($"Service of type {serviceType.Name} is not registered");

        if (descriptor.Implementation is not null)
            return descriptor.Implementation;

        var actualType = descriptor.ImplementationType ?? descriptor.ServiceType;

        if (actualType.IsAbstract || actualType.IsInterface)
        {
            throw new Exception("Can not instantiate abstract classes or interfaces");
        }

        var constructorInfo = actualType.GetConstructors().First();

        var parameters = constructorInfo.GetParameters()
            .Select(p => GetService(p.ParameterType))
            .ToArray();

        var implementation = Activator.CreateInstance(actualType, parameters)!;

        if (descriptor.Lifetime == ServiceLifetime.Singleton)
            descriptor.Implementation = implementation;

        return implementation;
    }
}