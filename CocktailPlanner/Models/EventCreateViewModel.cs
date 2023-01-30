namespace CocktailPlanner.Models;

public class EventCreateViewModel
{
    public int IdEventPlan { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string Date { get; set; }
    public List<int>? SelectedCocktailIds { get; set; }
    public List<Cocktail>? Cocktails { get; set; }
    public List<int>? CocktailQuantity { get; set; }

}