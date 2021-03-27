using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IRentalService
    {
        IDataResult<List<Rental>> GetAll();
        IDataResult<Rental> GetById(int Id);
        IDataResult<List<RentalCarDetailDto>> GetByCarId(int Id);
        IDataResult<List<RentalCarDetailDto>> GetByCustomerId(int customerId);
        IDataResult<List<RentalCarDetailDto>> GetByRentDate(DateTime rentDate);
        IDataResult<List<RentalCarDetailDto>> GetByReturnDate(DateTime returnDate);
        IDataResult<List<RentalCarDetailDto>> GetRentalCarDetails();
        IResult Add(Rental rental);
        IResult Update(Rental rental);
        IResult Delete(Rental rental);
        IResult CheckReturnDate(int carId);
        IResult IsRentable(Rental rental);
    }
}