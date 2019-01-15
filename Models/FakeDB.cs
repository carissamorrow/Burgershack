using System.Collections.Generic;
using BurgerShack.Models;

namespace BurgerShack.Db
{
  static class FakeDB
  {
    public static List<Burger> Burgers = new List<Burger>(){
    new Burger("Carissa Burger", "With Mac and Cheese and Bourbon bbq sauce!", 7.56f),
      new Burger("Sally Burger", "Now with fries!", 8.54f),
      new Burger("Joe", "It's all meat", 6.24f)
  };
    public static List<Drink> Drinks = new List<Drink>(){
      new Drink("Orange Soda", "Tastes like an orange", 2.20f),
      new Drink("Shandy", "21 and up Only!", 4.50f),
      new Drink("Coffee", "Perfectly Bitter", 2.50f)
  };
    public static List<Side> Sides = new List<Side>(){
     new Side("Mac and Cheese", "Creamy, topped with bacon!", 8.00f),
      new Side("Chili Fries", "Now with extra chili!", 3.50f),
      new Side("Applesauce", "Healthy but delicious", 2.75f)
  };
  }
}