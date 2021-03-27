using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq.Expressions;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, RentACarContext>, ICarDal
    {
        public List<CarDetailsDto> GetCarDetails(Expression<Func<Car, bool>> filter = null)
        {
          using (RentACarContext context=new RentACarContext())
            {
                var result = from c in filter is null ? context.Cars : context.Cars.Where(filter)
                              join b in context.Brands
                              on c.BrandId equals b.Id
                              join co in context.Colors
                              on c.ColorId equals co.Id
                              select new CarDetailsDto
                              {
                                  CarId = c.Id,
                                  CarModel = c.CarName,
                                  BrandName = b.BrandName,
                                  ColorName = co.ColorName,
                                  DailyPrice = c.DailyPrice,
                                  ModelYear = c.ModelYear,
                                  ImagePath = context.CarImages.Where(x => x.CarId == c.Id).FirstOrDefault().ImagePath,
                                  Status=!context.Rentals.Any(p=>p.CarId==c.Id && p.ReturnDate==null)
                              };

                return result.ToList();
            }
        }
    }
}