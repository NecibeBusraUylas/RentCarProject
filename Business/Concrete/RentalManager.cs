using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
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

        [SecuredOperation("admin")]
        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll());
        }

        [SecuredOperation("admin,rental.list")]
        public IDataResult<Rental> GetById(int Id)
        {
            return new SuccessDataResult<Rental>(_rentalDal.Get(p => p.Id == Id));
        }

        [SecuredOperation("admin")]
        public IDataResult<List<RentalCarDetailDto>> GetRentalCarDetails()
        {
            return new SuccessDataResult<List<RentalCarDetailDto>>(_rentalDal.GetRentalCarDetails());
        }

        [SecuredOperation("admin,rental.add")]
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

        [SecuredOperation("admin,rental.update")]
        [ValidationAspect(typeof(RentalValidator))]
        public IResult Update(Rental rental)
        {
            _rentalDal.Update(rental);
            return new SuccessResult(Messages.RentalCarUpdated);           
        }

        [SecuredOperation("admin,rental.delete")]
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
    }
}