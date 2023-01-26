using CocktailPlanner.Models;
using Microsoft.EntityFrameworkCore;

namespace CocktailPlanner.DataLink;

public class CocktailPDbContext : DbContext
{
    private readonly IConfiguration _config;
    public CocktailPDbContext(IConfiguration config)
    {
        _config = config;
    }
    public DbSet<Cocktail> Cocktails { get; set; }
    public DbSet<Ingredient> Ingredients { get; set; }
    public DbSet<EventPlan> EventPlans { get; set; }
    public DbSet<Inventory> Inventories { get; set; }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        
        optionsBuilder.UseSqlServer(_config.GetConnectionString("DefaultConnection"));
        base.OnConfiguring(optionsBuilder);
    }

}