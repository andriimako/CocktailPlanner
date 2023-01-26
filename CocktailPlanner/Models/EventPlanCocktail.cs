namespace CocktailPlanner.Models;

public class EventPlanCocktail
{
    public int CocktailId { get; set; }
    public Cocktail Cocktail { get; set; }
    
    public int EventPlanId { get; set; }
    public EventPlan EventPlan { get; set; }
    
    public int CocktailQuantity { get; set; }
}