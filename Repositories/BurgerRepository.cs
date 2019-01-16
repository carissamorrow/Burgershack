using System;
using System.Collections.Generic;
using System.Data;
// using BurgerShack.Db;
using BurgerShack.Models;
using Dapper;

namespace BurgerShack.Repositories
{
  public class BurgerRepository
  {
    private readonly IDbConnection _db;

    public BurgerRepository(IDbConnection db)
    {
      _db = db;
    }

    public IEnumerable<Burger> GetAll()
    {
      return _db.Query<Burger>("SELECT * FROM Burgers");
    }
    public Burger GetBurgerById(int id)
    {
      try
      {
        //this way sanitizes so someone can't drop table
        return _db.QueryFirstOrDefault<Burger>($"SELECT * FROM Burgers WHERE id = @id", new { id });
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex);
        return null;
      }
    }
    public Burger AddBurger(Burger newburger)
    {
      int id = _db.ExecuteScalar<int>(@"
      INSERT INTO Burgers (Name, Description, Price) Values (@Name, @Description,@Price);
 	     SELECT LAST_INSERT_ID();", new
      {
        newburger.Name,
        newburger.Description,
        newburger.Price
      });
      newburger.Id = id;
      return newburger;

    }

    public Burger EditBurger(int id, Burger newburger)
    {
      try
      {
        return _db.QueryFirstOrDefault<Burger>($@"
       UPDATE Burgers SET
       Name = @Name,
       Price = @Price,
       Description = @Description
       WHERE Id = @Id;
       SELECT * FROM Burgers WHERE id = @Id;
       ", newburger);
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex);
        return null;
      }
    }


    public bool DeleteBurger(int id)
    {
      int delete = _db.Execute("DELETE FROM Burgers WHERE ID = @Id", new { Id = id });
      return true;

    }
  }
}
