using Microsoft.EntityFrameworkCore;
using MinAPI.Database;
using MinAPI.Model;

namespace MinAPI.Endpoints;

public static class FoodsEndpoints
{
    public static void Map(WebApplication app)
    {
        var group = app.MapGroup("/foods");

        group.MapGet("/", GetAllFoodsAsync);
        group.MapGet("/{id:int}", GetFoodByIdAsync);
        group.MapPost("/", CreateFoodAsync);
        group.MapPut("/{id:int}", UpdateFoodAsync);
        group.MapDelete("/{id:int}", DeleteFoodAsync);
    }

    private static async Task<IResult> GetAllFoodsAsync(AppDbContext db)
    {
        var foods = await db.Foods.ToListAsync();
        return Results.Ok(foods);
    }

    private static async Task<IResult> GetFoodByIdAsync(AppDbContext db, int id)
    {
        var food = await db.Foods.FindAsync(id);
        if (food == null)
            return Results.NotFound();
        return Results.Ok(food);
    }

    private static async Task<IResult> CreateFoodAsync(AppDbContext db, Food food)
    {
        var id = db.Foods.Any() ? db.Foods.Max(f => f.Id) + 1 : 1;
        food.Id = id;
        db.Foods.Add(food);
        await db.SaveChangesAsync();
        return Results.Created($"/foods/{food.Id}", food);
    }

    private static async Task<IResult> UpdateFoodAsync(AppDbContext db, int id, Food updatedFood)
    {
        var food = await db.Foods.FindAsync(id);
        if (food == null)
            return Results.NotFound();

        food.Name = updatedFood.Name;
        food.Protein = updatedFood.Protein;
        food.Carbs = updatedFood.Carbs;
        food.Fat = updatedFood.Fat;
        food.Fiber = updatedFood.Fiber;
        food.Alcohol = updatedFood.Alcohol;

        await db.SaveChangesAsync();
        return Results.Ok(food);
    }

    private static async Task<IResult> DeleteFoodAsync(AppDbContext db, int id)
    {
        var food = await db.Foods.FindAsync(id);
        if (food == null)
            return Results.NotFound();

        db.Foods.Remove(food);
        await db.SaveChangesAsync();
        return Results.NoContent();
    }
}