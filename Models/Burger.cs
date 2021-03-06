using System.ComponentModel.DataAnnotations;

namespace BurgerShack.Models
{
  public class Burger
  {
    [Required]
    public int Id { get; set; }
    public string Name { get; set; }
    [Required]
    [MinLength(6)]
    public string Description { get; set; }
    [Range(5, float.MaxValue)]
    public float Price { get; set; }


  }
}