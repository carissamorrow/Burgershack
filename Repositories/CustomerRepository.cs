using System;
using System.Collections.Generic;
using System.Data;
using BurgerShack.Models;
using Dapper;

namespace BurgerShack.Repositories
{
  public class CustomerRepository
  {
    private readonly IDbConnection _db;

    public CustomerRepository(IDbConnection db)
    {
      _db = db;
    }

    public IEnumerable<Customer> GetAll()
    {
      return _db.Query<Customer>("SELECT * FROM Customers");
    }
    public Customer GetCustomerById(int id)
    {
      try
      {
        //this way sanitizes so someone can't drop table
        return _db.QueryFirstOrDefault<Customer>($"SELECT * FROM Customers WHERE id = @id", new { id });
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex);
        return null;
      }
    }
    public Customer AddCustomer(Customer newcustomer)
    {
      int id = _db.ExecuteScalar<int>(@"
      INSERT INTO Customers (Name, Favorites) Values (@Name, @Favorites);
      SELECT LAST_INSERT_ID()", new
      {
        newcustomer.Name,
        // newcustomer.Favorites
      });
      newcustomer.Id = id;
      return newcustomer;
    }

    public Customer EditCustomer(int id, Customer newcustomer)
    {
      try
      {
        return _db.QueryFirstOrDefault<Customer>($@"
       UPDATE Customerss SET
       Name = @Name,
      Favorites = @Favorites
       WHERE Id = @Id;
       SELECT * FROM Customers WHERE id = @Id;
       ", newcustomer);
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex);
        return null;
      }
    }


    public bool DeleteCustomer(int id)
    {
      int delete = _db.Execute("DELETE FROM CustomersS WHERE ID = @Id", new { Id = id });
      return true;
    }
  }
}