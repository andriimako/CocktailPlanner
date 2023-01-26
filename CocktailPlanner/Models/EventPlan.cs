using System.ComponentModel.DataAnnotations;

namespace CocktailPlanner.Models;

public class EventPlan
{
    [Key]
    public int IdEvent { get; set; }
    [Required]
    [MaxLength(255)]
    public string Title { get; set; }
    [MaxLength(255)]
    public string Description { get; set; }
    [MaxLength(255)]
    public string Date { get; set; }
    public virtual ICollection<Cocktail> Cocktails { get; set; } = new List<Cocktail>();
    public virtual ICollection<Inventory> Inventories { get; set; } = new List<Inventory>();
}