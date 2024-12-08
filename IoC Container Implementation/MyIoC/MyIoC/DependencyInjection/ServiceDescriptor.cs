﻿namespace MyIoC.DependencyInjection;
public class ServiceDescriptor
{
    public Type ServiceType { get; }

    public Type ImplementationType { get; }

    public object? Implementation { get; internal set; }

    public ServiceLifetime Lifetime { get; }

    public ServiceDescriptor(object implementation, ServiceLifetime lifetime)
    {
        ServiceType = implementation.GetType();
        ImplementationType = ServiceType;
        Implementation = implementation;
        Lifetime = lifetime;
    }

    public ServiceDescriptor(Type serviceType, ServiceLifetime lifetime)
    {
        ServiceType = serviceType;
        ImplementationType = serviceType;
        Lifetime = lifetime;
    }

    public ServiceDescriptor(Type serviceType, Type implementationType, ServiceLifetime lifetime)
    {
        ServiceType = serviceType;
        ImplementationType = implementationType;
        Lifetime = lifetime;
    }
}