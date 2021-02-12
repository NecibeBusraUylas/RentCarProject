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
    public class EfCarDal : EfEntityRepositoryBase<Car, RentCarContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails()
        {
            using (RentCarContext context = new RentCarContext())
            {
                var result = from car in context.Cars
                             join b in context.Brands
                             on car.BrandId equals b.Id
                             join color in context.Colors
                             on car.ColorId equals color.Id
                             select new CarDetailDto { Id=car.Id ,BrandName=b.BrandName ,ColorName=color.ColorName ,ModelYear=car.ModelYear , DailyPrice=car.DailyPrice ,CarName=car.CarName };
                return result.ToList();
            }
        }
    }
}