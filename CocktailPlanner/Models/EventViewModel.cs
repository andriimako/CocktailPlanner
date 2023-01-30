namespace CocktailPlanner.Models;

public class EventViewModel
{
    public int IdEvent { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string Date { get; set; }
    public IEnumerable<EventPlanCocktail>? EventPlanCocktails { get; set; }
    public IEnumerable<Cocktail>? Cocktails { get; set; }
    
    public static EventViewModel FromEventPlan(EventPlan eventPlan)
    {
        return new EventViewModel
        {
            IdEvent = eventPlan.IdEvent,
            Title = eventPlan.Title,
            Description = eventPlan.Description,
            Date = eventPlan.Date,
            EventPlanCocktails = eventPlan.EventPlanCocktails,
            Cocktails = eventPlan.EventPlanCocktails.Select(epc => epc.Cocktail)
        };
    }
}