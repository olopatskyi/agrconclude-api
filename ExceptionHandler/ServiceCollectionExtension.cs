using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace ExceptionHandler;

public static class ServiceCollectionExtension
{
    public static void AddExceptionHandlers(this IServiceCollection services, params Assembly[] markAssemblies)
    {
        var constructedServices = ConstructServices(markAssemblies);
        services.Add(constructedServices);
    }

    private static IEnumerable<Type> GetClassesImplementingInterface(Type interfaceType, params Assembly[] assemblies)
    {
        var result = new List<Type>();

        foreach (var assembly in assemblies)
        {
            var types = assembly.GetTypes()
                .Where(t => t.IsClass && !t.IsAbstract);

            foreach (var type in types)
            {
                if (type.GetInterfaces().Any(i =>
                        i.IsGenericType &&
                        i.GetGenericTypeDefinition() == interfaceType &&
                        i.GetGenericArguments().Length == 1 &&
                        (i.GetGenericArguments()[0].IsSubclassOf(typeof(Exception)) ||
                         i.GetGenericArguments()[0] == typeof(Exception))))
                {
                    result.Add(type);
                }
            }
        }

        return result;
    }

    private static Dictionary<Type, Type> GetCollectionOfDependencies(Assembly[] assemblies)
    {
        var interfaceType = typeof(IExceptionHandler<>);
        var implementingClasses = GetClassesImplementingInterface(interfaceType, assemblies);

        var dict = new Dictionary<Type, Type>();
        foreach (var implementingClass in implementingClasses)
        {
            var genericTypeArguments = implementingClass.GetInterfaces()
                .Where(i => i.IsGenericType && i.GetGenericTypeDefinition() == interfaceType)
                .Select(i => i.GetGenericArguments())
                .FirstOrDefault();

            if (genericTypeArguments != null && genericTypeArguments.Length == 1)
            {
                var key = interfaceType.MakeGenericType(genericTypeArguments);
                dict[key] = implementingClass;
            }
        }

        return dict;
    }

    private static IEnumerable<ServiceDescriptor> ConstructServices(Assembly[] assemblies)
    {
        var dependenciesMap = GetCollectionOfDependencies(assemblies);
        return dependenciesMap
            .Select(x => new ServiceDescriptor(x.Key, x.Value, ServiceLifetime.Singleton));
    }
}