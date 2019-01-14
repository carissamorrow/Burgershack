using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using BurgerShack.Models;
using Microsoft.AspNetCore.Mvc;

namespace BurgerShack.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class DrinksController : ControllerBase
  {
    public List<Drink> Drinks = new List<Drink>()
    {
      new Drink("Orange Soda", "Tastes like an orange", 2.20f),
      new Drink("Shandy", "21 and up Only!", 4.50f),
      new Drink("Coffee", "Perfectly Bitter", 2.50f)
    };



    // GET api/Drinks
    [HttpGet]
    public IEnumerable<Drink> Get()
    {
      return Drinks;
    }

    // GET api/Drinks/5
    [HttpGet("{id}")]
    public ActionResult<Drink> Get(int id)
    {
      try
      {
        return Drinks[id];
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex);
        return NotFound("{\"error\": \"NO SUCH Drink\"}");
      }
    }

    // POST api/Drinks
    [HttpPost]
    public ActionResult<List<Drink>> Post([FromBody] Drink drink)
    {
      Drinks.Add(drink);
      return Drinks;
    }

    // PUT api/Drinks/5
    [HttpPut("{id}")]
    public ActionResult<List<Drink>> Put(int id, [FromBody] Drink drink)
    {
      try
      {
        Drinks[id] = drink;
        return Drinks;
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex);
        return NotFound("{\"error\": \"NO SUCH DRINK\"}");
      }
    }

    // DELETE api/Drinks/5
    [HttpDelete("{id}")]
    public ActionResult<List<Drink>> Delete(int id)
    {
      try
      {
        Drinks.Remove(Drinks[id]);
        return Drinks;
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex);
        return NotFound("{\"error\": \"NO SUCH DRINK\"}");
      }
    }
  }
}