using System.ComponentModel.DataAnnotations;

namespace BurgerShack.Models
{
  public class Menu
  {
    [Required]
    public string Name { get; set; }
    [Required]
    [MinLength(6)]
    public string Description { get; set; }
    [Range(5, float.MaxValue)]
    public float Price { get; set; }

    public Menu(string name, string desc, float price)
    {
      Name = name;
      Description = desc;
      Price = price;
    }
  }
}