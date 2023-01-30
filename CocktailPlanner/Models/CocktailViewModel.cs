namespace CocktailPlanner.Models;

public class CocktailViewModel
{
    
    public int IdCocktail { get; set; }
    
    public string Name { get; set; }
    
    public string Description { get; set; }
    public string Image { get; set; }
    public IEnumerable<CocktailIngredient>? CocktailIngredients { get; set; } 
    public IEnumerable<Ingredient> Ingredients { get; set; } 
    public ICollection<EventPlanCocktail>? EventPlanCocktails { get; set; }
    
    public static CocktailViewModel FromCocktail(Cocktail cocktail)
    {
        return new CocktailViewModel
        {
            IdCocktail = cocktail.IdCocktail,
            Name = cocktail.Name,
            Description = cocktail.Description,
            Image = cocktail.Image,
            CocktailIngredients = cocktail.CocktailIngredients,
            Ingredients = cocktail.CocktailIngredients.Select(ci => ci.Ingredient)
        };
    }
}