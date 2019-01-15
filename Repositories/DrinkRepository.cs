using System;
using System.Collections.Generic;
using BurgerShack.Db;
using BurgerShack.Models;

namespace BurgerShack.Repositories
{
  public class DrinkRepository
  {
    // private readonly FakeDB;

    public IEnumerable<Drink> GetAll()
    {
      // return _db.Query<IEnumerable<Drink>>(@"
      // SELECT * FROM Drinks;
      // ");
      return FakeDB.Drinks;
    }

    public Drink GetDrinkById(int id)
    {
      try
      {
        return FakeDB.Drinks[id];
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex);
        return null;
      }
    }
    public Drink AddDrink(Drink newdrink)
    {
      FakeDB.Drinks.Add(newdrink);
      return newdrink;
    }

    public Drink EditDrink(int id, Drink newdrink)
    {
      try
      {
        FakeDB.Drinks[id] = newdrink;
        return newdrink;
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex);
        return null;
      }
    }


    public bool DeleteDrink(int id)
    {
      try
      {
        FakeDB.Drinks.Remove(FakeDB.Drinks[id]);
        return true;
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex);
        return false;
      }
    }
  }
}
