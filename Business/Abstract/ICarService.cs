using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Business.Abstract
{
    public interface ICarService
    {
        IResult Add(Car car);
        IResult Update(Car car);
        IResult Delete(Car car);
        IDataResult<List<Car>> GetAll();
        IDataResult<Car> GetById(int carId);
        IDataResult<List<CarDetailsDto>> GetCarsByColorId(int colorId);
        IDataResult<List<CarDetailsDto>> GetCarsByBrandId(int brandId);
        IDataResult<List<CarDetailsDto>> GetByDailyPrice(int min, int max);
        IDataResult<List<CarDetailsDto>> GetByModelYear(int modelYear);
        IDataResult<List<CarDetailsDto>> GetCarDetails(Expression<Func<Car, bool>> filter = null);
        IDataResult<List<CarDetailsDto>> GetCarsBySelect(int brandId, int colorId);
        IDataResult<List<CarDetailsDto>> GetCarDetail(int carId);
    }
}