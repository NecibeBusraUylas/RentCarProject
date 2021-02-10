using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class BrandManager : IBrandService
    {
        IBrandDal _brandDal;

        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }

        public List<Brand> GetAll()
        {
            return _brandDal.GetAll();
        }

        public Brand GetById(int Id)
        {
            return _brandDal.Get(p => p.Id == Id);
        }

        public void Add(Brand brand)
        {
            if (brand.BrandName.Length >= 2)
            {
                _brandDal.Add(brand);
                Console.WriteLine("\nNew brand added!\n");
            }
            else
            {
                Console.WriteLine("\nBrand could not be added.\n");
            }
        }

        public void Update(Brand brand)
        {
            if (brand.BrandName.Length >= 2)
            {
                _brandDal.Update(brand);
                Console.WriteLine("\nNew brand updated!");
            }
            else
            {
                Console.WriteLine("\nBrand could not be updated.\n");
            }
        }

        public void Delete(Brand brand)
        {
            _brandDal.Delete(brand);
            Console.WriteLine("\nBrand deleted!\n");
        }
    }
}
