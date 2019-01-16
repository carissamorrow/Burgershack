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
  public class SidesController : ControllerBase
  {
    private readonly SideRepository _sideRepo;
    public SidesController(SideRepository sideRepo)
    {
      _sideRepo = sideRepo;
    }

    // GET api/Sides
    [HttpGet]
    public ActionResult<IEnumerable<Side>> Get()
    {
      return Ok(_sideRepo.GetAll());
    }

    // GET api/Sides/5
    [HttpGet("{id}")]
    public ActionResult<Side> Get(int id)
    {
      Side result = _sideRepo.GetSideById(id);
      if (result != null)
      {
        return Ok(result);
      }
      return NotFound();
    }

    // POST api/Sides
    [HttpPost]
    public ActionResult<Side> Post([FromBody] Side side)
    {
      return Created("/api/sides/", _sideRepo.AddSide(side));
    }

    // PUT api/Sides/5
    [HttpPut("{id}")]
    public ActionResult<Side> Put(int id, [FromBody] Side side)
    {
      Side result = _sideRepo.EditSide(id, side);
      if (result != null)
      {
        return result;
      }
      return NotFound();
    }

    // DELETE api/Sides/5
    // [HttpDelete("{id}")]
    // public ActionResult<string> Delete(int id)
    // {
    //   if (_sideRepo.DeleteSide(id))
    //   {
    //     return Ok("success");
    //   }
    //   return NotFound("No Side to delete");
    // }
  }
}
