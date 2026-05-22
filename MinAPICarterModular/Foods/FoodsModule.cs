namespace Foods;

using System.Text.Json;
using Carter;
using Foods.Database;
using Foods.Endpoints;
using Foods.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Shared;

public class FoodsModule : ICarterModule, IModule
{
    public IServiceCollection RegisterServices(IServiceCollection services)
    {
        services.AddSingleton<FoodsModule>();
        services.AddDbContext<AppDbContext>(options =>
            options.UseInMemoryDatabase("FoodsDatabase"));
        return services;
    }

    public void AddRoutes(IEndpointRouteBuilder app)
    {
        // Populate database
        using var scope = app.ServiceProvider.CreateScope();
        var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
        using var stream = typeof(FoodsModule).Assembly.GetManifestResourceStream("Foods.Database.foods-data-set.json");
        using var reader = new StreamReader(stream);
        var text = reader.ReadToEnd();
        var foods = JsonSerializer.Deserialize<List<Food>>(text, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        if (foods != null)
            db.Foods.AddRange(foods);
        db.SaveChanges();

        // Group on module level
        var moduleLevelGroup = app.MapGroup("/foodsmodule");
        moduleLevelGroup.MapGet("/", () => "Welcome to the Foods Module!");

        FoodsEndpoints.Map(moduleLevelGroup);
    }
}

