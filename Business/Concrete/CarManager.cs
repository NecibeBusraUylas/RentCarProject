using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
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

        public IDataResult<List<Car>> GetAll()
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll());
        }

        public IDataResult<Car> GetById(int Id)
        {
            return new SuccessDataResult<Car>(_carDal.Get(p => p.Id == Id));
        }
        public IDataResult<List<Car>> GetAllByBrandId(int Id)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(p => p.BrandId == Id));
        }

        public IDataResult<List<Car>> GetAllByColorId(int Id)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(p => p.ColorId == Id));
        }

        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails());
        }

        public IDataResult<List<Car>> GetByDailyPrice(int min, int max)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(p => p.DailyPrice >= min && p.DailyPrice <= max));
        }

        public IResult Add(Car car)
        {
            if(car.DailyPrice < 0 || car.CarName.Length < 2)
            {
                if (car.DailyPrice < 0)
                {
                    return new ErrorResult(Messages.InvalidDailyPrice);
                }
                else if (car.CarName.Length < 2)
                {
                    return new ErrorResult(Messages.InvalidCarName);
                }
            }
                _carDal.Add(car);
                return new SuccessResult(Messages.CarAdded + car.CarName + "\n");
        }

        public IResult Update(Car car)
        {
            if (car.DailyPrice > 0)
            {
                _carDal.Update(car);
                return new SuccessResult(Messages.CarUpdated);
            }
            else
            {
                return new ErrorResult(Messages.CarCouldNotUpdated);
            }
        }

        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult(Messages.CarDeleted);
        }
    }
}
