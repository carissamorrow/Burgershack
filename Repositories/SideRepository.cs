using System;
using System.Collections.Generic;
using BurgerShack.Db;
using BurgerShack.Models;

namespace BurgerShack.Repositories
{
  public class SideRepository
  {
    // private readonly FakeDB;

    public IEnumerable<Side> GetAll()
    {
      // return _db.Query<IEnumerable<Side>>(@"
      // SELECT * FROM Sides;
      // ");
      return FakeDB.Sides;
    }
    public Side GetSideById(int id)
    {
      try
      {
        return FakeDB.Sides[id];
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex);
        return null;
      }
    }
    public Side AddSide(Side newside)
    {
      FakeDB.Sides.Add(newside);
      return newside;
    }

    public Side EditSide(int id, Side newside)
    {
      try
      {
        FakeDB.Sides[id] = newside;
        return newside;
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex);
        return null;
      }
    }


    public bool DeleteSide(int id)
    {
      try
      {
        FakeDB.Sides.Remove(FakeDB.Sides[id]);
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
