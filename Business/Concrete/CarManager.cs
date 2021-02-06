using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public List<Car> GetAll()
        {
            return _carDal.GetAll();
        }
        public Car GetById(int Id)
        {
            return _carDal.Get(p => p.Id == Id);
        }

        public List<Car> GetAllByBrandId(int Id)
        {
            return _carDal.GetAll(p => p.BrandId == Id);
        }

        public List<Car> GetAllByColorId(int Id)
        {
            return _carDal.GetAll(p => p.ColorId == Id);
        }

        public List<Car> GetByModelYear(int year)
        {
            return _carDal.GetAll(p => p.ModelYear == year);
        }

        public List<Car> GetByDailyPrice(int min, int max)
        {
            return _carDal.GetAll(p => p.DailyPrice>= min && p.DailyPrice <= max);
        }

        public void Add(Car car)
        {
            if (car.DailyPrice > 0 && car.Description.Length >= 2)
            {
                _carDal.Add(car);
                Console.WriteLine("New car added! " + car.Description);
                Console.WriteLine("\n");
            }
            else
            {
                Console.WriteLine("Car could not be added.\n");
            }
        }

        public void Update(Car car)
        {
            if (car.DailyPrice > 0)
            {
                _carDal.Update(car);
                Console.WriteLine("Information about car updated!\n");
            }
            else
            {
                Console.WriteLine("Information about car could not be updated.Daily Price must be greater than 0.\n");
            }
        }

        public void Delete(Car car)
        {
            _carDal.Delete(car);
            Console.WriteLine("Car deleted!\n");
        }
    }
}
