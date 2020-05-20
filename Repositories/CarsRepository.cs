using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using fullstack_gregslist.Models;

namespace fullstack_gregslist.Repositories
{
  public class CarsRepository
  {
    //NOTE Establish connetion between repository and DB (see CreateDbConnection in Startup.cs)
    private readonly IDbConnection _db;

    public CarsRepository(IDbConnection db)
    {
      _db = db;
    }
    //SECTION Get cars
    internal IEnumerable<Car> GetAll()
    {
      string sql = "SELECT * FROM cars";
      return _db.Query<Car>(sql);
    }
    internal Car GetCarById(int id)
    {
      string sql = "SELECT * FROM cars WHERE id = @Id";
      return _db.QueryFirstOrDefault<Car>(sql, new { id });
    }
    //!SECTION End get cars

    //SECTION Create car

    internal Car Create(Car newCar)
    {
      string sql = @"
        INSERT INTO cars
        (make, model, userId, year, price, imgUrl, description)
        VALUES
        (@Make, @Model, @UserId, @Year, @Price, @ImgUrl, @Description);
        SELECT LAST_INSERT_ID()";
      newCar.Id = _db.ExecuteScalar<int>(sql, newCar);
      return newCar;
    }
    //!SECTION
  }
}