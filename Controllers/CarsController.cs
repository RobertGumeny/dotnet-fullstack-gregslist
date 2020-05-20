using System;
using System.Collections.Generic;
using System.Security.Claims;
using fullstack_gregslist.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace fullstack_gregslist.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class CarsController : ControllerBase
  {
    private readonly CarsService _cs;

    public CarsController(CarsService cs)
    {
      _cs = cs;
    }

    //SECTION Get requests
    [HttpGet]
    public ActionResult<IEnumerable<Car>> GetAll()
    {
      try
      {
        return Ok(_cs.GetAll());
      }
      catch (System.Exception err)
      {
        return BadRequest(err.Message);
      }
    }
    //NOTE Do not forget to close the {}, VS code doesn't automatically close it when inside a string!!!
    [HttpGet("{id}")]
    public ActionResult<Car> GetCarById(int id)
    {
      try
      {
        return Ok(_cs.GetCarById(id));
      }
      catch (System.Exception err)
      {
        return BadRequest(err.Message);

      }
    }
    //!SECTION End get requests
    //SECTION Put requests
    //!SECTION End put requests
    //SECTION Post requests
    //NOTE Check to see if user is logged in and authorized before allowing them to create a new post
    [Authorize]
    [HttpPost]
    public ActionResult<Car> Create([FromBody] Car newCar)
    {
      try
      {
        Claim user = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier);
        if (user == null)
        {
          throw new Exception("Not logged in");
        }
        newCar.UserId = user.Value;
        return Ok(_cs.Create(newCar));
      }
      catch (System.Exception err)
      {
        return BadRequest(err.Message);
      }
    }
    //!SECTION End post requests
    //SECTION Delete requests
    //!SECTION End delete requests


  }
}