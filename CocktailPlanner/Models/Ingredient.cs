using System.ComponentModel.DataAnnotations;

namespace CocktailPlanner.Models;

public class Ingredient
{
    [Key]
    public int IdIngredient { get; set; }
    [Required]
    [MaxLength(255)]
    public string Name { get; set; }
    [Required]
    [MaxLength(255)]
    public double Quantity { get; set; }
    [Required]
    [MaxLength(255)]
    public string Unit { get; set; }
    public virtual ICollection<Cocktail> Cocktails { get; set; } = new List<Cocktail>();
}