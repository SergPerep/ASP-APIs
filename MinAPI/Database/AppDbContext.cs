using Microsoft.EntityFrameworkCore;
using MinAPI.Model;

namespace MinAPI.Database;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Food> Foods { get; set; }
}