using System.Collections.Generic;
using System.Data;
using Dapper;
using BurgerShack.Models;

namespace BurgerShack.Repositories
{
  public class FaveBurgersRepository
  {
    private readonly IDbConnection _db;
    public FaveBurgersRepository(IDbConnection db)
    {
      _db = db;

    }



    //GetBurgersByCustomerId
    public IEnumerable<Burger> GetBurgersByCustomerId(int id)
    {
      return _db.Query<Burger>($@"
        SELECT * FROM faveburgers fb
        INNER JOIN burger b ON b.id = fb.burgerId
        WHERE (customerId = @id);
      ", new { id });
    }

    //GetCustomersByBurgerId
    public IEnumerable<Customer> GetCustomersByBurgerId(int id)
    {
      return _db.Query<Customer>($@"
        SELECT * FROM faveburgers fb
        INNER JOIN customer c ON c.id = fb.customerId
        WHERE (burgerId = @id);
      ", new { id });
    }


    //Addfaveburger
    // public Burger AddFaveBurger(Customer fb)
    // {
    //   int id = _db.ExecuteScalar<int>(@"
    //   INSERT INTO FaveBurger(burgerId, customerId)
    //   VALUES(@BurgerId, @CustomerId)
    //   SELECT LAST_INSERT_ID();
    //   ", fb);
    //   fb.Id = id;
    //   return fb;
    // }

    //DeleteLibraryBook

    public bool DeleteBurger(Burger fb)
    {
      int success = _db.Execute(@"DELETE FROM FaveBurger WHERE burgerId = @BurgerId AND customerId = @CustomerId", fb);
      return success != 0;

    }


  }
}