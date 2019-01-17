using System.ComponentModel.DataAnnotations;

namespace BurgerShack.Models
{
  public class Customer
  {
    [Required]
    public string Name { get; set; }
    public int Id { get; set; }

    // public string Favorites { get; set; }

  }
}