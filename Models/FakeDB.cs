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
  }
}