using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarService
    {
        List<Car> GetAll();
        Car GetById(int Id);
        List<Car> GetAllByBrandId(int Id);
        List<Car> GetAllByColorId(int Id);
        List<Car> GetByModelYear(int year);
        List<Car> GetByDailyPrice(int min, int max);
        void Add(Car car);
        void Update(Car car);
        void Delete(Car car);
    }
}