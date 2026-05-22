using Microsoft.Extensions.DependencyInjection;

namespace Shared;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddModule<TModule>(this IServiceCollection services) where TModule : IModule, new()
    {
        var module = new TModule();
        services.AddSingleton<IModule>(module);
        return module.RegisterServices(services);
    }
}