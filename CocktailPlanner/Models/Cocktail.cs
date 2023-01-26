using System.ComponentModel.DataAnnotations;

namespace CocktailPlanner.Models;

public class Cocktail
{
    [Key]
    public int IdCocktail { get; set; }
    [Required]
    [MaxLength(255)]
    public string Name { get; set; }
    [MaxLength(255)]
    public string Description { get; set; }
    public byte Image { get; set; }
    public virtual ICollection<Ingredient> Ingredients { get; set; } = new List<Ingredient>();
}