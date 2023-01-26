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
    public double QuantityAvailable { get; set; }
    [Required]
    [MaxLength(255)]
    public string Unit { get; set; }
    [Required]
    public Boolean IsAlcoholic { get; set; }
    public ICollection<CocktailIngredient> CocktailIngredients { get; set; }
        
}