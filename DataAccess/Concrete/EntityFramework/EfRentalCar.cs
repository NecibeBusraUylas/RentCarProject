﻿using Core.DataAccess.EntityFramework;
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
    public class EfRentalDal : EfEntityRepositoryBase<Rental, RentACarContext>, IRentalDal
    {
        public List<RentalCarDetailDto> GetRentalCarDetails(Expression<Func<Rental,bool>>filter=null)
        {
            using (RentACarContext context = new RentACarContext())
            {
                var result = from r in filter is null ? context.Rentals :context.Rentals.Where(filter)
                             join car in context.Cars
                             on r.CarId equals car.Id
                             join customer in context.Customers
                             on r.CustomerId equals customer.Id
                             join u in context.Users
                             on customer.UserId equals u.Id
                             join b in context.Brands
                             on car.BrandId equals b.Id
                             select new RentalCarDetailDto 
                             {
                                 Id = r.Id,
                                 BrandName=b.BrandName,
                                 FirstName=u.FirstName,
                                 LastName=u.LastName,
                                 CustomerName = customer.CompanyName,
                                 RentDate = r.RentDate, 
                                 ReturnDate = r.ReturnDate
                             };
                return result.ToList();
            }
        }
    }
}