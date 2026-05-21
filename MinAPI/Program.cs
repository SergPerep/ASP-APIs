
using Microsoft.EntityFrameworkCore;
using MinAPI.Database;
using MinAPI.Model;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseInMemoryDatabase("MyDatabaseName"));

var app = builder.Build();

// Populate database
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "Database", "foods-data-set.json");
    if (!File.Exists(filePath))
        throw new Exception($"File not found: {filePath}");
    var text = File.ReadAllText(filePath);
    var foods = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Food>>(text);
    if (foods != null)
        db.Foods.AddRange(foods);
    db.SaveChanges();
}

app.MapGet("/", () => "Hello World!");

app.Run();
