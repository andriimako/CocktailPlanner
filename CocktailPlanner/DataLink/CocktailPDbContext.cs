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
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CocktailIngredient>()
            .HasKey(ci => new { ci.CocktailId, ci.IngredientId });

        modelBuilder.Entity<CocktailIngredient>()
            .HasOne(ci => ci.Cocktail)
            .WithMany(c => c.CocktailIngredients)
            .HasForeignKey(ci => ci.CocktailId);

        modelBuilder.Entity<CocktailIngredient>()
            .HasOne(ci => ci.Ingredient)
            .WithMany(i => i.CocktailIngredients)
            .HasForeignKey(ci => ci.IngredientId);

        modelBuilder.Entity<CocktailIngredient>()
            .Property(ci => ci.QuantityRequired)
            .HasDefaultValue(0);
        
        modelBuilder.Entity<EventPlanCocktail>()
            .HasKey(ci => new { ci.CocktailId, ci.EventPlanId });

        modelBuilder.Entity<EventPlanCocktail>()
            .HasOne(ci => ci.Cocktail)
            .WithMany(c => c.EventPlanCocktails)
            .HasForeignKey(ci => ci.CocktailId);

        modelBuilder.Entity<EventPlanCocktail>()
            .HasOne(ci => ci.EventPlan)
            .WithMany(i => i.EventPlanCocktails)
            .HasForeignKey(ci => ci.EventPlanId);

        modelBuilder.Entity<EventPlanCocktail>()
            .Property(ci => ci.CocktailQuantity)
            .HasDefaultValue(0);
    }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        
        optionsBuilder.UseSqlServer(_config.GetConnectionString("DefaultConnection"));
        base.OnConfiguring(optionsBuilder);
        
        
    }
    
    public DbSet<CocktailPlanner.Models.CocktailIngredient>? CocktailIngredient { get; set; }

}