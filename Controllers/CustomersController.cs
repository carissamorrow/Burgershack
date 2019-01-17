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
  public class CustomersController : ControllerBase
  {
    private readonly CustomerRepository _Repo;
    public CustomersController(CustomerRepository customerRepo)
    {
      _Repo = customerRepo;
    }

    // GET api/Customers
    [HttpGet]
    public ActionResult<IEnumerable<Customer>> Get()
    {
      return Ok(_Repo.GetAll());
    }

    // GET api/Customers/3
    [HttpGet("{id}")]
    public ActionResult<Customer> Get(int id)
    {
      Customer result = _Repo.GetCustomerById(id);
      if (result != null)
      {
        return Ok(result);
      }
      return NotFound();
    }

    // POST api/Customers
    [HttpPost]
    public ActionResult<Customer> Post([FromBody] Customer customer)
    {
      return Created("/api/customers/", _Repo.AddCustomer(customer));
    }

    // PUT api/Customers
    [HttpPut("{id}")]
    public ActionResult<Customer> Put(int id, [FromBody] Customer customer)
    {
      if (customer.Id == 0)
      {
        customer.Id = id;
      }
      Customer result = _Repo.EditCustomer(id, customer);
      if (result != null)
      {
        return result;
      }
      return NotFound();
    }

    [HttpDelete("{id}")]
    public ActionResult<string> Delete(int id)
    {
      if (_Repo.DeleteCustomer(id))
      {
        return Ok("success");
      }
      return NotFound("No Customer to delete");
    }
  }
}