using System.Text.Json;
using Foods.Database;
using Foods.Endpoints;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Shared;
using Foods.Models;

namespace Foods;

public class FoodsModule : IModule
{
    public IServiceCollection RegisterServices(IServiceCollection services)
    {
        services.AddDbContext<AppDbContext>(options =>
            options.UseInMemoryDatabase("FoodsDatabase"));

        return services;
    }
    public WebApplication MapEndpoints(WebApplication app)
    {
        // Populate database
        using var scope = app.Services.CreateScope();
        var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
        using var stream = typeof(FoodsModule).Assembly.GetManifestResourceStream("Foods.Database.foods-data-set.json");
        using var reader = new StreamReader(stream);
        var text = reader.ReadToEnd();
        //var filePath = Path.Combine(app.Environment.ContentRootPath, "Database", "foods-data-set.json");    
        // if (!File.Exists(filePath))
        //     throw new Exception($"File not found: {filePath}");
        // var text = File.ReadAllText(filePath);
        var foods = JsonSerializer.Deserialize<List<Food>>(text, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        if (foods != null)
            db.Foods.AddRange(foods);
        db.SaveChanges();

        // Group on module level
        var moduleLevelGroup = app.MapGroup("/foodsmodule");
        moduleLevelGroup.MapGet("/", () => "Welcome to the Foods Module!");

        FoodsEndpoints.Map(moduleLevelGroup);
        return app;
    }

}
