using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Shared;

public static class WebApplicationExtension
{
    public static WebApplication MapModules(this WebApplication app)
    {
        var modules = app.Services.GetServices<IModule>();
        foreach (var module in modules)
        {
            module.MapEndpoints(app);
        }
        return app;
    }
}