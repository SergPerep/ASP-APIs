using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Shared;

public interface IModule
{
    IServiceCollection RegisterServices(IServiceCollection services);
    WebApplication MapEndpoints(WebApplication endpoints);
}
