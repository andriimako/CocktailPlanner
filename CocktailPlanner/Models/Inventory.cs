using System.ComponentModel.DataAnnotations;

namespace CocktailPlanner.Models;

public class Inventory
{
    [Key]
    public int IdItem { get; set; }
    [Required]
    [MaxLength(255)]
    public string Name { get; set; }
    [Required]
    [MaxLength(255)]
    public string Quantity { get; set; }
    [Required]
    [MaxLength(255)]
    public string Unit { get; set; }
    public virtual ICollection<EventPlan> EventPlans { get; set; } = new List<EventPlan>();
}