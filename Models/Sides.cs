using System.ComponentModel.DataAnnotations;

namespace BurgerShack.Models
{
  public class Side
  {
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
    [Required]
    public string Description { get; set; }
    [Range(5, float.MaxValue)]
    public float Price { get; set; }

  }
}