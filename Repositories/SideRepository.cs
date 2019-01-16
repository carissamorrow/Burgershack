using System;
using System.Collections.Generic;
using System.Data;
// using BurgerShack.Db;
using BurgerShack.Models;
using Dapper;

namespace BurgerShack.Repositories
{
  public class SideRepository
  {
    private readonly IDbConnection _db;

    public SideRepository(IDbConnection db)
    {
      _db = db;
    }

    public IEnumerable<Side> GetAll()
    {
      return _db.Query<Side>("SELECT * FROM Sides");
    }
    public Side GetSideById(int id)
    {
      try
      {
        //this way sanitizes so someone can't drop table
        return _db.QueryFirstOrDefault<Side>($"SELECT * FROM Sides WHERE id = @id", new { id });
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex);
        return null;
      }
    }
    public Side AddSide(Side newside)
    {
      int id = _db.ExecuteScalar<int>(@"
      INSERT INTO Sides (Name, Description, Price) Values (@Name, @Description,@Price);
 	SELECT LAST_INSERT_ID()", new
      {
        newside.Name,
        newside.Description,
        newside.Price
      });
      newside.Id = id;
      return newside;

    }

    public Side EditSide(int id, Side newside)
    {
      try
      {
        return _db.QueryFirstOrDefault<Side>($@"
       UPDATE Sides SET
       Name = @Name,
       Price = @Price,
       Description = @Description
       WHERE Id = @Id;
       SELECT * FROM Sides WHERE id = @Id;
       ", newside);
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex);
        return null;
      }
    }


    public bool DeleteSide(int id)
    {
      int delete = _db.Execute("DELETE FROM SIDES WHERE ID = @Id", new { Id = id });
      return true;

    }
  }
}
