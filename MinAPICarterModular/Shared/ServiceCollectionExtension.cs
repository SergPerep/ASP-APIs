using Microsoft.Extensions.DependencyInjection;
using Carter;

namespace Shared;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddModule<TModule>(this IServiceCollection services) where TModule : IModule, new()
    {
        var module = new TModule();
        module.RegisterServices(services);
        services.AddSingleton<ICarterModule>(module);
        return services;
    }
}