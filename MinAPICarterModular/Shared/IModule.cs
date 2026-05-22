using Carter;
using Microsoft.Extensions.DependencyInjection;

namespace Shared;

public interface IModule : ICarterModule
{
    IServiceCollection RegisterServices(IServiceCollection services);
}
