using System;
using System.Collections.Generic;
using fullstack_gregslist.Models;
using fullstack_gregslist.Repositories;

namespace fullstack_gregslist.Controllers
{
  public class CarsService
  {
    //NOTE Set up dependency and link with repository
    private readonly CarsRepository _repo;

    public CarsService(CarsRepository repo)
    {
      _repo = repo;
    }
    //SECTION Get cars
    internal IEnumerable<Car> GetAll()
    {
      return _repo.GetAll();
    }
    public Car GetCarById(int id)
    {
      Car foundCar = _repo.GetCarById(id);
      if (foundCar == null)
      {
        throw new Exception("Invalid ID");
      }
      return foundCar;
    }
    //!SECTION

    //SECTION Create new car
    internal Car Create(Car newCar)
    {
      return _repo.Create(newCar);
    }
    //!SECTION 
  }
}