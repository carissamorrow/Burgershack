using System;
using System.Collections.Generic;
using System.Data;
// using BurgerShack.Db;
using BurgerShack.Models;
using Dapper;

namespace BurgerShack.Repositories
{
  public class DrinkRepository
  {
    private readonly IDbConnection _db;

    public DrinkRepository(IDbConnection db)
    {
      _db = db;
    }

    public IEnumerable<Drink> GetAll()
    {
      return _db.Query<Drink>("SELECT * FROM burgershack");
    }
    public Drink GetDrinkById(int id)
    {
      try
      {
        //this way sanitizes so someone can't drop table
        return _db.QueryFirstOrDefault<Drink>($"SELECT * FROM Drinks WHERE id = @id", new { id });
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex);
        return null;
      }
    }
    public Drink AddDrink(Drink newdrink)
    {
      int id = _db.ExecuteScalar<int>(@"
      SELECT LAST_INSERT_ID()", new
      {
        newdrink.Name,
        newdrink.Description,
        newdrink.Price
      });
      newdrink.Id = id;
      return newdrink;
    }

    public Drink EditDrink(int id, Drink newdrink)
    {
      try
      {
        return _db.QueryFirstOrDefault<Drink>($@"
       UPDATE Drinks SET
       Name = @Name,
       Price = @Price,
       Description = @Description
       WHERE Id = @Id;
       SELECT * FROM Drinks WHERE id = @Id;
       ", newdrink);
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex);
        return null;
      }
    }


    // public bool DeleteDrink(int id)
    // {
    //   try
    //   {

    //   }
    //   catch (Exception ex)
    //   {
    //     Console.WriteLine(ex);
    //     return false;
    //   }
    // }
  }
}
