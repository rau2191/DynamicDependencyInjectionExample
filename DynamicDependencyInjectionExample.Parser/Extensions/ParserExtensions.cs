using DynamicDependencyInjectionExample.Parser.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace DynamicDependencyInjectionExample.Parser.Extensions;

public static class ParserExtensions
{
    public static IServiceCollection AddParsers(this IServiceCollection services)
    {
        var assembly = Assembly.GetExecutingAssembly();

        var parserImplementations = assembly.GetTypes()
            .Where(type => type.GetInterfaces()
            .Where(i => i.IsGenericType).Any(i => i.GetGenericTypeDefinition() == typeof(IParser<>)) && !type.IsAbstract && !type.IsInterface);

        foreach (var implementation in parserImplementations)
        {
            var serviceType = implementation.GetInterfaces().First(i => i.GetGenericTypeDefinition() == typeof(IParser<>));
            services.AddScoped(serviceType, implementation);
        }

        return services;
    }
}
