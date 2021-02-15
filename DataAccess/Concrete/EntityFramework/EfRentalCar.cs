using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, RentCarContext>, IRentalDal
    {
        public List<RentalCarDetailDto> GetRentalCarDetails(Expression<Func<Rental,bool>>filter=null)
        {
            using (RentCarContext context = new RentCarContext())
            {
                var result = from r in filter is null ? context.Rentals :context.Rentals.Where(filter)
                             join car in context.Cars
                             on r.CarId equals car.Id
                             join customer in context.Customers
                             on r.CustomerId equals customer.Id
                             join u in context.Users
                             on customer.UserId equals u.Id
                             select new RentalCarDetailDto 
                             { 
                                 Id = r.Id,
                                 CarId = car.Id,
                                 CarName = car.CarName, 
                                 CustomerName = customer.CompanyName,
                                 UserName = u.FirstName + " " + u.LastName,
                                 RentDate = r.RentDate, 
                                 ReturnDate = r.ReturnDate
                             };
                return result.ToList();
            }
        }
    }
}