using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;

        public InMemoryCarDal()
        {
            _cars = new List<Car>
            {
                new Car{Id=1,BrandId=1,ColorId=1,ModelYear=2019,DailyPrice=500,Description="Range Rover Sport"},
                new Car{Id=2,BrandId=2,ColorId=1,ModelYear=2011,DailyPrice=170,Description="Toyota Corolla"},
                new Car{Id=3,BrandId=2,ColorId=2,ModelYear=2015,DailyPrice=255,Description="Toyota Yaris"},
                new Car{Id=4,BrandId=3,ColorId=2,ModelYear=2007,DailyPrice=100,Description="Ford Fiesta"},
                new Car{Id=5,BrandId=3,ColorId=3,ModelYear=2019,DailyPrice=500,Description="Ford Focus"},
                new Car{Id=6,BrandId=4,ColorId=3,ModelYear=2017,DailyPrice=450,Description="Mini Cooper Cabria"}
            };
        }

        public List<Car> GetByBrandId(int BrandId)
        {
            return _cars.Where(p => p.BrandId == BrandId).ToList();
        }

        public List<Car> GetByColorId(int ColorId)
        {
            return _cars.Where(p => p.ColorId == ColorId).ToList();
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public void Add(Car car)
        {
            _cars.Add(car);
            Console.WriteLine("\n" + car.Id + "  " + car.Description + " added!");
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(p => p.Id == car.Id);
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
            Console.WriteLine("\n" + car.Id + "  " + car.Description + " updated!");
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(p => p.Id == car.Id);
            _cars.Remove(carToDelete);
            Console.WriteLine("\n" + car.Id + "  " + car.Description + " deleted!");
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }
    }
}
