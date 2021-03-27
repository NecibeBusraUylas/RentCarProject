using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspect.Autofac.Caching;
using Core.Aspect.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;

        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }


        [CacheAspect]
        //[SecuredOperation("admin")]
        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll());
        }


        [CacheAspect]
        //[SecuredOperation("admin,rental.list")]
        public IDataResult<Rental> GetById(int Id)
        {
            return new SuccessDataResult<Rental>(_rentalDal.Get(p => p.Id == Id));
        }


        [CacheAspect]
        public IDataResult<List<RentalCarDetailDto>> GetRentalCarDetails()
        {
            return new SuccessDataResult<List<RentalCarDetailDto>>(_rentalDal.GetRentalCarDetails());
        }

        [CacheRemoveAspect("IRentalService.Get")]
        //[SecuredOperation("admin,rental.add")]
        [ValidationAspect(typeof(RentalValidator))]
        public IResult Add(Rental rental)
        {
            //ValidationTool.Validate(new RentalValidator(), rental);

            var result2 = CheckReturnDate(rental.CarId);
            if (!result2.Success)
            {
                return new ErrorResult(result2.Message);
            }
            _rentalDal.Add(rental);
            return new SuccessResult(result2.Message);
        }

        [CacheRemoveAspect("IRentalService.Get")]
        //[SecuredOperation("admin,rental.update")]
        [ValidationAspect(typeof(RentalValidator))]
        public IResult Update(Rental rental)
        {
            _rentalDal.Update(rental);
            return new SuccessResult(Messages.RentalCarUpdated);           
        }

        [CacheRemoveAspect("IRentalService.Get")]
        //[SecuredOperation("admin,rental.delete")]
        public IResult Delete(Rental rental)
        {
            _rentalDal.Delete(rental);
            return new SuccessResult(Messages.RentalCarDeleted);
        }

        public IResult CheckReturnDate(int carId)
        {
            var result = _rentalDal.GetRentalCarDetails(p => p.CarId == carId && p.ReturnDate == null);
            if(result.Count!=0)
            {
                return new ErrorResult(Messages.RentalCarCouldNotAdded);
            }
            return new SuccessResult(Messages.RentalCarAdded);
        }

        public IDataResult<List<RentalCarDetailDto>> GetByCarId(int Id)
        {
            return new SuccessDataResult<List<RentalCarDetailDto>>(_rentalDal.GetRentalCarDetails(c => c.Id == Id));
        }

        public IDataResult<List<RentalCarDetailDto>> GetByCustomerId(int Id)
        {
            return new SuccessDataResult<List<RentalCarDetailDto>>(_rentalDal.GetRentalCarDetails(c => c.CustomerId == Id));
        }

        public IDataResult<List<RentalCarDetailDto>> GetByRentDate(DateTime rentDate)
        {
            return new SuccessDataResult<List<RentalCarDetailDto>>(_rentalDal.GetRentalCarDetails(c => c.RentDate == rentDate));
        }

        public IDataResult<List<RentalCarDetailDto>> GetByReturnDate(DateTime returnDate)
        {
            return new SuccessDataResult<List<RentalCarDetailDto>>(_rentalDal.GetRentalCarDetails(c => c.ReturnDate == returnDate));
        }

        public IResult IsRentable(Rental rental)
        {
            var dates = _rentalDal.GetAll(r => r.CarId == rental.CarId);
            foreach (var date in dates)
            {
                if (date.RentDate <= rental.RentDate && rental.RentDate <= date.ReturnDate)
                {
                    return new ErrorResult();
                }
                else if (date.RentDate <= rental.ReturnDate && rental.ReturnDate <= date.ReturnDate)
                {
                    return new ErrorResult();
                }
                else if (date.RentDate >= rental.RentDate && rental.ReturnDate >= date.ReturnDate)
                {
                    return new ErrorResult();
                }
            }
            return new SuccessResult();
        }
    }
}