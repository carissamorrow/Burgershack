using System.Collections.Generic;
using BurgerShack.Models;

namespace BurgerShack.Db
{
  static class FakeDB
  {
    public static List<Menu> Menues = new List<Menu>(){
      new Menu("Mac and cheese", "best ever", 10),
      new Menu("Coca Cola","Delicious", 3),
      new Menu("Fries", "With every main dish", 10)
  };
  }
}