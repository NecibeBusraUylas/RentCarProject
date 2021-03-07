using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarService
    {
        IDataResult<List<Car>> GetAll();
        IDataResult<Car> GetById(int Id);
        IDataResult<List<Car>> GetAllByBrandId(int Id);
        IDataResult<List<Car>> GetAllByColorId(int Id);
        IDataResult<List<CarDetailDto>> GetCarDetails();
        IDataResult<List<Car>> GetByDailyPrice(int min, int max);
        IResult Add(Car car);
        IResult Update(Car car);
        IResult Delete(Car car);
        IResult TransactionalOperation(Car car);
    }
}