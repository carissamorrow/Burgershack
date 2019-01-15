using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using BurgerShack.Models;
using BurgerShack.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace BurgerShack.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class DrinksController : ControllerBase
  {
    private readonly DrinkRepository _drinkRepo;
    public DrinksController(DrinkRepository drinkRepo)
    {
      _drinkRepo = drinkRepo;
    }

    // GET api/Drinks
    [HttpGet]
    // public IEnumerable<Drink> Get()
    // {
    //   return Ok(_drinkRepo.GetAll());
    // }

    // GET api/Drinks/5
    [HttpGet("{id}")]
    public ActionResult<Drink> Get(int id)
    {
      Drink result = _drinkRepo.GetDrinkById(id);
      if (result != null)
      {
        return Ok(result);
      }
      return NotFound();
    }

    // POST api/Drinks
    [HttpPost]
    public ActionResult<Drink> Post([FromBody] Drink drink)
    {
      return Created("/api/drinks/", _drinkRepo.AddDrink(drink));
    }

    // PUT api/Drinks/5
    [HttpPut("{id}")]
    public ActionResult<Drink> Put(int id, [FromBody] Drink drink)
    {
      Drink result = _drinkRepo.EditDrink(id, drink);
      if (result != null)
      {
        return result;
      }
      return NotFound();
    }
    // DELETE api/Drinks/5
    [HttpDelete("{id}")]
    public ActionResult<string> Delete(int id)
    {
      if (_drinkRepo.DeleteDrink(id))
      {
        return Ok("success");
      }
      return NotFound("No Drink to delete");
    }
  }
}