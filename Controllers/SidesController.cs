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
  public class SidesController : ControllerBase
  {
    public List<Side> Sides = new List<Side>()
    {
      new Side("Mac and Cheese", "Creamy, topped with bacon!", 8.00f),
      new Side("Chili Fries", "Now with extra chili!", 3.50f),
      new Side("Applesauce", "Healthy but delicious", 2.75f)
    };



    // GET api/Sides
    [HttpGet]
    public IEnumerable<Side> Get()
    {
      return Sides;
    }

    // GET api/Sides
    [HttpGet("{id}")]
    public ActionResult<Side> Get(int id)
    {
      try
      {
        return Sides[id];
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex);
        return NotFound("{\"error\": \"NO SUCH Side\"}");
      }
    }

    // POST api/Sides
    [HttpPost]
    public ActionResult<List<Side>> Post([FromBody] Side side)
    {
      Sides.Add(side);
      return Sides;
    }

    // PUT api/Sides/4
    [HttpPut("{id}")]
    public ActionResult<List<Side>> Put(int id, [FromBody] Side side)
    {
      try
      {
        Sides[id] = side;
        return Sides;
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex);
        return NotFound("{\"error\": \"NO SUCH SIDE\"}");
      }
    }

    // DELETE api/Sides/5
    [HttpDelete("{id}")]
    public ActionResult<List<Side>> Delete(int id)
    {
      try
      {
        Sides.Remove(Sides[id]);
        return Sides;
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex);
        return NotFound("{\"error\": \"NO SUCH SIDE\"}");
      }
    }

  }
}