namespace CocktailPlanner.Models;

public class CocktailCreateViewModel
{
    public int IdCocktail { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Image { get; set; }
    public List<int>? SelectedIngredientIds { get; set; }

    public List<Ingredient>? Ingredients { get; set; }
    public List<string>? QuantityRequired { get; set; }
}
